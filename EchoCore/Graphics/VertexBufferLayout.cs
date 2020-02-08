using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;

namespace EchoCore.Graphics
{
    /// <summary>
    /// containing data to construct VertexAttribPointer
    /// </summary>
    internal class VertexBufferLayoutData
    {
        public VertexAttribPointerType Type { private set; get; }
        public int ByteSize { private set; get; }
        public int Count { private set; get; }
        public bool Normalized { private set; get; }

        public VertexBufferLayoutData(VertexAttribPointerType type, int byteSize, int count, bool normalized)
        {
            Type = type;
            ByteSize = byteSize;
            Count = count;
            Normalized = normalized;
        }
    }

    /// <summary>
    /// hold all vertex buffer layout data
    /// </summary>
    internal class VertexBufferLayout
    {
        public List<VertexBufferLayoutData> Element { private set; get; }
        public int Stride { private set; get; }

        public VertexBufferLayout()
        {
            Element = new List<VertexBufferLayoutData>();
        }

        /// <summary>
        /// add layout elements
        /// </summary>
        /// <typeparam name="T">type of data</typeparam>
        /// <param name="count">layout element count</param>
        public void Add<T>(int count)
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Single:
                    Element.Add(new VertexBufferLayoutData(VertexAttribPointerType.Float, sizeof(float), count, false));
                    break;

                case TypeCode.Double:
                    Element.Add(new VertexBufferLayoutData(VertexAttribPointerType.Double, sizeof(double), count, false));
                    break;

                case TypeCode.Int32:
                    Element.Add(new VertexBufferLayoutData(VertexAttribPointerType.Int, sizeof(int), count, true));
                    break;

                default:
                    EchoCore.Log.ConsoleLog(Log.LogType.Error, "invalid vertex buffer layout type");
                    throw new ArgumentException();
            }
        }
    }
}