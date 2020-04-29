namespace Coursework
{
	partial class Homescreen
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homescreen));
			this.bExit = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.bMain = new System.Windows.Forms.Button();
			this.bInfo = new System.Windows.Forms.Button();
			this.bProceed = new System.Windows.Forms.Button();
			this.name = new System.Windows.Forms.Label();
			this.author = new System.Windows.Forms.Label();
			this.info = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bExit
			// 
			this.bExit.BackColor = System.Drawing.Color.Transparent;
			this.bExit.FlatAppearance.BorderSize = 0;
			this.bExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bExit.Location = new System.Drawing.Point(0, 600);
			this.bExit.Margin = new System.Windows.Forms.Padding(0);
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(300, 200);
			this.bExit.TabIndex = 1;
			this.bExit.Text = "Выйти";
			this.bExit.UseVisualStyleBackColor = false;
			this.bExit.Click += new System.EventHandler(this.bExit_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel1.Controls.Add(this.bMain);
			this.panel1.Controls.Add(this.bInfo);
			this.panel1.Controls.Add(this.bProceed);
			this.panel1.Controls.Add(this.bExit);
			this.panel1.Location = new System.Drawing.Point(1060, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(300, 800);
			this.panel1.TabIndex = 0;
			// 
			// bMain
			// 
			this.bMain.BackColor = System.Drawing.Color.Transparent;
			this.bMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bMain.FlatAppearance.BorderSize = 0;
			this.bMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bMain.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bMain.Location = new System.Drawing.Point(0, 0);
			this.bMain.Margin = new System.Windows.Forms.Padding(0);
			this.bMain.Name = "bMain";
			this.bMain.Size = new System.Drawing.Size(300, 200);
			this.bMain.TabIndex = 4;
			this.bMain.Text = "Главная страница";
			this.bMain.UseVisualStyleBackColor = false;
			this.bMain.Click += new System.EventHandler(this.bMain_Click);
			// 
			// bInfo
			// 
			this.bInfo.BackColor = System.Drawing.Color.Transparent;
			this.bInfo.FlatAppearance.BorderSize = 0;
			this.bInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bInfo.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bInfo.Location = new System.Drawing.Point(0, 200);
			this.bInfo.Margin = new System.Windows.Forms.Padding(0);
			this.bInfo.Name = "bInfo";
			this.bInfo.Size = new System.Drawing.Size(300, 200);
			this.bInfo.TabIndex = 3;
			this.bInfo.Text = "Информация о программе";
			this.bInfo.UseVisualStyleBackColor = false;
			this.bInfo.Click += new System.EventHandler(this.bInfo_Click);
			// 
			// bProceed
			// 
			this.bProceed.BackColor = System.Drawing.Color.Transparent;
			this.bProceed.FlatAppearance.BorderSize = 0;
			this.bProceed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bProceed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bProceed.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bProceed.Location = new System.Drawing.Point(0, 391);
			this.bProceed.Margin = new System.Windows.Forms.Padding(0);
			this.bProceed.Name = "bProceed";
			this.bProceed.Size = new System.Drawing.Size(300, 200);
			this.bProceed.TabIndex = 2;
			this.bProceed.Text = "Перейти к работе";
			this.bProceed.UseVisualStyleBackColor = false;
			this.bProceed.Click += new System.EventHandler(this.bProceed_Click);
			// 
			// name
			// 
			this.name.Font = new System.Drawing.Font("Century Gothic", 20F);
			this.name.Location = new System.Drawing.Point(12, 50);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(812, 232);
			this.name.TabIndex = 1;
			this.name.Text = "Программа симуляции и визуализации работы радиолокатора";
			// 
			// author
			// 
			this.author.Font = new System.Drawing.Font("Century Gothic", 15F);
			this.author.Location = new System.Drawing.Point(14, 672);
			this.author.Name = "author";
			this.author.Size = new System.Drawing.Size(434, 128);
			this.author.TabIndex = 2;
			this.author.Text = "Зубарева Наталия\r\nСтудентка группы БПИ-199\r\nndzubareva@edu.hse.ru";
			// 
			// info
			// 
			this.info.Font = new System.Drawing.Font("Century Gothic", 15F);
			this.info.Location = new System.Drawing.Point(14, 60);
			this.info.Name = "info";
			this.info.Size = new System.Drawing.Size(1036, 720);
			this.info.TabIndex = 3;
			this.info.Text = resources.GetString("info.Text");
			// 
			// Homescreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.SlateGray;
			this.ClientSize = new System.Drawing.Size(1360, 800);
			this.Controls.Add(this.info);
			this.Controls.Add(this.author);
			this.Controls.Add(this.name);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Homescreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Beginning";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button bExit;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button bInfo;
		private System.Windows.Forms.Button bProceed;
		private System.Windows.Forms.Label name;
		private System.Windows.Forms.Label author;
		private System.Windows.Forms.Button bMain;
		private System.Windows.Forms.Label info;
	}
}