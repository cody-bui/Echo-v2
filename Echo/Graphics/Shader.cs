using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Echo.Graphics
{
    public class Shader
    {
        private int id;
        private string _name;

        /// <summary>
        /// uniform location cache
        /// </summary>
        private Dictionary<string, int> uniforms;

        public Shader(in string name, in ShaderType[] types)
        {
            _name = name;
            Log.Init($"new shader: {name}");

            // create new shader program
            id = GL.CreateProgram();

            List<int> shaders = new List<int>();
            uniforms = new Dictionary<string, int>();

            // compile all shaders
            for (int i = 0; i < types.Length; i++)
            {
                shaders.Add(CompileShader(in name, types[i]));
                GL.AttachShader(id, shaders[shaders.Count - 1]);
            }

            GL.LinkProgram(id);

            // detach all shaders
            for (int i = 0; i < shaders.Count; i++)
            {
                GL.DetachShader(id, shaders[i]);
                GL.DeleteShader(shaders[i]);
            }

            // unbind for safety reason
            GL.UseProgram(0);
        }

        /// <summary>
        /// parse the shader and compile the shader
        /// </summary>
        /// <param name="name">shader name, excluding '.' and file extension</param>
        /// <param name="type">type of the shader</param>
        /// <returns></returns>
        private int CompileShader(in string name, ShaderType type)
        {
            string fpath = $@"{Loader.Asset}\Shaders\{name}{ShaderExtension(type)}";
            string source;
            int shader;

            // parse and create the shader
            using (StreamReader reader = new StreamReader(fpath, Encoding.UTF8))
                source = reader.ReadToEnd();

            Log.Info($"{type.ToString()}\n{source}\n");

            shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);

            // compile and validate the shader
            GL.CompileShader(shader);

            string info = GL.GetShaderInfoLog(shader);
            if (info != System.String.Empty)
                System.Console.WriteLine(info);

            return shader;
        }

        /// <summary>
        /// convert shader type to shader file extension
        /// </summary>
        /// <param name="type">shader type</param>
        /// <returns></returns>
        private string ShaderExtension(ShaderType type)
        {
            switch (type)
            {
                case (ShaderType.FragmentShader):
                    return ".frag";

                case (ShaderType.GeometryShader):
                    return ".geom";

                case (ShaderType.VertexShader):
                    return ".vert";

                default:
                    throw new ArgumentException();      // unsupported type
            }
        }

        ~Shader()
        {
            Log.Delete($"delete shader{_name}");
            GL.DeleteProgram(id);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                Log.Delete($"delete shader: {_name}");
                GL.DeleteProgram(id);
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Bind()
        {
            GL.UseProgram(id);
        }

        public void UnBind()
        {
            GL.UseProgram(0);
        }

        /// <summary>
        /// find the uniform location
        /// </summary>
        /// <param name="name">attribute name</param>
        /// <returns></returns>
        private int UniformLocation(in string name)
        {
            // if uniform has been looked up before
            if (uniforms.ContainsKey(name))
                return uniforms[name];

            int location = GL.GetUniformLocation(id, name);

            if (location == -1)
                Log.Warning($"uniform {name} not found");
            else
                uniforms.Add(name, location);

            return location;
        }

        public void SetUniform(in string name, in Vector4 vec)
            => GL.Uniform4(UniformLocation(in name), vec);

        public void SetUniform(in string name, float v1, float v2, float v3, float v4)
            => GL.Uniform4(UniformLocation(in name), v1, v2, v3, v4);

        public void SetUniform(in string name, int v1, int v2, int v3, int v4)
            => GL.Uniform4(UniformLocation(in name), v1, v2, v3, v4);

        public void SetUniform(in string name, in Vector3 vec)
            => GL.Uniform3(UniformLocation(in name), vec);

        public void SetUniform(in string name, float v1, float v2, float v3)
            => GL.Uniform3(UniformLocation(in name), v1, v2, v3);

        public void SetUniform(in string name, int v1, int v2, int v3)
            => GL.Uniform3(UniformLocation(in name), v1, v2, v3);

        public void SetUniform(in string name, in Vector2 vec)
            => GL.Uniform2(UniformLocation(in name), vec);

        public void SetUniform(in string name, float v1, float v2)
            => GL.Uniform2(UniformLocation(in name), v1, v2);

        public void SetUniform(in string name, int v1, int v2)
            => GL.Uniform2(UniformLocation(in name), v1, v2);

        public void SetUniform(in string name, float val)
            => GL.Uniform1(UniformLocation(name), val);

        public void SetUniform(in string name, int val)
            => GL.Uniform1(UniformLocation(name), val);
    }
}