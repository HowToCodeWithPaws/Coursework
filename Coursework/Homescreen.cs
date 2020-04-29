using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
	public partial class Homescreen : Form
	{
		MatlabFuncs.Funcs funcs = new MatlabFuncs.Funcs();

		Color backColor = Color.FromArgb(46, 76, 86);
		Color panelColor = Color.FromArgb(89, 139, 155);
		Color hoverColor = Color.FromArgb(125, 167, 181);
		Color textColor = Color.FromArgb(160, 238, 230);

		public Homescreen()
		{
			InitializeComponent();
			this.BackColor = backColor;
			panel1.BackColor = panelColor;

			foreach (Button b in GetAllControlsOfType<Button>(this))
			{
				b.FlatAppearance.MouseOverBackColor = hoverColor;
				b.ForeColor = textColor;
				//		b.FlatAppearance.MouseDownBackColor = Color.FromArgb(68, 138, 162);
			}

			foreach (Label l in GetAllControlsOfType<Label>(this))
			{
				l.ForeColor = textColor;
			}

			name.Visible = author.Visible = true;
			info.Visible = false;
		}

		private void bExit_Click(object sender, EventArgs e)
		{
			this.Close();
			Application.Exit();
		}

		private void bProceed_Click(object sender, EventArgs e)
		{
			this.Hide();
			new Input(this, funcs).Show();
		}

		private void bInfo_Click(object sender, EventArgs e)
		{
			name.Visible = author.Visible = false;
			info.Visible = true;
		}

		private void bMain_Click(object sender, EventArgs e)
		{
			name.Visible = author.Visible = true;
			info.Visible = false;
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
	}
}
