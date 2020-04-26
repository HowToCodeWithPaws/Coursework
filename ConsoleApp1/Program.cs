using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadarLib;
using System.IO;

namespace ConsoleApp1
{
	class Program
	{
		/// <summary>
		/// Метод выводит сообщение с переданной информацией и осуществляет
		/// считывание переменной указанного типа с использованием метода 
		/// TryParse в цикле do while до тех пор, пока пользователь не введет
		/// данные, для которых осуществится парсинг, также метод принимает
		/// на вход границы значений считываемого числа, соответствие которым
		/// также проверяется внутри условия do while.
		/// </summary>
		/// <param name="message"> Входной параметр выводимого сообщения. </param>
		/// <param name="minvalue"> Входной параметр нижней границы значения 
		/// числа. </param>
		/// <param name="maxvalue"> Входной параметр верхней границы значения
		/// числа. </param>
		/// <returns>Метод возвращает считанные данные, приведенные к требуемому 
		/// типу.</returns>
		public static float ReadF(string message, float minvalue = float.MinValue, float maxvalue = float.MaxValue)
		{
			float input;

			do
			{
				Console.Write(message + ": ");
			} while (!float.TryParse(Console.ReadLine(), out input) || input < minvalue || input > maxvalue);

			return input;
		}

		/// <summary>
		/// Метод выводит сообщение с переданной информацией и осуществляет
		/// считывание переменной указанного типа с использованием метода 
		/// TryParse в цикле do while до тех пор, пока пользователь не введет
		/// данные, для которых осуществится парсинг, также метод принимает
		/// на вход границы значений считываемого числа, соответствие которым
		/// также проверяется внутри условия do while.
		/// </summary>
		/// <param name="message"> Входной параметр выводимого сообщения. </param>
		/// <param name="minvalue"> Входной параметр нижней границы значения 
		/// числа. </param>
		/// <param name="maxvalue"> Входной параметр верхней границы значения
		/// числа. </param>
		/// <returns>Метод возвращает считанные данные, приведенные к требуемому 
		/// типу.</returns>
		public static int ReadI(string message, int minvalue = int.MinValue, int maxvalue = int.MaxValue)
		{
			int input;

			do
			{
				Console.Write(message + ": ");
			} while (!int.TryParse(Console.ReadLine(), out input) || input < minvalue || input > maxvalue);

			return input;
		}

		static void Main(string[] args)
		{
			System.Globalization.CultureInfo.CurrentCulture
				= new System.Globalization.CultureInfo("en-US", false);

			//Console.WriteLine("Введите параметры\n");

			//int N = ReadI("N");
			//int Mu = ReadI("Mu");
			//int Mv = ReadI("Mv");
			//float Um = ReadF("Um");
			//float Vm = ReadF("Vm");
			//float du = ReadF("du");
			//float dv = ReadF("dv");
			//float u = ReadF("u");
			//float v = ReadF("v");
			//float a = ReadF("a");
			//float Tc = ReadF("Tc");
			//float up1 = ReadF("up1");
			//float up2 = ReadF("up2");
			//float vp1 = ReadF("vp1");
			//float vp2 = ReadF("vp2");
			//float Ap1 = ReadF("Ap1");
			//float Ap2 = ReadF("Ap2");
			//float gamma = ReadF("gamma");
			//float mu = ReadF("mu");
			//float H = ReadF("H");
			//int pq = ReadI("pq");


			//File.WriteAllLines("../../../Input.txt", new string[]
			//{ N.ToString(), Mu.ToString(), Mv.ToString(),	Um.ToString(), Vm.ToString(), 
			//	du.ToString(), dv.ToString(), u.ToString(), v.ToString(), a.ToString(),
			//	Tc.ToString(), up1.ToString(), up2.ToString(), vp1.ToString(),vp2.ToString(),
			//	Ap1.ToString(),Ap2.ToString(), gamma.ToString(), mu.ToString(), H.ToString(),
			//	pq.ToString() });

			Console.WriteLine("Input written to file. Now generating data");

			CreateFiles.MatlabFuncs class1 = new CreateFiles.MatlabFuncs();
			class1.CreateFiles(1, 64, 4, 4, 0.1666667, 0.1666667, 0.1666667, 0.1666667, 0, 0, 0.42, 20, 0.03125, -0.03125, 0, 0, 300, 300, 0, 3000);

//			Exec(@"GenerateFiles.exe");

			//Console.WriteLine("Data generated");

			//RadarOperations test = new RadarOperations(pq, mu, Mv * Mu, N);/*,
			//	"../../../Yx.txt", "../../../Yy.txt", "../../../Rx.txt", "../../../Ry.txt");*/

			//test.Start();

			//Console.WriteLine("Now visualizing");

			//Exec(@"Graphics.exe");
		}

		public static void Exec(string cmd)
		{
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = cmd;
			process.StartInfo = startInfo;
			process.Start();
			process.WaitForExit();
		}
	}
}
