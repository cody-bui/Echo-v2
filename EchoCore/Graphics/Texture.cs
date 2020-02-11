﻿using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace EchoCore.Graphics
{
    public class Texture
    {
        private int id;

        /// <summary>
        /// 2d texture
        /// </summary>
        /// <param name="path">texture path</param>
        /// <param name="wrapS">wrap s (x)</param>
        /// <param name="wrapT">wrap t (y)</param>
        /// <param name="minFilter">min filter</param>
        /// <param name="magFilter">mag filter</param>
        public Texture(string name, TextureWrapMode wrap = TextureWrapMode.ClampToBorder, bool pixelated = false)
        {
            Log.ConsoleLog(Log.LogType.Init, "new texture");

            // gen texture
            id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            // texture wrapping
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)wrap); // s (x)
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)wrap); // t (y)

            // texture filtering
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)   // min filter
                (pixelated ? TextureMinFilter.Nearest : TextureMinFilter.Linear));
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)   // mag filter
                (pixelated ? TextureMagFilter.Nearest : TextureMagFilter.Linear));

            // load the image
            Image<Rgba32> image = (Image<Rgba32>)Image.Load(@"C:\Users\Rogue\source\repos\Echo.NET\EchoCore\Assets\Textures\" + name);

            // flip the image vertically bc opengl loads image reversed
            image.Mutate(x => x.Flip(FlipMode.Vertical));

            // pixel array in imagesharp's format
            Rgba32[] px = image.GetPixelSpan().ToArray();

            // pixel array in opengl format
            List<byte> pixels = new List<byte>();
            foreach (Rgba32 p in px)
            {
                pixels.Add(p.R);
                pixels.Add(p.G);
                pixels.Add(p.B);
                pixels.Add(p.A);
            }

            // load texture
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixels.ToArray());
        }

        ~Texture()
        {
            GL.DeleteTexture(id);
        }

        /// <summary>
        /// bind texture to unit 0 or 1
        /// </summary>
        /// <param name="first">is first unit</param>
        public void Bind(bool first)
        {
            if (first)
                GL.ActiveTexture(TextureUnit.Texture0);
            else
                GL.ActiveTexture(TextureUnit.Texture1);

            GL.BindTexture(TextureTarget.Texture2D, id);
        }

        /// <summary>
        /// unbind texture from unit 0 or 1
        /// </summary>
        /// <param name="first">is first unit</param>
        public void Unbind(bool first)
        {
            if (first)
                GL.ActiveTexture(TextureUnit.Texture0);
            else
                GL.ActiveTexture(TextureUnit.Texture1);
            
            GL.BindTexture(TextureTarget.Texture2D, id);
        }

        private bool disposed = false;

        /// <summary>
        /// dispose function
        /// </summary>
        /// <param name="disposing"></param>
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                Log.ConsoleLog(Log.LogType.Delete, "delete texture");
                GL.DeleteTexture(id);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}