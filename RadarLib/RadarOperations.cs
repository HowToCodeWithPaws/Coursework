using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace RadarLib
{
	public class RadarOperations
	{
		float mu;
		int m, n, pq, pqm, dataSize, outSize;

		Complex[] data, outMatrix;

		string pathYx, pathYy, pathRx, pathRy;

		public RadarOperations(int pq_, float mu_, int m_, int n_
			/*,string pathYx_, string pathYy_,
		/*	string pathRx_, string pathRy_*/)
		{
			pq = pq_;
			mu = mu_;
			m = m_;
			n = n_;

			pathYx = "YX.txt";//pathYx_;
			pathYy = "YY.txt";//pathYy_;
			pathRx = "Rx.txt";//pathRx_;
			pathRy = "Ry.txt";//pathRy_;
		}

		void ReadData()
		{
			FileStream streamYx = new FileStream(pathYx, FileMode.Open);
			FileStream streamYy = new FileStream(pathYy, FileMode.Open);

			StreamReader readYx = new StreamReader(streamYx);
			StreamReader readYy = new StreamReader(streamYy);

			Console.WriteLine("Reading input data from file...\n");

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
						data[pqm * i + k * m + j] = new Complex(float.Parse(linesYr[it].Trim(' ')), 
							float.Parse(linesYy[it].Trim(' ')));

						it++;
					}
				}
			}

			readYx.Dispose();
			readYy.Dispose();
		}

		void WriteData()
		{
			FileStream streamRx = new FileStream(pathRx, FileMode.Create);
			FileStream streamRy = new FileStream(pathRy, FileMode.Create);

			StreamWriter writeRx = new StreamWriter(streamRx);
			StreamWriter writeRy = new StreamWriter(streamRy);

			Console.WriteLine("Dumping out the results...\n");

			for (int j = 0; j < m; j++)
			{
				for (int k = 0; k < pq; k++)
				{
					for (int i = 0; i < m; i++)
					{
						writeRx.Write(outMatrix[pqm * j + k * m + i].Real + " ");
						writeRy.Write(outMatrix[pqm * j + k * m + i].Imaginary + " ");
					}
				}

				writeRx.WriteLine();
				writeRy.WriteLine();
			}

			writeRx.Dispose();
			writeRy.Dispose();
		}

		public void Start()
		{
			pqm = pq * m;
			dataSize = pq * n * m;
			outSize = pq * m * m;

			outMatrix = new Complex[outSize];
			data = new Complex[dataSize];


			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				ReadData();

				matrixInvCPU();

				WriteData();
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("Файл не существует" + Environment.NewLine + e);
			}
			catch (IOException e)
			{
				Console.WriteLine("Ошибка ввода/вывода" + Environment.NewLine + e);
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла" + Environment.NewLine + e);
			}
			catch (System.Security.SecurityException e)
			{
				Console.WriteLine("Ошибка безопасности" + Environment.NewLine + e);
			}

			Console.WriteLine("Matrix computed.\n");
		}

		void complexMAD(ref Complex a, Complex b, Complex c)
		{
			Complex t = new Complex(a.Real + b.Real * c.Real - b.Imaginary * c.Imaginary, a.Imaginary + b.Real * c.Imaginary + b.Imaginary * c.Real);
			a = t;
		}

		void matrixInvCPU()
		{
			Console.WriteLine("Computing the matrix...");

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
						outMatrix[pqm * j + k * m + o] = new Complex((j == o) ? invMu : 0, 0);
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
							complexMAD(ref a[j], outMatrix[pqm * j + k * m + o], data[pqm * i + k * m + o]);

						//Isn't it more correct to accumulate C complex and 
						//derive absolute value only in the end?
						c += (float)(a[j].Real * data[pqm * i + k * m + j].Real + a[j].Imaginary * data[pqm * i + k * m + j].Imaginary);
					}

					//Update R: R(n) = R(n - 1) - f(a)
					for (int j = 0; j < m; j++)
					{
						for (int o = 0; o < m; o++)
						{
							outMatrix[pqm * j + k * m + o] -= new Complex((a[j].Real * a[o].Real + a[j].Imaginary * a[o].Imaginary) / c, (-a[j].Real * a[o].Imaginary + a[j].Imaginary * a[o].Real) / c);
						}
					}
				}
			}
		}
	}
}