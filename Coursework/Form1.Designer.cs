namespace Coursework
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.inputUpload = new System.Windows.Forms.Button();
			this.inputDownload = new System.Windows.Forms.Button();
			this.InN = new System.Windows.Forms.TextBox();
			this.lN = new System.Windows.Forms.Label();
			this.lMv = new System.Windows.Forms.Label();
			this.lMu = new System.Windows.Forms.Label();
			this.lUm = new System.Windows.Forms.Label();
			this.lVm = new System.Windows.Forms.Label();
			this.ldu = new System.Windows.Forms.Label();
			this.ldv = new System.Windows.Forms.Label();
			this.lu = new System.Windows.Forms.Label();
			this.lv = new System.Windows.Forms.Label();
			this.la = new System.Windows.Forms.Label();
			this.lTc = new System.Windows.Forms.Label();
			this.lup1 = new System.Windows.Forms.Label();
			this.lup2 = new System.Windows.Forms.Label();
			this.lvp1 = new System.Windows.Forms.Label();
			this.lvp2 = new System.Windows.Forms.Label();
			this.lAp1 = new System.Windows.Forms.Label();
			this.lAp2 = new System.Windows.Forms.Label();
			this.lgamma = new System.Windows.Forms.Label();
			this.l_mu = new System.Windows.Forms.Label();
			this.lH = new System.Windows.Forms.Label();
			this.InMu = new System.Windows.Forms.TextBox();
			this.InMv = new System.Windows.Forms.TextBox();
			this.InUm = new System.Windows.Forms.TextBox();
			this.InVm = new System.Windows.Forms.TextBox();
			this.Indu = new System.Windows.Forms.TextBox();
			this.Indv = new System.Windows.Forms.TextBox();
			this.Inu = new System.Windows.Forms.TextBox();
			this.Inv = new System.Windows.Forms.TextBox();
			this.Ina = new System.Windows.Forms.TextBox();
			this.lpq = new System.Windows.Forms.Label();
			this.InTc = new System.Windows.Forms.TextBox();
			this.Inup1 = new System.Windows.Forms.TextBox();
			this.Inup2 = new System.Windows.Forms.TextBox();
			this.Invp1 = new System.Windows.Forms.TextBox();
			this.Invp2 = new System.Windows.Forms.TextBox();
			this.InAp1 = new System.Windows.Forms.TextBox();
			this.InAp2 = new System.Windows.Forms.TextBox();
			this.Ingamma = new System.Windows.Forms.TextBox();
			this.In_mu = new System.Windows.Forms.TextBox();
			this.InH = new System.Windows.Forms.TextBox();
			this.Inpq = new System.Windows.Forms.TextBox();
			this.toolTipTc = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipMu = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipMv = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipN = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipPq = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipGamma = new System.Windows.Forms.ToolTip(this.components);
			this.toolTip_Mu = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipUm = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipVm = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipDu = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipDv = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipU = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipV = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipA = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipH = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipUp1 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipUp2 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipVp1 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipVp2 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipAp1 = new System.Windows.Forms.ToolTip(this.components);
			this.toolTipAp2 = new System.Windows.Forms.ToolTip(this.components);
			this.proceed = new System.Windows.Forms.Button();
			this.openFileInput = new System.Windows.Forms.OpenFileDialog();
			this.saveFileInput = new System.Windows.Forms.SaveFileDialog();
			this.info = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// inputUpload
			// 
			this.inputUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.inputUpload.Location = new System.Drawing.Point(380, 25);
			this.inputUpload.Name = "inputUpload";
			this.inputUpload.Size = new System.Drawing.Size(200, 85);
			this.inputUpload.TabIndex = 0;
			this.inputUpload.Text = "Загрузить параметры симуляции из файла";
			this.inputUpload.UseVisualStyleBackColor = true;
			this.inputUpload.Click += new System.EventHandler(this.inputUpload_Click);
			// 
			// inputDownload
			// 
			this.inputDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.inputDownload.Location = new System.Drawing.Point(700, 25);
			this.inputDownload.Name = "inputDownload";
			this.inputDownload.Size = new System.Drawing.Size(200, 85);
			this.inputDownload.TabIndex = 8;
			this.inputDownload.Text = "Сохранить параметры симуляции в файл";
			this.inputDownload.UseVisualStyleBackColor = true;
			this.inputDownload.Click += new System.EventHandler(this.inputDownload_Click);
			// 
			// InN
			// 
			this.InN.Location = new System.Drawing.Point(60, 360);
			this.InN.Name = "InN";
			this.InN.Size = new System.Drawing.Size(100, 26);
			this.InN.TabIndex = 9;
			this.InN.Leave += new System.EventHandler(this.InN_Leave);
			// 
			// lN
			// 
			this.lN.Location = new System.Drawing.Point(170, 360);
			this.lN.Name = "lN";
			this.lN.Size = new System.Drawing.Size(200, 100);
			this.lN.TabIndex = 10;
			this.lN.Text = "N";
			// 
			// lMv
			// 
			this.lMv.BackColor = System.Drawing.Color.Transparent;
			this.lMv.Location = new System.Drawing.Point(170, 255);
			this.lMv.Name = "lMv";
			this.lMv.Size = new System.Drawing.Size(200, 100);
			this.lMv.TabIndex = 11;
			this.lMv.Text = "Mv";
			// 
			// lMu
			// 
			this.lMu.BackColor = System.Drawing.Color.Transparent;
			this.lMu.Location = new System.Drawing.Point(170, 150);
			this.lMu.Name = "lMu";
			this.lMu.Size = new System.Drawing.Size(200, 100);
			this.lMu.TabIndex = 12;
			this.lMu.Text = "Mu";
			// 
			// lUm
			// 
			this.lUm.Location = new System.Drawing.Point(490, 150);
			this.lUm.Name = "lUm";
			this.lUm.Size = new System.Drawing.Size(200, 100);
			this.lUm.TabIndex = 13;
			this.lUm.Text = "Um";
			// 
			// lVm
			// 
			this.lVm.Location = new System.Drawing.Point(490, 255);
			this.lVm.Name = "lVm";
			this.lVm.Size = new System.Drawing.Size(200, 100);
			this.lVm.TabIndex = 14;
			this.lVm.Text = "Vm";
			// 
			// ldu
			// 
			this.ldu.Location = new System.Drawing.Point(490, 360);
			this.ldu.Name = "ldu";
			this.ldu.Size = new System.Drawing.Size(200, 100);
			this.ldu.TabIndex = 15;
			this.ldu.Text = "du";
			// 
			// ldv
			// 
			this.ldv.Location = new System.Drawing.Point(490, 465);
			this.ldv.Name = "ldv";
			this.ldv.Size = new System.Drawing.Size(200, 100);
			this.ldv.TabIndex = 16;
			this.ldv.Text = "dv";
			// 
			// lu
			// 
			this.lu.Location = new System.Drawing.Point(810, 150);
			this.lu.Name = "lu";
			this.lu.Size = new System.Drawing.Size(200, 100);
			this.lu.TabIndex = 17;
			this.lu.Text = "u";
			// 
			// lv
			// 
			this.lv.Location = new System.Drawing.Point(810, 255);
			this.lv.Name = "lv";
			this.lv.Size = new System.Drawing.Size(200, 100);
			this.lv.TabIndex = 18;
			this.lv.Text = "v";
			// 
			// la
			// 
			this.la.Location = new System.Drawing.Point(810, 360);
			this.la.Name = "la";
			this.la.Size = new System.Drawing.Size(200, 100);
			this.la.TabIndex = 19;
			this.la.Text = "a";
			// 
			// lTc
			// 
			this.lTc.Location = new System.Drawing.Point(810, 465);
			this.lTc.Name = "lTc";
			this.lTc.Size = new System.Drawing.Size(200, 100);
			this.lTc.TabIndex = 20;
			this.lTc.Text = "Tc";
			// 
			// lup1
			// 
			this.lup1.Location = new System.Drawing.Point(1130, 150);
			this.lup1.Name = "lup1";
			this.lup1.Size = new System.Drawing.Size(200, 100);
			this.lup1.TabIndex = 21;
			this.lup1.Text = "up1";
			// 
			// lup2
			// 
			this.lup2.Location = new System.Drawing.Point(1130, 255);
			this.lup2.Name = "lup2";
			this.lup2.Size = new System.Drawing.Size(200, 100);
			this.lup2.TabIndex = 22;
			this.lup2.Text = "up2";
			// 
			// lvp1
			// 
			this.lvp1.Location = new System.Drawing.Point(1130, 360);
			this.lvp1.Name = "lvp1";
			this.lvp1.Size = new System.Drawing.Size(200, 100);
			this.lvp1.TabIndex = 23;
			this.lvp1.Text = "vp1";
			// 
			// lvp2
			// 
			this.lvp2.Location = new System.Drawing.Point(1130, 465);
			this.lvp2.Name = "lvp2";
			this.lvp2.Size = new System.Drawing.Size(200, 100);
			this.lvp2.TabIndex = 24;
			this.lvp2.Text = "vp2";
			// 
			// lAp1
			// 
			this.lAp1.Location = new System.Drawing.Point(1130, 570);
			this.lAp1.Name = "lAp1";
			this.lAp1.Size = new System.Drawing.Size(200, 100);
			this.lAp1.TabIndex = 25;
			this.lAp1.Text = "Ap1";
			// 
			// lAp2
			// 
			this.lAp2.Location = new System.Drawing.Point(1130, 675);
			this.lAp2.Name = "lAp2";
			this.lAp2.Size = new System.Drawing.Size(200, 100);
			this.lAp2.TabIndex = 26;
			this.lAp2.Text = "Ap2";
			// 
			// lgamma
			// 
			this.lgamma.Location = new System.Drawing.Point(170, 570);
			this.lgamma.Name = "lgamma";
			this.lgamma.Size = new System.Drawing.Size(200, 100);
			this.lgamma.TabIndex = 27;
			this.lgamma.Text = "gamma";
			// 
			// l_mu
			// 
			this.l_mu.Location = new System.Drawing.Point(170, 675);
			this.l_mu.Name = "l_mu";
			this.l_mu.Size = new System.Drawing.Size(200, 100);
			this.l_mu.TabIndex = 28;
			this.l_mu.Text = "mu";
			// 
			// lH
			// 
			this.lH.Location = new System.Drawing.Point(810, 570);
			this.lH.Name = "lH";
			this.lH.Size = new System.Drawing.Size(200, 100);
			this.lH.TabIndex = 29;
			this.lH.Text = "H";
			// 
			// InMu
			// 
			this.InMu.Location = new System.Drawing.Point(60, 150);
			this.InMu.Name = "InMu";
			this.InMu.Size = new System.Drawing.Size(100, 26);
			this.InMu.TabIndex = 30;
			this.InMu.Leave += new System.EventHandler(this.InMu_Leave);
			// 
			// InMv
			// 
			this.InMv.Location = new System.Drawing.Point(60, 255);
			this.InMv.Name = "InMv";
			this.InMv.Size = new System.Drawing.Size(100, 26);
			this.InMv.TabIndex = 31;
			this.InMv.Leave += new System.EventHandler(this.InMv_Leave);
			// 
			// InUm
			// 
			this.InUm.Location = new System.Drawing.Point(380, 150);
			this.InUm.Name = "InUm";
			this.InUm.Size = new System.Drawing.Size(100, 26);
			this.InUm.TabIndex = 32;
			this.InUm.Leave += new System.EventHandler(this.InUm_Leave);
			// 
			// InVm
			// 
			this.InVm.Location = new System.Drawing.Point(380, 255);
			this.InVm.Name = "InVm";
			this.InVm.Size = new System.Drawing.Size(100, 26);
			this.InVm.TabIndex = 33;
			this.InVm.Leave += new System.EventHandler(this.InVm_Leave);
			// 
			// Indu
			// 
			this.Indu.Location = new System.Drawing.Point(380, 360);
			this.Indu.Name = "Indu";
			this.Indu.Size = new System.Drawing.Size(100, 26);
			this.Indu.TabIndex = 34;
			this.Indu.Leave += new System.EventHandler(this.Indu_Leave);
			// 
			// Indv
			// 
			this.Indv.Location = new System.Drawing.Point(380, 465);
			this.Indv.Name = "Indv";
			this.Indv.Size = new System.Drawing.Size(100, 26);
			this.Indv.TabIndex = 35;
			this.Indv.Leave += new System.EventHandler(this.Indv_Leave);
			// 
			// Inu
			// 
			this.Inu.Location = new System.Drawing.Point(700, 150);
			this.Inu.Name = "Inu";
			this.Inu.Size = new System.Drawing.Size(100, 26);
			this.Inu.TabIndex = 36;
			this.Inu.Leave += new System.EventHandler(this.Inu_Leave);
			// 
			// Inv
			// 
			this.Inv.Location = new System.Drawing.Point(700, 255);
			this.Inv.Name = "Inv";
			this.Inv.Size = new System.Drawing.Size(100, 26);
			this.Inv.TabIndex = 37;
			this.Inv.Leave += new System.EventHandler(this.Inv_Leave);
			// 
			// Ina
			// 
			this.Ina.Location = new System.Drawing.Point(700, 360);
			this.Ina.Name = "Ina";
			this.Ina.Size = new System.Drawing.Size(100, 26);
			this.Ina.TabIndex = 38;
			this.Ina.Leave += new System.EventHandler(this.Ina_Leave);
			// 
			// lpq
			// 
			this.lpq.Location = new System.Drawing.Point(170, 465);
			this.lpq.Name = "lpq";
			this.lpq.Size = new System.Drawing.Size(200, 100);
			this.lpq.TabIndex = 39;
			this.lpq.Text = "pq";
			// 
			// InTc
			// 
			this.InTc.Location = new System.Drawing.Point(700, 465);
			this.InTc.Name = "InTc";
			this.InTc.Size = new System.Drawing.Size(100, 26);
			this.InTc.TabIndex = 40;
			this.InTc.Leave += new System.EventHandler(this.InTc_Leave);
			// 
			// Inup1
			// 
			this.Inup1.Location = new System.Drawing.Point(1020, 150);
			this.Inup1.Name = "Inup1";
			this.Inup1.Size = new System.Drawing.Size(100, 26);
			this.Inup1.TabIndex = 41;
			this.Inup1.Leave += new System.EventHandler(this.Inup1_Leave);
			// 
			// Inup2
			// 
			this.Inup2.Location = new System.Drawing.Point(1020, 255);
			this.Inup2.Name = "Inup2";
			this.Inup2.Size = new System.Drawing.Size(100, 26);
			this.Inup2.TabIndex = 42;
			this.Inup2.Leave += new System.EventHandler(this.Inup2_Leave);
			// 
			// Invp1
			// 
			this.Invp1.Location = new System.Drawing.Point(1020, 360);
			this.Invp1.Name = "Invp1";
			this.Invp1.Size = new System.Drawing.Size(100, 26);
			this.Invp1.TabIndex = 43;
			this.Invp1.Leave += new System.EventHandler(this.Invp1_Leave);
			// 
			// Invp2
			// 
			this.Invp2.Location = new System.Drawing.Point(1020, 465);
			this.Invp2.Name = "Invp2";
			this.Invp2.Size = new System.Drawing.Size(100, 26);
			this.Invp2.TabIndex = 44;
			this.Invp2.Leave += new System.EventHandler(this.Invp2_Leave);
			// 
			// InAp1
			// 
			this.InAp1.Location = new System.Drawing.Point(1020, 570);
			this.InAp1.Name = "InAp1";
			this.InAp1.Size = new System.Drawing.Size(100, 26);
			this.InAp1.TabIndex = 45;
			this.InAp1.Leave += new System.EventHandler(this.InAp1_Leave);
			// 
			// InAp2
			// 
			this.InAp2.Location = new System.Drawing.Point(1020, 675);
			this.InAp2.Name = "InAp2";
			this.InAp2.Size = new System.Drawing.Size(100, 26);
			this.InAp2.TabIndex = 46;
			this.InAp2.Leave += new System.EventHandler(this.InAp2_Leave);
			// 
			// Ingamma
			// 
			this.Ingamma.Location = new System.Drawing.Point(60, 570);
			this.Ingamma.Name = "Ingamma";
			this.Ingamma.Size = new System.Drawing.Size(100, 26);
			this.Ingamma.TabIndex = 47;
			this.Ingamma.Leave += new System.EventHandler(this.Ingamma_Leave);
			// 
			// In_mu
			// 
			this.In_mu.Location = new System.Drawing.Point(60, 675);
			this.In_mu.Name = "In_mu";
			this.In_mu.Size = new System.Drawing.Size(100, 26);
			this.In_mu.TabIndex = 48;
			this.In_mu.Leave += new System.EventHandler(this.In_mu_Leave);
			// 
			// InH
			// 
			this.InH.Location = new System.Drawing.Point(700, 570);
			this.InH.Name = "InH";
			this.InH.Size = new System.Drawing.Size(100, 26);
			this.InH.TabIndex = 49;
			this.InH.Leave += new System.EventHandler(this.InH_Leave);
			// 
			// Inpq
			// 
			this.Inpq.Location = new System.Drawing.Point(60, 465);
			this.Inpq.Name = "Inpq";
			this.Inpq.Size = new System.Drawing.Size(100, 26);
			this.Inpq.TabIndex = 50;
			this.Inpq.Leave += new System.EventHandler(this.Inpq_Leave);
			// 
			// proceed
			// 
			this.proceed.Location = new System.Drawing.Point(1020, 25);
			this.proceed.Name = "proceed";
			this.proceed.Size = new System.Drawing.Size(200, 85);
			this.proceed.TabIndex = 51;
			this.proceed.Text = "перейти к созданию наблюдений";
			this.proceed.UseVisualStyleBackColor = true;
			this.proceed.Click += new System.EventHandler(this.proceed_Click);
			// 
			// openFileInput
			// 
			this.openFileInput.DefaultExt = "txt";
			this.openFileInput.Filter = "TXT files (*.txt)|*.txt";
			// 
			// saveFileInput
			// 
			this.saveFileInput.DefaultExt = "txt";
			this.saveFileInput.Filter = "TXT files (*.txt)|*.txt";
			// 
			// info
			// 
			this.info.Location = new System.Drawing.Point(60, 25);
			this.info.Name = "info";
			this.info.Size = new System.Drawing.Size(200, 85);
			this.info.TabIndex = 52;
			this.info.Text = "информация";
			this.info.UseVisualStyleBackColor = true;
			this.info.Click += new System.EventHandler(this.info_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1338, 740);
			this.Controls.Add(this.info);
			this.Controls.Add(this.proceed);
			this.Controls.Add(this.Inpq);
			this.Controls.Add(this.InH);
			this.Controls.Add(this.In_mu);
			this.Controls.Add(this.Ingamma);
			this.Controls.Add(this.InAp2);
			this.Controls.Add(this.InAp1);
			this.Controls.Add(this.Invp2);
			this.Controls.Add(this.Invp1);
			this.Controls.Add(this.Inup2);
			this.Controls.Add(this.Inup1);
			this.Controls.Add(this.InTc);
			this.Controls.Add(this.lpq);
			this.Controls.Add(this.Ina);
			this.Controls.Add(this.Inv);
			this.Controls.Add(this.Inu);
			this.Controls.Add(this.Indv);
			this.Controls.Add(this.Indu);
			this.Controls.Add(this.InVm);
			this.Controls.Add(this.InUm);
			this.Controls.Add(this.InMv);
			this.Controls.Add(this.InMu);
			this.Controls.Add(this.lH);
			this.Controls.Add(this.l_mu);
			this.Controls.Add(this.lgamma);
			this.Controls.Add(this.lAp2);
			this.Controls.Add(this.lAp1);
			this.Controls.Add(this.lvp2);
			this.Controls.Add(this.lvp1);
			this.Controls.Add(this.lup2);
			this.Controls.Add(this.lup1);
			this.Controls.Add(this.lTc);
			this.Controls.Add(this.la);
			this.Controls.Add(this.lv);
			this.Controls.Add(this.lu);
			this.Controls.Add(this.ldv);
			this.Controls.Add(this.ldu);
			this.Controls.Add(this.lVm);
			this.Controls.Add(this.lUm);
			this.Controls.Add(this.lMu);
			this.Controls.Add(this.lMv);
			this.Controls.Add(this.lN);
			this.Controls.Add(this.InN);
			this.Controls.Add(this.inputDownload);
			this.Controls.Add(this.inputUpload);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button inputUpload;
		private System.Windows.Forms.Button inputDownload;
		private System.Windows.Forms.TextBox InN;
		private System.Windows.Forms.Label lN;
		private System.Windows.Forms.Label lMv;
		private System.Windows.Forms.Label lMu;
		private System.Windows.Forms.Label lUm;
		private System.Windows.Forms.Label lVm;
		private System.Windows.Forms.Label ldu;
		private System.Windows.Forms.Label ldv;
		private System.Windows.Forms.Label lu;
		private System.Windows.Forms.Label lv;
		private System.Windows.Forms.Label la;
		private System.Windows.Forms.Label lTc;
		private System.Windows.Forms.Label lup1;
		private System.Windows.Forms.Label lup2;
		private System.Windows.Forms.Label lvp1;
		private System.Windows.Forms.Label lvp2;
		private System.Windows.Forms.Label lAp1;
		private System.Windows.Forms.Label lAp2;
		private System.Windows.Forms.Label lgamma;
		private System.Windows.Forms.Label l_mu;
		private System.Windows.Forms.Label lH;
		private System.Windows.Forms.TextBox InMu;
		private System.Windows.Forms.TextBox InMv;
		private System.Windows.Forms.TextBox InUm;
		private System.Windows.Forms.TextBox InVm;
		private System.Windows.Forms.TextBox Indu;
		private System.Windows.Forms.TextBox Indv;
		private System.Windows.Forms.TextBox Inu;
		private System.Windows.Forms.TextBox Inv;
		private System.Windows.Forms.TextBox Ina;
		private System.Windows.Forms.Label lpq;
		private System.Windows.Forms.TextBox InTc;
		private System.Windows.Forms.TextBox Inup1;
		private System.Windows.Forms.TextBox Inup2;
		private System.Windows.Forms.TextBox Invp1;
		private System.Windows.Forms.TextBox Invp2;
		private System.Windows.Forms.TextBox InAp1;
		private System.Windows.Forms.TextBox InAp2;
		private System.Windows.Forms.TextBox Ingamma;
		private System.Windows.Forms.TextBox In_mu;
		private System.Windows.Forms.TextBox InH;
		private System.Windows.Forms.TextBox Inpq;
		private System.Windows.Forms.ToolTip toolTipTc;
		private System.Windows.Forms.ToolTip toolTipMu;
		private System.Windows.Forms.ToolTip toolTipMv;
		private System.Windows.Forms.ToolTip toolTipN;
		private System.Windows.Forms.ToolTip toolTipPq;
		private System.Windows.Forms.ToolTip toolTipGamma;
		private System.Windows.Forms.ToolTip toolTip_Mu;
		private System.Windows.Forms.ToolTip toolTipUm;
		private System.Windows.Forms.ToolTip toolTipVm;
		private System.Windows.Forms.ToolTip toolTipDu;
		private System.Windows.Forms.ToolTip toolTipDv;
		private System.Windows.Forms.ToolTip toolTipU;
		private System.Windows.Forms.ToolTip toolTipV;
		private System.Windows.Forms.ToolTip toolTipA;
		private System.Windows.Forms.ToolTip toolTipH;
		private System.Windows.Forms.ToolTip toolTipUp1;
		private System.Windows.Forms.ToolTip toolTipUp2;
		private System.Windows.Forms.ToolTip toolTipVp1;
		private System.Windows.Forms.ToolTip toolTipVp2;
		private System.Windows.Forms.ToolTip toolTipAp1;
		private System.Windows.Forms.ToolTip toolTipAp2;
		private System.Windows.Forms.Button proceed;
		private System.Windows.Forms.OpenFileDialog openFileInput;
		private System.Windows.Forms.SaveFileDialog saveFileInput;
		private System.Windows.Forms.Button info;
	}
}

