using OpenTK.Graphics.OpenGL4;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;

namespace Echo.Graphics
{
    public class Texture
    {
        private int id;

        public Texture(string file, TextureWrapMode wrap = TextureWrapMode.ClampToBorder, bool pixelated = false)
        {
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

            using (Image<Rgba32> image = (Image<Rgba32>)Image.Load($@"{Loader.Asset}\Textures\{file}"))
            {
                // flip the image vertically bc opengl loads image reversed
                image.Mutate(x => x.Flip(FlipMode.Vertical));

                Rgba32[] px = image.GetPixelSpan().ToArray();

                byte[] pixels = new byte[px.Length * 4];
                for (int i = 0; i < px.Length; i++)
                {
                    pixels[i*4] = px[i].R;
                    pixels[i*4+1] = px[i].G;
                    pixels[i*4+2] = px[i].B;
                    pixels[i*4+3] = px[i].A;
                }

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixels);
            }

            Log.Init("texture loaded");
        }

        ~Texture()
        {
            GL.DeleteTexture(id);
        }

        public void Bind(int unit)
        {
            if (unit == 0 || unit == 1)
            {
                GL.ActiveTexture(TextureUnit.Texture0 + unit + 1);
                GL.BindTexture(TextureTarget.Texture2D, id);
            }
            else
            {
                Log.Warning($"unit {unit} out of range, nothing binded");
            }
        }

        public void Unbind(int unit)
        {
            if (unit == 0 || unit == 1)
            {
                GL.ActiveTexture(TextureUnit.Texture0 + unit + 1);
                GL.BindTexture(TextureTarget.Texture2D, id);
            }
            else
            {
                Log.Warning($"unit {unit} out of range, nothing binded");
            }
        }

        private bool disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                GL.DeleteTexture(id);
            }

            Log.Delete("texture deleted");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}