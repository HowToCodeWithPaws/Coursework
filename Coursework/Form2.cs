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

namespace Coursework
{
	public partial class Form2 : Form
	{
		Form1 prevForm;
		int pq, M, N;
		float mu;
		bool withData;

		public Form2(Form1 form, int N, int Mu, int Mv,
			float Um, float Vm, float du, float dv,
			float u, float v, float a, float Tc,
			float up1, float up2, float vp1, float vp2, float Ap1, float Ap2,
			float gamma, float mu, float H, int pq, bool data)
		{
			this.mu = mu;
			this.pq = pq;
			this.N = N;
			M = Mu * Mv;
			prevForm = form;
			withData = data;
			InitializeComponent();
			computeMatrix.Visible = false;
			visualize.Visible = false;

			if (data)
			{
				status.Text += "\nНаблюдения сгенерированы";
				computeMatrix.Visible = true;
			}
			else
			{
				Begin();
			}
		}

		public async void Begin()
		{
			try
			{
				progress.Visible = true;
				status.Text = "Начинаем генерацию наблюдений";

				await Task.Run(() => Exec(@"GenerateFiles.exe"));

				progress.Visible = false;
				status.Text += "\nНаблюдения сгенерированы";
				computeMatrix.Visible = true;
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка запуска исполняемого файла матлаб." +
					" Пожалуйста, добавьте файл в папку с исполняемым файлом винформы.");
			}
		}
		public void Exec(string adress)
		{
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			process.EnableRaisingEvents = true;
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			//	startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = adress;
			process.StartInfo = startInfo;
			process.Start();
				process.WaitForExit();
			//process.Exited += (object sender, EventArgs e) =>
			//{
			////	button.Visible = true;
			//	firstFinished = true;
			//};

		}

		public async void BeginMatrix() {

			progress.Visible = true;
			status.Text += "\nНачинаем вычисление корреляционной матрицы";

			RadarOperations test = new RadarOperations(pq, mu, M, N);
			//	",../../../Yx.txt", "../../../Yy.txt", "../../../Rx.txt", "../../../Ry.txt");

			await Task.Run(() => test.Start());

			progress.Visible = false;
			status.Text += "\nВычисление матрицы закончено";
			getL.Visible = true;
		}
		public async void BeginVis() {
			progress.Visible = true;
			status.Text += "\nНачинаем визуализацию";

			await Task.Run(() => Exec(@"Graphics.exe"));

			progress.Visible = false;
			status.Text += "\nВизуализация закончена";
		}

		public async void BeginL()
		{
			progress.Visible = true;
			status.Text += "\nНачинаем расчет статистики наблюдений";

			await Task.Run(() => Exec(@"GetL.exe"));

			progress.Visible = false;
			status.Text += "\nРасчет статистики наблюдений закончен";
			visualize.Visible = true;
		}

		private void computeMatrix_Click(object sender, EventArgs e)
		{
			computeMatrix.Visible = false;
			BeginMatrix();
		}


		private void getL_Click(object sender, EventArgs e)
		{
			getL.Visible = false;
			BeginL();
		}

		private void visualize_Click(object sender, EventArgs e)
		{
			visualize.Visible = false;
			BeginVis();
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevForm.Show();
		}
	}
}
