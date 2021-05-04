
namespace CourseWork
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
            this.sizebox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.method = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.elem00 = new System.Windows.Forms.TextBox();
            this.solve = new System.Windows.Forms.Button();
            this.elem01 = new System.Windows.Forms.TextBox();
            this.elem02 = new System.Windows.Forms.TextBox();
            this.elem03 = new System.Windows.Forms.TextBox();
            this.elem04 = new System.Windows.Forms.TextBox();
            this.row1 = new System.Windows.Forms.GroupBox();
            this.row2 = new System.Windows.Forms.GroupBox();
            this.elem14 = new System.Windows.Forms.TextBox();
            this.elem13 = new System.Windows.Forms.TextBox();
            this.elem10 = new System.Windows.Forms.TextBox();
            this.elem12 = new System.Windows.Forms.TextBox();
            this.elem11 = new System.Windows.Forms.TextBox();
            this.row3 = new System.Windows.Forms.GroupBox();
            this.elem24 = new System.Windows.Forms.TextBox();
            this.elem23 = new System.Windows.Forms.TextBox();
            this.elem20 = new System.Windows.Forms.TextBox();
            this.elem22 = new System.Windows.Forms.TextBox();
            this.elem21 = new System.Windows.Forms.TextBox();
            this.row4 = new System.Windows.Forms.GroupBox();
            this.elem34 = new System.Windows.Forms.TextBox();
            this.elem33 = new System.Windows.Forms.TextBox();
            this.elem30 = new System.Windows.Forms.TextBox();
            this.elem32 = new System.Windows.Forms.TextBox();
            this.elem31 = new System.Windows.Forms.TextBox();
            this.row5 = new System.Windows.Forms.GroupBox();
            this.elem44 = new System.Windows.Forms.TextBox();
            this.elem43 = new System.Windows.Forms.TextBox();
            this.elem40 = new System.Windows.Forms.TextBox();
            this.elem42 = new System.Windows.Forms.TextBox();
            this.elem41 = new System.Windows.Forms.TextBox();
            this.generate = new System.Windows.Forms.Button();
            this.buttonDet = new System.Windows.Forms.Button();
            this.labelDet = new System.Windows.Forms.Label();
            this.row1.SuspendLayout();
            this.row2.SuspendLayout();
            this.row3.SuspendLayout();
            this.row4.SuspendLayout();
            this.row5.SuspendLayout();
            this.SuspendLayout();
            // 
            // sizebox
            // 
            this.sizebox.FormattingEnabled = true;
            this.sizebox.Location = new System.Drawing.Point(70, 49);
            this.sizebox.Name = "sizebox";
            this.sizebox.Size = new System.Drawing.Size(47, 21);
            this.sizebox.TabIndex = 0;
            this.sizebox.SelectedIndexChanged += new System.EventHandler(this.sizebox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Розмір матриці: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(51, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(579, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Метод розв\'язання:";
            // 
            // method
            // 
            this.method.FormattingEnabled = true;
            this.method.Location = new System.Drawing.Point(580, 305);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(134, 21);
            this.method.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(15, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "A = ";
            // 
            // elem00
            // 
            this.elem00.Location = new System.Drawing.Point(3, 9);
            this.elem00.Name = "elem00";
            this.elem00.Size = new System.Drawing.Size(33, 20);
            this.elem00.TabIndex = 6;
            // 
            // solve
            // 
            this.solve.Location = new System.Drawing.Point(591, 335);
            this.solve.Name = "solve";
            this.solve.Size = new System.Drawing.Size(110, 35);
            this.solve.TabIndex = 7;
            this.solve.Text = "Розв\'язати";
            this.solve.UseVisualStyleBackColor = true;
            this.solve.Click += new System.EventHandler(this.solve_Click);
            // 
            // elem01
            // 
            this.elem01.Location = new System.Drawing.Point(42, 9);
            this.elem01.Name = "elem01";
            this.elem01.Size = new System.Drawing.Size(33, 20);
            this.elem01.TabIndex = 8;
            // 
            // elem02
            // 
            this.elem02.Location = new System.Drawing.Point(81, 9);
            this.elem02.Name = "elem02";
            this.elem02.Size = new System.Drawing.Size(33, 20);
            this.elem02.TabIndex = 9;
            // 
            // elem03
            // 
            this.elem03.Location = new System.Drawing.Point(120, 9);
            this.elem03.Name = "elem03";
            this.elem03.Size = new System.Drawing.Size(33, 20);
            this.elem03.TabIndex = 10;
            // 
            // elem04
            // 
            this.elem04.Location = new System.Drawing.Point(158, 9);
            this.elem04.Name = "elem04";
            this.elem04.Size = new System.Drawing.Size(33, 20);
            this.elem04.TabIndex = 11;
            // 
            // row1
            // 
            this.row1.Controls.Add(this.elem04);
            this.row1.Controls.Add(this.elem03);
            this.row1.Controls.Add(this.elem00);
            this.row1.Controls.Add(this.elem02);
            this.row1.Controls.Add(this.elem01);
            this.row1.Location = new System.Drawing.Point(54, 104);
            this.row1.Name = "row1";
            this.row1.Size = new System.Drawing.Size(197, 33);
            this.row1.TabIndex = 32;
            this.row1.TabStop = false;
            // 
            // row2
            // 
            this.row2.Controls.Add(this.elem14);
            this.row2.Controls.Add(this.elem13);
            this.row2.Controls.Add(this.elem10);
            this.row2.Controls.Add(this.elem12);
            this.row2.Controls.Add(this.elem11);
            this.row2.Location = new System.Drawing.Point(54, 134);
            this.row2.Name = "row2";
            this.row2.Size = new System.Drawing.Size(197, 33);
            this.row2.TabIndex = 33;
            this.row2.TabStop = false;
            // 
            // elem14
            // 
            this.elem14.Location = new System.Drawing.Point(158, 9);
            this.elem14.Name = "elem14";
            this.elem14.Size = new System.Drawing.Size(33, 20);
            this.elem14.TabIndex = 11;
            // 
            // elem13
            // 
            this.elem13.Location = new System.Drawing.Point(120, 9);
            this.elem13.Name = "elem13";
            this.elem13.Size = new System.Drawing.Size(33, 20);
            this.elem13.TabIndex = 10;
            // 
            // elem10
            // 
            this.elem10.Location = new System.Drawing.Point(3, 9);
            this.elem10.Name = "elem10";
            this.elem10.Size = new System.Drawing.Size(33, 20);
            this.elem10.TabIndex = 6;
            // 
            // elem12
            // 
            this.elem12.Location = new System.Drawing.Point(81, 9);
            this.elem12.Name = "elem12";
            this.elem12.Size = new System.Drawing.Size(33, 20);
            this.elem12.TabIndex = 9;
            // 
            // elem11
            // 
            this.elem11.Location = new System.Drawing.Point(42, 9);
            this.elem11.Name = "elem11";
            this.elem11.Size = new System.Drawing.Size(33, 20);
            this.elem11.TabIndex = 8;
            // 
            // row3
            // 
            this.row3.Controls.Add(this.elem24);
            this.row3.Controls.Add(this.elem23);
            this.row3.Controls.Add(this.elem20);
            this.row3.Controls.Add(this.elem22);
            this.row3.Controls.Add(this.elem21);
            this.row3.Location = new System.Drawing.Point(54, 165);
            this.row3.Name = "row3";
            this.row3.Size = new System.Drawing.Size(197, 33);
            this.row3.TabIndex = 33;
            this.row3.TabStop = false;
            // 
            // elem24
            // 
            this.elem24.Location = new System.Drawing.Point(158, 9);
            this.elem24.Name = "elem24";
            this.elem24.Size = new System.Drawing.Size(33, 20);
            this.elem24.TabIndex = 11;
            // 
            // elem23
            // 
            this.elem23.Location = new System.Drawing.Point(120, 9);
            this.elem23.Name = "elem23";
            this.elem23.Size = new System.Drawing.Size(33, 20);
            this.elem23.TabIndex = 10;
            // 
            // elem20
            // 
            this.elem20.Location = new System.Drawing.Point(3, 9);
            this.elem20.Name = "elem20";
            this.elem20.Size = new System.Drawing.Size(33, 20);
            this.elem20.TabIndex = 6;
            // 
            // elem22
            // 
            this.elem22.Location = new System.Drawing.Point(81, 9);
            this.elem22.Name = "elem22";
            this.elem22.Size = new System.Drawing.Size(33, 20);
            this.elem22.TabIndex = 9;
            // 
            // elem21
            // 
            this.elem21.Location = new System.Drawing.Point(42, 9);
            this.elem21.Name = "elem21";
            this.elem21.Size = new System.Drawing.Size(33, 20);
            this.elem21.TabIndex = 8;
            // 
            // row4
            // 
            this.row4.Controls.Add(this.elem34);
            this.row4.Controls.Add(this.elem33);
            this.row4.Controls.Add(this.elem30);
            this.row4.Controls.Add(this.elem32);
            this.row4.Controls.Add(this.elem31);
            this.row4.Location = new System.Drawing.Point(54, 199);
            this.row4.Name = "row4";
            this.row4.Size = new System.Drawing.Size(197, 33);
            this.row4.TabIndex = 33;
            this.row4.TabStop = false;
            // 
            // elem34
            // 
            this.elem34.Location = new System.Drawing.Point(158, 9);
            this.elem34.Name = "elem34";
            this.elem34.Size = new System.Drawing.Size(33, 20);
            this.elem34.TabIndex = 11;
            // 
            // elem33
            // 
            this.elem33.Location = new System.Drawing.Point(120, 9);
            this.elem33.Name = "elem33";
            this.elem33.Size = new System.Drawing.Size(33, 20);
            this.elem33.TabIndex = 10;
            // 
            // elem30
            // 
            this.elem30.Location = new System.Drawing.Point(3, 9);
            this.elem30.Name = "elem30";
            this.elem30.Size = new System.Drawing.Size(33, 20);
            this.elem30.TabIndex = 6;
            // 
            // elem32
            // 
            this.elem32.Location = new System.Drawing.Point(81, 9);
            this.elem32.Name = "elem32";
            this.elem32.Size = new System.Drawing.Size(33, 20);
            this.elem32.TabIndex = 9;
            // 
            // elem31
            // 
            this.elem31.Location = new System.Drawing.Point(42, 9);
            this.elem31.Name = "elem31";
            this.elem31.Size = new System.Drawing.Size(33, 20);
            this.elem31.TabIndex = 8;
            // 
            // row5
            // 
            this.row5.Controls.Add(this.elem44);
            this.row5.Controls.Add(this.elem43);
            this.row5.Controls.Add(this.elem40);
            this.row5.Controls.Add(this.elem42);
            this.row5.Controls.Add(this.elem41);
            this.row5.Location = new System.Drawing.Point(54, 234);
            this.row5.Name = "row5";
            this.row5.Size = new System.Drawing.Size(197, 33);
            this.row5.TabIndex = 34;
            this.row5.TabStop = false;
            // 
            // elem44
            // 
            this.elem44.Location = new System.Drawing.Point(158, 9);
            this.elem44.Name = "elem44";
            this.elem44.Size = new System.Drawing.Size(33, 20);
            this.elem44.TabIndex = 11;
            // 
            // elem43
            // 
            this.elem43.Location = new System.Drawing.Point(120, 9);
            this.elem43.Name = "elem43";
            this.elem43.Size = new System.Drawing.Size(33, 20);
            this.elem43.TabIndex = 10;
            // 
            // elem40
            // 
            this.elem40.Location = new System.Drawing.Point(3, 9);
            this.elem40.Name = "elem40";
            this.elem40.Size = new System.Drawing.Size(33, 20);
            this.elem40.TabIndex = 6;
            // 
            // elem42
            // 
            this.elem42.Location = new System.Drawing.Point(81, 9);
            this.elem42.Name = "elem42";
            this.elem42.Size = new System.Drawing.Size(33, 20);
            this.elem42.TabIndex = 9;
            // 
            // elem41
            // 
            this.elem41.Location = new System.Drawing.Point(42, 9);
            this.elem41.Name = "elem41";
            this.elem41.Size = new System.Drawing.Size(33, 20);
            this.elem41.TabIndex = 8;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(184, 43);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(92, 32);
            this.generate.TabIndex = 35;
            this.generate.Text = "Згенерувати";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // buttonDet
            // 
            this.buttonDet.Location = new System.Drawing.Point(549, 24);
            this.buttonDet.Name = "buttonDet";
            this.buttonDet.Size = new System.Drawing.Size(75, 23);
            this.buttonDet.TabIndex = 36;
            this.buttonDet.Text = "FindDet";
            this.buttonDet.UseVisualStyleBackColor = true;
            this.buttonDet.Click += new System.EventHandler(this.buttonDet_Click);
            // 
            // labelDet
            // 
            this.labelDet.AutoSize = true;
            this.labelDet.Location = new System.Drawing.Point(646, 29);
            this.labelDet.Name = "labelDet";
            this.labelDet.Size = new System.Drawing.Size(0, 13);
            this.labelDet.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelDet);
            this.Controls.Add(this.buttonDet);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.row5);
            this.Controls.Add(this.row4);
            this.Controls.Add(this.row3);
            this.Controls.Add(this.row2);
            this.Controls.Add(this.row1);
            this.Controls.Add(this.solve);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.method);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizebox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.row1.ResumeLayout(false);
            this.row1.PerformLayout();
            this.row2.ResumeLayout(false);
            this.row2.PerformLayout();
            this.row3.ResumeLayout(false);
            this.row3.PerformLayout();
            this.row4.ResumeLayout(false);
            this.row4.PerformLayout();
            this.row5.ResumeLayout(false);
            this.row5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sizebox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox elem00;
        private System.Windows.Forms.Button solve;
        private System.Windows.Forms.TextBox elem01;
        private System.Windows.Forms.TextBox elem02;
        private System.Windows.Forms.TextBox elem03;
        private System.Windows.Forms.TextBox elem04;
        private System.Windows.Forms.GroupBox row1;
        private System.Windows.Forms.GroupBox row2;
        private System.Windows.Forms.TextBox elem14;
        private System.Windows.Forms.TextBox elem13;
        private System.Windows.Forms.TextBox elem10;
        private System.Windows.Forms.TextBox elem12;
        private System.Windows.Forms.TextBox elem11;
        private System.Windows.Forms.GroupBox row3;
        private System.Windows.Forms.TextBox elem24;
        private System.Windows.Forms.TextBox elem23;
        private System.Windows.Forms.TextBox elem20;
        private System.Windows.Forms.TextBox elem22;
        private System.Windows.Forms.TextBox elem21;
        private System.Windows.Forms.GroupBox row4;
        private System.Windows.Forms.TextBox elem34;
        private System.Windows.Forms.TextBox elem33;
        private System.Windows.Forms.TextBox elem30;
        private System.Windows.Forms.TextBox elem32;
        private System.Windows.Forms.TextBox elem31;
        private System.Windows.Forms.GroupBox row5;
        private System.Windows.Forms.TextBox elem44;
        private System.Windows.Forms.TextBox elem43;
        private System.Windows.Forms.TextBox elem40;
        private System.Windows.Forms.TextBox elem42;
        private System.Windows.Forms.TextBox elem41;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Button buttonDet;
        private System.Windows.Forms.Label labelDet;
    }
}

