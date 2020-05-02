using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Coursework
{
	/// <summary>
	/// Форма с начальным экраном приложения,
	/// на ней отображается информация о программе,
	/// авторе, и с нее можно перейти к работе с
	/// наблюдениями.
	/// </summary>
	public partial class Homescreen : Form
	{
		/// <summary>
		/// Экземпляр класса функций библиотеки с 
		/// функциями матлаб, создается в самом начале
		/// работы, чтобы размер формы не перерасчитывался
		/// в дальнейшем из-за форматирования.
		/// </summary>
		MatlabFuncs.Funcs funcs = new MatlabFuncs.Funcs();

		/// <summary>
		/// Поля для цветов, которые определяют внешний 
		/// вид формы.
		/// </summary>
		Color backColor = Color.FromArgb(46, 76, 86);
		Color panelColor = Color.FromArgb(89, 139, 155);
		Color hoverColor = Color.FromArgb(125, 167, 181);
		Color textColor = Color.FromArgb(160, 238, 230);

		/// <summary>
		/// Конструктор формы, в котором инициализируются
		/// компоненты формы и задается из внешний вид.
		/// </summary>
		public Homescreen()
		{
			InitializeComponent();
			this.BackColor = backColor;
			panel1.BackColor = panelColor;

			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.FlatAppearance.MouseOverBackColor = hoverColor;
				b.ForeColor = textColor;
			}

			foreach (Label l in GetAllControlsOfType<Label>(this))
			{
				l.ForeColor = textColor;
			}

			name.Visible = author.Visible = true;
			info.Visible = false;
		}

		/// <summary>
		/// Обработчик нажатия на кнопку перехода к 
		/// главному экрану, на котором отображается название
		/// приложения и информация об авторе.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bMain_Click(object sender, EventArgs e)
		{
			name.Visible = author.Visible = true;
			info.Visible = false;
		}

		/// <summary>
		/// Обработчик нажатия на кнопку перехода к информации,
		/// делает видимым текст, поясняющий работу данного
		/// приложения, и невидимым остальной текст.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bInfo_Click(object sender, EventArgs e)
		{
			name.Visible = author.Visible = false;
			info.Visible = true;
		}

		/// <summary>
		/// Обработчик нажатия на кнопку перехода к работе,
		/// скрывает эту форму и открывает форму для 
		/// задания параметров симуляции на основе этой формы.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bProceed_Click(object sender, EventArgs e)
		{
			this.Hide();
			new Input(this, funcs).Show();
		}

		/// <summary>
		/// Обработчик нажатия на кнопку выхода, закрывает 
		/// данную форму и приложение.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bExit_Click(object sender, EventArgs e)
		{
			this.Close();
			Application.Exit();
		}

		/// <summary>
		/// Метод, позволяющий получить все элементы
		/// определенного типа на форме для их 
		/// более удобной настройки.
		/// </summary>
		/// <typeparam name="T"> Параметр для типа
		/// желаемых элементов. </typeparam>
		/// <param name="container"> Параметр для
		/// контейнера, на котором требуется найти
		/// элементы желаемого типа. </param>
		/// <returns> Возвращает список элементов
		/// контроля желаемого типа. </returns>
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
	}
}
