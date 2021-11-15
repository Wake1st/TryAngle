using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleApp
{
    public class VisualElement
    {
        public List<string> Shape;

        public int Height;
        public int Width;
        public int Left;
        public int Top;
        public int Layer;

        /// <summary>
        /// Creates whatever is given
        /// </summary>
        /// <param name="shape"></param>
        public VisualElement(string[] shape, int left, int top, int layer)
        {
            Shape = shape.ToList();

            Height = shape.Length;
            Width = shape[0].Length;
            Left = left;
            Top = top;
            Layer = layer;
        }

        /// <summary>
        /// Creates an empty space, with a possible border
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="borderCharCode"></param>
        public VisualElement(int width, int height, int left, int top, int layer, int borderCharCode = 9619)
        {
            Shape = new List<string>();

            char border = (char)borderCharCode;
            bool drawingBorder = false;

            for (int j = 0; j<height; j++)
			{
                Shape.Add("");
                drawingBorder = j == 0 || j == height - 1;

                for (int i = 0; i<width; i++)
			    {
                    Shape[j] += drawingBorder ? border : ((i == 0 || i == width - 1) ? border : ' ');
			    }
			}

            Left = left;
            Top = top;
            Layer = layer;
        }
    }
}
