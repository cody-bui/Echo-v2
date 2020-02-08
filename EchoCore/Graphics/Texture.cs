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
        /// <summary>
        /// 2d texture
        /// </summary>
        /// <param name="path">texture path</param>
        /// <param name="wrapS">wrap s (x)</param>
        /// <param name="wrapT">wrap t (y)</param>
        /// <param name="minFilter">min filter</param>
        /// <param name="magFilter">mag filter</param>
        public Texture(string name, TextureWrapMode wrapS, TextureWrapMode wrapT, TextureMinFilter minFilter, TextureMagFilter magFilter)
        {
            // texture wrapping
            GL.TexParameter(TextureTarget.Texture3D, TextureParameterName.TextureWrapS, (int)wrapS);    // s (x)
            GL.TexParameter(TextureTarget.Texture3D, TextureParameterName.TextureWrapT, (int)wrapT);    // t (y)

            // texture filtering
            GL.TexParameter(TextureTarget.Texture3D, TextureParameterName.TextureMinFilter, (int)minFilter);    // min
            GL.TexParameter(TextureTarget.Texture3D, TextureParameterName.TextureMagFilter, (int)magFilter);    // mag

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

            // generate the image
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixels.ToArray());
        }
    }
}