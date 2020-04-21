using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RadarLib;
using System.Diagnostics;
using System.IO;

namespace Coursework
{
	public partial class Form2 : Form
	{
		Form1 prevForm;
		int pq, M, N;
		float mu;

		public Form2(Form1 form, int N, int Mu, int Mv,
			float Um, float Vm, float du, float dv,
			float u, float v, float a, float Tc,
			float up1, float up2, float vp1, float vp2, float Ap1, float Ap2,
			float gamma, float mu, float H, int pq)
		{
			this.mu = mu;
			this.pq = pq;
			this.N = N;
			M = Mu * Mv;
			prevForm = form;
			InitializeComponent();
			status.Text = "Параметры симуляции определены";
			generateData.Visible = true;
			getData.Visible = true;
			generateMatrix.Visible = false;
			generateL.Visible = false;
			visualize.Visible = false;
		}
		public void Exec(string adress)
		{
			Process process = new Process();
			process.EnableRaisingEvents = true;
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = adress;
			process.StartInfo = startInfo;
			process.Start();
			process.WaitForExit();
		}

		public async void BeginData()
		{
			try
			{
				progress.Visible = true;
				status.Text = "Начинаем генерацию наблюдений";

				await Task.Run(() => Exec(@"GenerateFiles.exe"));

				progress.Visible = false;
				status.Text += "\nНаблюдения сгенерированы";
				generateMatrix.Visible = true;
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка запуска исполняемого файла матлаб." +
					" Пожалуйста, добавьте файл в папку с исполняемым файлом винформы.");
				progress.Visible = false;
				status.Text += "\nПроиошла ошибка при генерации наблюдений";
			}
		}

		public async void BeginMatrix()
		{
			try
			{

				progress.Visible = true;
				status.Text += "\nНачинаем вычисление корреляционной матрицы";
				RadarOperations test = new RadarOperations(pq, mu, M, N);

				await Task.Run(() => test.Start());

				progress.Visible = false;
				status.Text += "\nВычисление матрицы закончено";
				generateL.Visible = true;
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка запуска процесса расчета" +
					" корреляционной матрицы. Попробуйте снова.");
				progress.Visible = false;
				status.Text += "\nПроизошла ошибка при расчете корреляционной матрицы";
			}
		}

		public async void BeginL()
		{
			try
			{
				progress.Visible = true;
				status.Text += "\nНачинаем расчет статистики наблюдений";

				await Task.Run(() => Exec(@"GetL.exe"));

				progress.Visible = false;
				status.Text += "\nРасчет статистики наблюдений закончен";
				visualize.Visible = true;
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка запуска исполняемого файла матлаб." +
					" Пожалуйста, добавьте файл в папку с исполняемым файлом винформы.");
				progress.Visible = false;
				status.Text += "\nПроиошла ошибка при расчете статистики наблюдений";
			}
		}

		public async void BeginVis()
		{
			try
			{
				progress.Visible = true;
				status.Text += "\nНачинаем визуализацию";

				await Task.Run(() => Exec(@"Graphics.exe"));

				progress.Visible = false;
				status.Text += "\nВизуализация закончена";
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка запуска исполняемого файла матлаб." +
					" Пожалуйста, добавьте файл в папку с исполняемым файлом винформы.");
				progress.Visible = false;
				status.Text += "\nПроиошла ошибка при визуализации";
			}
		}

		private void generateData_Click(object sender, EventArgs e)
		{
			BeginData();
		}

		private void generateMatrix_Click(object sender, EventArgs e)
		{
			BeginMatrix();
		}

		private void generateL_Click(object sender, EventArgs e)
		{
			BeginL();
		}

		private void visualize_Click(object sender, EventArgs e)
		{
			//	visualize.Visible = false;
			BeginVis();
		}

		private void getData_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				status.Text += "\nДобавляем файлы наблюдений";

				string pathSx, pathSy, pathUx, pathUy, pathYX, pathYY;
				pathSy = pathSx = pathUx = pathUy = pathYX = pathYY = "";

				MessageBox.Show("Вам нужно выбрать файл Sx");
				// File Sx
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathSx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Sx выбран. Теперь нужно выбрать файл Sy");
				// File Sy
				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathSy = openFileInput.FileName;
				}

				MessageBox.Show("Файл Sy выбран. Теперь нужно выбрать файл Ux");
				// File Ux
				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathUx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Ux выбран. Теперь нужно выбрать файл Uy");
				// File Uy				
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathUy = openFileInput.FileName;
				}


				MessageBox.Show("Файл Uy выбран. Теперь нужно выбрать файл YX");
				// File YX
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathYX = openFileInput.FileName;
				}

				MessageBox.Show("Файл YX выбран. Теперь нужно выбрать файл YY");
				// File YY
				if (openFileInput.ShowDialog()
					  == DialogResult.OK)
				{
					pathYY = openFileInput.FileName;
				}

				if (CheckData(pathYY) && CheckData(pathYX)
					&& CheckData(pathSx) && CheckData(pathSy)
					&& CheckData(pathUx) && CheckData(pathUy))
				{
					File.Copy(pathSx, "Sx.txt");
					File.Copy(pathSy, "Sy.txt");
					File.Copy(pathUx, "Ux.txt");
					File.Copy(pathUy, "Uy.txt");
					File.Copy(pathYX, "YX.txt");
					File.Copy(pathYY, "YY.txt");

					status.Text += "\nФайлы наблюдений добавлены";
					generateMatrix.Visible = true;
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы должны выбрать файл.");

				status.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
					"Начните заново.");
				status.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				status.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				status.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				status.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				status.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		//TODO
		private void getMatrix_Click(object sender, EventArgs e)
		{

		}

		//TODO
		private void getL_Click(object sender, EventArgs e)
		{

		}

		//TODO
		private void saveData_Click(object sender, EventArgs e)
		{

		}

		//TODO
		private void saveMatrix_Click(object sender, EventArgs e)
		{

		}

		//TODO
		private void saveL_Click(object sender, EventArgs e)
		{

		}
		
		//TODO
		public bool CheckData(string path)
		{
			return true;
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevForm.Show();
		}
	}
}
