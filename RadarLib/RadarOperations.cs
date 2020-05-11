using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace RadarLib
{
	/// <summary>
	/// Статический класс для расчета и записи в файлы обратной
	/// корреляционной матрицы наблюдений на основе параметров 
	/// наблюдений и ранее сгенерированной матрицы наблюдений,
	/// считываемой из файлов.
	/// </summary>
	public static class RadarOperations
	{
		/// <summary>
		/// Вызываемый извне метод класса, который 
		/// вызывает методы считывания матрицы наблюдений,
		/// расчета обратной корреляционной матрицы и 
		/// записи ее в файл, кроме того осуществляется 
		/// измерение времени всего процесса обработки
		/// информации, и оно возвращается в точку вызова.
		/// </summary>
		/// <param name="m"> Параметр для размеров приемной
		/// решетки радиолокатора. </param>
		/// <param name="n"> Параметр для количества векторов
		/// наблюдений, по которым составляется корреляционная
		/// матрица. </param>
		/// <param name="pq"> Параметр числа блоков, по которым
		/// составляются наблюдения и корреляционная матрица. </param>
		/// <param name="mu"> Параметр для коэффициента
		/// регуляризации корреляционной матрицы. </param>
		/// <param name="pathYx"> Параметр для пути к файлу, в
		/// котором находятся вещественные компоненты матрицы
		/// наблюдений. </param>
		/// <param name="pathYy"> Параметр для пути к файлу, в
		/// котором находятся мнимые компоненты матрицы
		/// наблюдений. </param>
		/// <param name="pathRx"> Параметр для пути к файлу, в
		/// котором находятся вещественные компоненты обратной 
		/// корреляционной матрицы. </param>
		/// <param name="pathRy"> Параметр для пути к файлу, в
		/// котором находятся мнимые компоненты обратной 
		/// корреляционной матрицы. </param>
		/// <returns> Метод возвращает время работы по расчету и 
		/// записи обратной корреляционной матрицы. </returns>
		public static TimeSpan Start(int m, int n, int pq, float mu,
			string pathYx = "YX.txt", string pathYy = "YY.txt",
			string pathRx = "Rx.txt", string pathRy = "Ry.txt")
		{
			int dataSize = pq * n * m;
			int outSize = pq * m * m;

			Complex[] data, outMatrix;

			outMatrix = new Complex[outSize];
			data = new Complex[dataSize];

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			try
			{
				ReadData(m, n, pq, data, pathYx, pathYy);

				MatrixInv(m, n, pq, mu, data, outMatrix);

				WriteData(m, pq, outMatrix, pathRx, pathRy);
			}
			catch (Exception)
			{
				throw;
			}

			stopwatch.Stop();

			return stopwatch.Elapsed;
		}

		/// <summary>
		/// Метод, с помощью которого через потоки считывается матрица
		/// наблюдений, сгенерированная ранее. Матрица, находящаяся
		/// в двух файлах (для вещественных и мнимых компонент), 
		/// объединяется в массив комплексных чисел.
		/// </summary>
		/// <param name="m"> Параметр для размеров приемной
		/// решетки радиолокатора. </param>
		/// <param name="n"> Параметр для количества векторов
		/// наблюдений, по которым составляется корреляционная
		/// матрица. </param>
		/// <param name="pq"> Параметр числа блоков, по которым
		/// составляются наблюдения и корреляционная матрица. </param>
		/// <param name="mu"> Параметр для коэффициента
		/// регуляризации корреляционной матрицы. </param>
		/// <param name="data"> Ссылка на матрицу определенного
		/// размера, проинициализированную в основном методе класса,
		/// в которую будут записаны наблюдения, считанные из
		/// файлов. </param>
		/// <param name="pathYx"> Параметр для пути к файлу, в
		/// котором находятся вещественные компоненты матрицы
		/// наблюдений. </param>
		/// <param name="pathYy"> Параметр для пути к файлу, в
		/// котором находятся мнимые компоненты матрицы
		/// наблюдений. </param>
		static void ReadData(int m, int n, int pq, Complex[] data,
			string pathYx, string pathYy)
		{
			try
			{
				FileStream streamYx = new FileStream(pathYx, FileMode.Open);
				FileStream streamYy = new FileStream(pathYy, FileMode.Open);

				StreamReader readYx = new StreamReader(streamYx);
				StreamReader readYy = new StreamReader(streamYy);

				string[] linesYr = readYx.ReadToEnd().Split(new char[] { ' ' },
					StringSplitOptions.RemoveEmptyEntries);
				string[] linesYy = readYy.ReadToEnd().Split(new char[] { ' ' },
					StringSplitOptions.RemoveEmptyEntries);

				int it = 0;

				for (int j = 0; j < m; j++)
				{
					for (int k = 0; k < pq; k++)
					{
						for (int i = 0; i < n; i++)
						{
							data[pq * m * i + k * m + j] =
								new Complex(float.Parse(linesYr[it].Trim(' ')),
								float.Parse(linesYy[it].Trim(' ')));

							it++;
						}
					}
				}

				readYx.Dispose();
				readYy.Dispose();
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Метод, осуществляющий расчет обратной корреляционной матрицы
		/// на основе матрицы наблюдений. В том числе происходит ее 
		/// изначальное заполнение, затем расчет значений по матрице
		/// наблюдений и инверсия.
		/// </summary>
		/// /// <param name="m"> Параметр для размеров приемной
		/// решетки радиолокатора. </param>
		/// <param name="n"> Параметр для количества векторов
		/// наблюдений, по которым составляется корреляционная
		/// матрица. </param>
		/// <param name="pq"> Параметр числа блоков, по которым
		/// составляются наблюдения и корреляционная матрица. </param>
		/// <param name="mu"> Параметр для коэффициента
		/// регуляризации корреляционной матрицы. </param>
		/// <param name="data"> Ссылка на матрицу определенного
		/// размера, проинициализированную в основном методе класса,
		/// в которую будут записаны наблюдения, считанные из
		/// файлов. </param>
		/// <param name="outMatrix"> Ссылка на матрицу определенного
		/// размера, проинициализированную в основном методе класса,
		/// в которую будет записана рассчитанная корреляционная
		/// матрица. </param>
		static void MatrixInv(int m, int n, int pq, float mu,
			Complex[] data, Complex[] outMatrix)
		{
			try
			{
				float invMu = 1.0f / mu;
				float c;
				Complex[] a = new Complex[m];

				//Loop over all input matrices
				for (int k = 0; k < pq; k++)
				{
					//Intialize R0
					for (int j = 0; j < m; j++)
					{
						for (int o = 0; o < m; o++)
						{
							outMatrix[pq * m * j + k * m + o] =
								new Complex((j == o) ? invMu : 0, 0);
						}
					}

					//N iterations for matrix inversion
					for (int i = 0; i < n; i++)
					{
						c = 1.0f;

						//Calculate a = R * Y[i] matrix-vector product
						for (int j = 0; j < m; j++)
						{
							a[j] = new Complex(0, 0);

							for (int o = 0; o < m; o++)
								ComplexMAD(ref a[j], outMatrix[pq * m * j + k * m + o],
									data[pq * m * i + k * m + o]);

							//Isn't it more correct to accumulate C complex and 
							//derive absolute value only in the end?
							c += (float)(a[j].Real * data[pq * m * i + k * m + j].Real
								+ a[j].Imaginary * data[pq * m * i + k * m + j].Imaginary);
						}

						//Update R: R(n) = R(n - 1) - f(a)
						for (int j = 0; j < m; j++)
						{
							for (int o = 0; o < m; o++)
							{
								outMatrix[pq * m * j + k * m + o] -=
									new Complex((a[j].Real * a[o].Real +
									a[j].Imaginary * a[o].Imaginary) / c,
									(-a[j].Real * a[o].Imaginary +
									a[j].Imaginary * a[o].Real) / c);
							}
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Метод, выполняющий сложение первого передаваемого
		/// комплексного числа с произведением двух следующих -
		/// a += b * c.
		/// </summary>
		/// <param name="a"> Параметр изменяемого числа, к 
		/// которому прибавляется произведение двух следующих.</param>
		/// <param name="b"> Параметр для одного из чисел
		/// прибавляемого произведения. </param>
		/// <param name="c"> Параметр для другого из чисел
		/// прибавляемого произведения. </param>
		static void ComplexMAD(ref Complex a, Complex b, Complex c)
		{
			Complex t = new Complex(a.Real + b.Real * c.Real - b.Imaginary * c.Imaginary,
				a.Imaginary + b.Real * c.Imaginary + b.Imaginary * c.Real);
			a = t;
		}

		/// <summary>
		/// Метод, в котором через потоки в два файла
		/// (для вещественных и мнимых компонент) записывается
		/// рассчитанная корреляционная матрица.
		/// </summary>
		/// <param name="m"> Параметр для размеров приемной
		/// решетки радиолокатора. </param>
		/// <param name="pq"> Параметр числа блоков, по которым
		/// составляются наблюдения и корреляционная матрица. </param>
		/// <param name="outMatrix"> Ссылка на матрицу определенного
		/// размера, проинициализированную в основном методе класса,
		/// в которую будет записана рассчитанная корреляционная
		/// матрица. </param>
		/// <param name="pathRx"> Параметр для пути к файлу, в
		/// котором находятся вещественные компоненты обратной 
		/// корреляционной матрицы. </param>
		/// <param name="pathRy"> Параметр для пути к файлу, в
		/// котором находятся мнимые компоненты обратной 
		/// корреляционной матрицы. </param>
		static void WriteData(int m, int pq, Complex[] outMatrix,
			string pathRx, string pathRy)
		{
			try
			{
				FileStream streamRx = new FileStream(pathRx, FileMode.Create);
				FileStream streamRy = new FileStream(pathRy, FileMode.Create);

				StreamWriter writeRx = new StreamWriter(streamRx);
				StreamWriter writeRy = new StreamWriter(streamRy);

				for (int j = 0; j < m; j++)
				{
					for (int k = 0; k < pq; k++)
					{
						for (int i = 0; i < m; i++)
						{
							writeRx.Write(outMatrix[pq * m * j + k * m + i].Real + " ");
							writeRy.Write(outMatrix[pq * m * j + k * m + i].Imaginary + " ");
						}
					}

					writeRx.WriteLine();
					writeRy.WriteLine();
				}

				writeRx.Dispose();
				writeRy.Dispose();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}