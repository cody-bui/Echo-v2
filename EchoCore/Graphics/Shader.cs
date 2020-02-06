using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

namespace EchoCore.Graphics
{
    public class Shader
    {
        private int id;
        private string _name;
        private List<int> shaders;

        /// <summary>
        /// shader constructor
        /// </summary>
        /// <param name="shaderName">name of the shader file, excluding '.' and file extension</param>
        /// <param name="shaderTypes">shader types, used to determine file extension</param>
        public Shader(string name, ShaderType[] types)
        {
            _name = name;
            Log.ConsoleLog(Log.LogType.Init, $"new shader: {name}");

            id = GL.CreateProgram();
            shaders = new List<int>();

            // compile all shaders
            for (int i = 0; i < types.Length; i++)
            {                
                shaders.Add(CompileShader(name, types[i]));
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

        // delete shader program
        ~Shader()
        {
            Log.ConsoleLog(Log.LogType.Delete, $"delete shader: {_name}");
            GL.DeleteProgram(id);
        }

        // for disposing the shader
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                Log.ConsoleLog(Log.LogType.Delete, $"delete shader: {_name}");
                GL.DeleteProgram(id);
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // bind shader
        public void Bind()
        {
            GL.UseProgram(id);
        }

        // unbind shader
        public void UnBind()
        {
            GL.UseProgram(0);
        }

        /// <summary>
        /// parse the shader and compile the shader
        /// </summary>
        /// <param name="name">shader name, excluding '.' and file extension</param>
        /// <param name="type">type of the shader</param>
        /// <returns></returns>
        private int CompileShader(string name, ShaderType type)
        {
            string fpath = 
                @"C:\Users\Rogue\source\repos\Echo.NET\EchoCore\Assets\Shaders\" + 
                name + ShaderExtension(type);
            string source;
            int shader;

            // parse and create the shader
            using (StreamReader reader = new StreamReader(fpath, Encoding.UTF8))
                source = reader.ReadToEnd();

            Log.ConsoleLog(Log.LogType.Message, $"{type.ToString()}\n{source}\n");

            shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);

            // compile and validate the shader
            GL.CompileShader(shader);

            string info = GL.GetShaderInfoLog(shader);
            if (info != System.String.Empty)
                System.Console.WriteLine(info);

            return shader;
        }

        // convert shader type to file extension name
        private string ShaderExtension(ShaderType type)
        {
            switch(type)
            {
                case (ShaderType.FragmentShader):
                    return ".frag";
                case (ShaderType.GeometryShader):
                    return ".geom";
                default:            // default to vertex shader
                    return ".vert";
            }
        }
    }
}
