using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

// http://www.vcskicks.com/license.php

namespace Convolution
{
	public class BoxFilter
	{
		private Bitmap Convolve(Bitmap input, float[,] filter)
		{
			//Find center of filter
			int xMiddle = (int)Math.Floor(filter.GetLength(0) / 2.0);
			int yMiddle = (int)Math.Floor(filter.GetLength(1) / 2.0);

			//Create new image
			Bitmap output = new Bitmap(input.Width, input.Height);

			FastBitmap reader = new FastBitmap(input);
			FastBitmap writer = new FastBitmap(output);
			reader.LockImage();
			writer.LockImage();

			for (int x = 0; x < input.Width; x++)
			{
				for (int y = 0; y < input.Height; y++)
				{
					float a = 0;
					float r = 0;
					float g = 0;
					float b = 0;

					//Apply filter
					for (int xFilter = 0; xFilter < filter.GetLength(0); xFilter++)
					{
						for (int yFilter = 0; yFilter < filter.GetLength(1); yFilter++)
						{
							int x0 = x - xMiddle + xFilter;
							int y0 = y - yMiddle + yFilter;

							//Only if in bounds
							if (x0 >= 0 && x0 < input.Width &&
								y0 >= 0 && y0 < input.Height)
							{
								Color clr = reader.GetPixel(x0, y0);

								a += clr.A * filter[xFilter, yFilter];
								r += clr.R * filter[xFilter, yFilter];
								g += clr.G * filter[xFilter, yFilter];
								b += clr.B * filter[xFilter, yFilter];
							}
						}
					}

					//Normalize (basic)
					if (a > 255)
						a = 255;
					if (r > 255)
						r = 255;
					if (g > 255)
						g = 255;
					if (b > 255)
						b = 255;

					if (a < 0)
						a = 0;
					if (r < 0)
						r = 0;
					if (g < 0)
						g = 0;
					if (b < 0)
						b = 0;

					//Set the pixel
					writer.SetPixel(x, y, Color.FromArgb((int)a, (int)r, (int)g, (int)b));
				}
			}

			reader.UnlockImage();
			writer.UnlockImage();

			return output;
		}

		/// <summary>
		/// Returns a box filter 1D kernel that is in the format {1,..,n}
		/// </summary>
		private float[,] GetHorizontalFilter(int size)
		{
			float[,] smallFilter = new float[size, 1];
			float constant = size;

			for (int i = 0; i < size; i++)
			{
				smallFilter[i, 0] = 1.0f / constant;
			}

			return smallFilter;
		}

		/// <summary>
		/// Returns a box filter 1D kernel that is in the format {1},...,{n}
		/// </summary>
		private float[,] GetVerticalFilter(int size)
		{
			float[,] smallFilter = new float[1, size];
			float constant = size;

			for (int i = 0; i < size; i++)
			{
				smallFilter[0, i] = 1.0f / constant;
			}

			return smallFilter;
		}

		/// <summary>
		/// Returns a box filter 2D kernel in the format {1,...,n},...,{1,...,n}
		/// </summary>
		private float[,] GetBoxFilter(int size)
		{
			float[,] filter = new float[size, size];
			float constant = size * size;

			for (int i = 0; i < filter.GetLength(0); i++)
			{
				for (int j = 0; j < filter.GetLength(1); j++)
				{
					filter[i, j] = 1.0f / constant;
				}
			}

			return filter;
		}

		public Bitmap BoxBlur(Image img, int size)
		{
			//Apply a box filter by convolving the image with a 2D kernel
			return Convolve(new Bitmap(img), GetBoxFilter(size));
		}

		public Bitmap FastBoxBlur(Image img, int size)
		{
			//Apply a box filter by convolving the image with two separate 1D kernels (faster)
			return Convolve(Convolve(new Bitmap(img), GetHorizontalFilter(size)), GetVerticalFilter(size));
		}
	}
}
