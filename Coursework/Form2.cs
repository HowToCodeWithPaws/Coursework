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

		public Form2(Form1 form, int N, int Mu, int Mv, float mu, int pq)
		{
			this.mu = mu;
			this.pq = pq;
			this.N = N;
			M = Mu * Mv;
			prevForm = form;
			InitializeComponent();
			log.Text = "Параметры симуляции определены";
			generateData.Visible = true;
			getData.Visible = true;
			saveData.Visible = false;
			generateMatrix.Visible = false;
			getMatrix.Visible = true;
			saveMatrix.Visible = false;
			generateL.Visible = false;
			getL.Visible = true;
			saveL.Visible = false;
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
				Disable();
				progress.Visible = true;
				log.Text += "\nНачинаем генерацию наблюдений";

				await Task.Run(() => Exec(@"GenerateFiles.exe"));

				progress.Visible = false;
				log.Text += "\nНаблюдения сгенерированы";
				saveData.Visible = true;
				generateMatrix.Visible = true;
				getMatrix.Visible = true;
				Enable();
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка запуска исполняемого файла матлаб." +
					" Пожалуйста, добавьте файл в папку с исполняемым файлом винформы.");
				progress.Visible = false;
				log.Text += "\nПроиошла ошибка при генерации наблюдений";
			}
		}

		public async void BeginMatrix()
		{
			try
			{
				Disable();
				progress.Visible = true;
				log.Text += "\nНачинаем вычисление корреляционной матрицы";
				RadarOperations test = new RadarOperations(pq, mu, M, N);

				await Task.Run(() => test.Start());

				progress.Visible = false;
				log.Text += "\nВычисление матрицы закончено";
				saveMatrix.Visible = true;
				generateL.Visible = true;
				getL.Visible = true;
				Enable();
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка запуска процесса расчета" +
					" корреляционной матрицы. Попробуйте снова.");
				progress.Visible = false;
				log.Text += "\nПроизошла ошибка при расчете корреляционной матрицы";
			}
		}

		public async void BeginL()
		{
			try
			{
				Disable();
				progress.Visible = true;
				log.Text += "\nНачинаем расчет статистики наблюдений";

				await Task.Run(() => Exec(@"GetL.exe"));

				progress.Visible = false;
				log.Text += "\nРасчет статистики наблюдений закончен";
				saveL.Visible = true;
				visualize.Visible = true;
				Enable();
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка запуска исполняемого файла матлаб." +
					" Пожалуйста, добавьте файл в папку с исполняемым файлом винформы.");
				progress.Visible = false;
				log.Text += "\nПроиошла ошибка при расчете статистики наблюдений";
			}
		}

		public async void BeginVis()
		{
			try
			{
				Disable();
				progress.Visible = true;
				log.Text += "\nНачинаем визуализацию";

				await Task.Run(() => Exec(@"Graphics.exe"));

				progress.Visible = false;
				log.Text += "\nВизуализация закончена";
				Enable();
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка запуска исполняемого файла матлаб." +
					" Пожалуйста, добавьте файл в папку с исполняемым файлом винформы.");
				progress.Visible = false;
				log.Text += "\nПроиошла ошибка при визуализации";
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
				log.Text += "\nДобавляем файлы наблюдений";

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
					File.Copy(pathSx, "Sx.txt", true);
					File.Copy(pathSy, "Sy.txt", true);
					File.Copy(pathUx, "Ux.txt", true);
					File.Copy(pathUy, "Uy.txt", true);
					File.Copy(pathYX, "YX.txt", true);
					File.Copy(pathYY, "YY.txt", true);

					log.Text += "\nФайлы наблюдений добавлены";
					generateMatrix.Visible = true;
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы должны выбрать файл.");

				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		private void getMatrix_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				log.Text += "\nДобавляем файлы матрицы";

				string pathRx, pathRy;
				pathRy = pathRx = "";

				MessageBox.Show("Вам нужно выбрать файл Rx");
				// File Rx
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathRx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Rx выбран. Теперь нужно выбрать файл Ry");
				// File Ry
				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathRy = openFileInput.FileName;
				}

				if (CheckData(pathRx) && CheckData(pathRy))
				{
					File.Copy(pathRx, "Rx.txt", true);
					File.Copy(pathRy, "Ry.txt", true);

					log.Text += "\nФайлы матрицы добавлены";
					generateL.Visible = true;
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы должны выбрать файл.");

				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		private void getL_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				log.Text += "\nДобавляем файл статистики";

				string pathL; ;
				pathL = "";

				MessageBox.Show("Вам нужно выбрать файл L");
				// File L
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathL = openFileInput.FileName;
				}

				if (CheckData(pathL))
				{
					File.Copy(pathL, "Lfile.txt", true);

					log.Text += "\nФайл статистики добавлен";
					visualize.Visible = true;
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы должны выбрать файл.");

				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				log.Text += "\nПроизошла ошибка добавления файлов.";
			}
		}

		private void saveData_Click(object sender, EventArgs e)
		{/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				log.Text += "\nСохраняем файлы наблюдений";

				string pathSx, pathSy, pathUx, pathUy, pathYX, pathYY;
				pathSy = pathSx = pathUx = pathUy = pathYX = pathYY = "";

				MessageBox.Show("Вам нужно выбрать, куда сохранить файл Sx");
				// File Sx
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathSx = openFileInput.FileName;
				}

				MessageBox.Show("Путь для файла Sx выбран. Теперь нужно выбрать, куда сохранить файл Sy");
				// File Sy
				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathSy = openFileInput.FileName;
				}

				MessageBox.Show("Путь для файла Sy выбран. Теперь нужно выбрать, куда сохранить файл Ux");
				// File Ux
				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathUx = openFileInput.FileName;
				}

				MessageBox.Show("Путь для файла Ux выбран. Теперь нужно выбрать, куда сохранить файл Uy");
				// File Uy				
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathUy = openFileInput.FileName;
				}


				MessageBox.Show("Путь для файла Uy выбран. Теперь нужно выбрать, куда сохранить файл YX");
				// File YX
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathYX = openFileInput.FileName;
				}

				MessageBox.Show("Путь для файла YX выбран. Теперь нужно выбрать, куда сохранить файл YY");
				// File YY
				if (openFileInput.ShowDialog()
					  == DialogResult.OK)
				{
					pathYY = openFileInput.FileName;
				}

				File.Copy("Sx.txt", pathSx, true);
				File.Copy("Sy.txt", pathSy, true);
				File.Copy("Ux.txt", pathUx, true);
				File.Copy("Uy.txt", pathUy, true);
				File.Copy("YX.txt", pathYX, true);
				File.Copy("YY.txt", pathYY, true);

				log.Text += "\nФайлы наблюдений сохранены";
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы должны выбрать файл.");

				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
		}

		private void saveMatrix_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				log.Text += "\nСохраняем файлы матрицы";

				string pathRx, pathRy;
				pathRy = pathRx = "";

				MessageBox.Show("Вам нужно выбрать, куда сохранить файл Rx");
				// File Rx
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathRx = openFileInput.FileName;
				}

				MessageBox.Show("Файл Rx выбран. Теперь нужно выбрать, куда сохранить файл Ry");
				// File Ry
				if (openFileInput.ShowDialog()
						== DialogResult.OK)
				{
					pathRy = openFileInput.FileName;
				}

				File.Copy("Rx.txt", pathRx, true);
				File.Copy("Ry.txt", pathRy, true);

				log.Text += "\nФайлы матрицы сохранены";
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы должны выбрать файл.");

				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
		}

		private void saveL_Click(object sender, EventArgs e)
		{
			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				log.Text += "\nСохраняем файл статистики";

				string pathL; ;
				pathL = "";

				MessageBox.Show("Вам нужно выбрать, куда сохранить файл L");
				// File L
				if (openFileInput.ShowDialog()
					   == DialogResult.OK)
				{
					pathL = openFileInput.FileName;
				}

				if (CheckData(pathL))
				{
					File.Copy("Lfile.txt",pathL,  true);

					log.Text += "\nФайл статистики сохранен";
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Вы должны выбрать файл.");

				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Файл не существует, " +
					"добавьте его в папку с решением. " +
					"Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (IOException)
			{
				MessageBox.Show("Ошибка в работе с файлом." +
					" Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("Ошибка доступа к файлу:" +
					" нет разрешения на доступ. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (System.Security.SecurityException)
			{
				MessageBox.Show("Ошибка безопасности при " +
				"работе с файлом. Начните заново.");
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				log.Text += "\nПроизошла ошибка сохранения файлов.";
			}
		}

		//TODO
		public bool CheckData(string path)
		{
			return true;
		}

		static private List<Control> GetAllControlsOfType<T>(Control container)
		{
			List<Control> controlList = new List<Control>();
			foreach (Control c in container.Controls)
			{
				controlList.AddRange(GetAllControlsOfType<T>(c));
				if (c is T)
				{
					controlList.Add(c);
				}
			}
			return controlList;
		}

		void Enable()
		{
			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.Enabled = true;
			}
		}

		void Disable()
		{
			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.Enabled = false;
			}
		}

		private void formBack_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			prevForm.Show();
		}

	}
}
