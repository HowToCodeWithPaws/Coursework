﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace RadarLib
{
	public class RadarOperations
	{
		Stopwatch stopwatch = new Stopwatch();
		TimeSpan timeSpan = new TimeSpan();

		float mu;
		int m, n, pq, pqm, dataSize, outSize;

		Complex[] data, outMatrix;

		string pathYx, pathYy, pathRx, pathRy;

		public RadarOperations(int pq_, float mu_, int m_, int n_)
		{
			pq = pq_;
			mu = mu_;
			m = m_;
			n = n_;

			pathYx = "YX.txt";
			pathYy = "YY.txt";
			pathRx = "Rx.txt";
			pathRy = "Ry.txt";

			pqm = pq * m;
			dataSize = pq * n * m;
			outSize = pq * m * m;

			outMatrix = new Complex[outSize];
			data = new Complex[dataSize];
		}

		void ReadData()
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
							data[pqm * i + k * m + j] =
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

		void WriteData()
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
			catch (Exception)
			{
				throw;
			}
		}

		public string Start()
		{
			stopwatch.Start();

			try
			{
				ReadData();

				matrixInvCPU();

				WriteData();
			}
			catch (Exception)
			{
				throw;
			}

			stopwatch.Stop();

			timeSpan = stopwatch.Elapsed;

			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
			timeSpan.Milliseconds / 10);

			return elapsedTime;
		}

		void complexMAD(ref Complex a, Complex b, Complex c)
		{
			Complex t = new Complex(a.Real + b.Real * c.Real - b.Imaginary * c.Imaginary, 
				a.Imaginary + b.Real * c.Imaginary + b.Imaginary * c.Real);
			a = t;
		}

		void matrixInvCPU()
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
							outMatrix[pqm * j + k * m + o] =
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
								complexMAD(ref a[j], outMatrix[pqm * j + k * m + o],
									data[pqm * i + k * m + o]);

							//Isn't it more correct to accumulate C complex and 
							//derive absolute value only in the end?
							c += (float)(a[j].Real * data[pqm * i + k * m + j].Real 
								+ a[j].Imaginary * data[pqm * i + k * m + j].Imaginary);
						}

						//Update R: R(n) = R(n - 1) - f(a)
						for (int j = 0; j < m; j++)
						{
							for (int o = 0; o < m; o++)
							{
								outMatrix[pqm * j + k * m + o] -= 
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
	}
}