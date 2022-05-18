namespace FindProcess
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButBFSS = new System.Windows.Forms.RadioButton();
            this.radioButFSS = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonCleanProc = new System.Windows.Forms.Button();
            this.ButtonChangeProc = new System.Windows.Forms.Button();
            this.ProcToClean = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProcMade = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButBFSS);
            this.groupBox1.Controls.Add(this.radioButFSS);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radioButBFSS
            // 
            this.radioButBFSS.AutoSize = true;
            this.radioButBFSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButBFSS.Location = new System.Drawing.Point(213, 3);
            this.radioButBFSS.Name = "radioButBFSS";
            this.radioButBFSS.Size = new System.Drawing.Size(47, 13);
            this.radioButBFSS.TabIndex = 3;
            this.radioButBFSS.TabStop = true;
            this.radioButBFSS.Text = "БФСС";
            this.radioButBFSS.UseVisualStyleBackColor = true;
            this.radioButBFSS.CheckedChanged += new System.EventHandler(this.RadioButBFSS_CheckedChanged);
            // 
            // radioButFSS
            // 
            this.radioButFSS.AutoSize = true;
            this.radioButFSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButFSS.Location = new System.Drawing.Point(169, 3);
            this.radioButFSS.Name = "radioButFSS";
            this.radioButFSS.Size = new System.Drawing.Size(42, 13);
            this.radioButFSS.TabIndex = 2;
            this.radioButFSS.TabStop = true;
            this.radioButFSS.Text = "ФСС";
            this.radioButFSS.UseVisualStyleBackColor = true;
            this.radioButFSS.CheckedChanged += new System.EventHandler(this.RadioButFSS_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.ButtonCancel);
            this.groupBox3.Controls.Add(this.ButtonCleanProc);
            this.groupBox3.Controls.Add(this.ButtonChangeProc);
            this.groupBox3.Controls.Add(this.ProcToClean);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(8, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 60);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Процессов до профилактики";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(167, 19);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 33);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.TabStop = false;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Visible = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonCleanProc
            // 
            this.ButtonCleanProc.Location = new System.Drawing.Point(7, 19);
            this.ButtonCleanProc.Name = "ButtonCleanProc";
            this.ButtonCleanProc.Size = new System.Drawing.Size(75, 33);
            this.ButtonCleanProc.TabIndex = 2;
            this.ButtonCleanProc.TabStop = false;
            this.ButtonCleanProc.Text = "Сбросить";
            this.ButtonCleanProc.UseVisualStyleBackColor = true;
            this.ButtonCleanProc.Visible = false;
            this.ButtonCleanProc.Click += new System.EventHandler(this.ButtonCleanProc_Click);
            // 
            // ButtonChangeProc
            // 
            this.ButtonChangeProc.Location = new System.Drawing.Point(87, 19);
            this.ButtonChangeProc.Name = "ButtonChangeProc";
            this.ButtonChangeProc.Size = new System.Drawing.Size(75, 33);
            this.ButtonChangeProc.TabIndex = 1;
            this.ButtonChangeProc.TabStop = false;
            this.ButtonChangeProc.Text = "Изменить";
            this.ButtonChangeProc.UseVisualStyleBackColor = true;
            this.ButtonChangeProc.Visible = false;
            this.ButtonChangeProc.Click += new System.EventHandler(this.ButtonChangeProc_Click);
            // 
            // ProcToClean
            // 
            this.ProcToClean.BackColor = System.Drawing.SystemColors.Control;
            this.ProcToClean.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcToClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProcToClean.Location = new System.Drawing.Point(3, 17);
            this.ProcToClean.Name = "ProcToClean";
            this.ProcToClean.Size = new System.Drawing.Size(244, 40);
            this.ProcToClean.TabIndex = 0;
            this.ProcToClean.Text = "0";
            this.ProcToClean.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProcToClean.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ProcToClean_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProcMade);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(8, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 44);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Проведено процессов за все время";
            // 
            // ProcMade
            // 
            this.ProcMade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcMade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProcMade.Location = new System.Drawing.Point(3, 17);
            this.ProcMade.Name = "ProcMade";
            this.ProcMade.Size = new System.Drawing.Size(244, 24);
            this.ProcMade.TabIndex = 0;
            this.ProcMade.Text = "0";
            this.ProcMade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 140);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label ProcToClean;
        private System.Windows.Forms.Label ProcMade;
        private System.Windows.Forms.Timer timer1;       
        private System.Windows.Forms.Button ButtonChangeProc;
        private System.Windows.Forms.Button ButtonCleanProc;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.RadioButton radioButBFSS;
        private System.Windows.Forms.RadioButton radioButFSS;
    }
}

