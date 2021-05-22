
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.method = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.solve = new System.Windows.Forms.Button();
            this.generate = new System.Windows.Forms.Button();
            this.buttonDet = new System.Windows.Forms.Button();
            this.labelDet = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.importButton = new System.Windows.Forms.Button();
            this.gridInputMatrix = new System.Windows.Forms.DataGridView();
            this.numericSize = new System.Windows.Forms.NumericUpDown();
            this.gridResultMatrix = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridInputMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultMatrix)).BeginInit();
            this.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(29, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(459, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Метод розв\'язання:";
            // 
            // method
            // 
            this.method.FormattingEnabled = true;
            this.method.Location = new System.Drawing.Point(462, 484);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(134, 21);
            this.method.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(391, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "A = ";
            // 
            // solve
            // 
            this.solve.Location = new System.Drawing.Point(486, 520);
            this.solve.Name = "solve";
            this.solve.Size = new System.Drawing.Size(110, 35);
            this.solve.TabIndex = 7;
            this.solve.Text = "Розв\'язати";
            this.solve.UseVisualStyleBackColor = true;
            this.solve.Click += new System.EventHandler(this.solve_Click);
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(188, 43);
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(762, 523);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 38;
            this.importButton.Text = "Імпорт";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // gridInputMatrix
            // 
            this.gridInputMatrix.AllowUserToOrderColumns = true;
            this.gridInputMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInputMatrix.Location = new System.Drawing.Point(36, 105);
            this.gridInputMatrix.Name = "gridInputMatrix";
            this.gridInputMatrix.Size = new System.Drawing.Size(318, 265);
            this.gridInputMatrix.TabIndex = 39;
            // 
            // numericSize
            // 
            this.numericSize.Location = new System.Drawing.Point(52, 51);
            this.numericSize.Name = "numericSize";
            this.numericSize.Size = new System.Drawing.Size(104, 20);
            this.numericSize.TabIndex = 40;
            this.numericSize.ValueChanged += new System.EventHandler(this.numericSize_ValueChanged);
            // 
            // gridResultMatrix
            // 
            this.gridResultMatrix.AllowUserToOrderColumns = true;
            this.gridResultMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultMatrix.Location = new System.Drawing.Point(440, 105);
            this.gridResultMatrix.Name = "gridResultMatrix";
            this.gridResultMatrix.Size = new System.Drawing.Size(318, 265);
            this.gridResultMatrix.TabIndex = 41;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 558);
            this.Controls.Add(this.gridResultMatrix);
            this.Controls.Add(this.numericSize);
            this.Controls.Add(this.gridInputMatrix);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.labelDet);
            this.Controls.Add(this.buttonDet);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.solve);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.method);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Обернення матриці";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridInputMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button solve;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Button buttonDet;
        private System.Windows.Forms.Label labelDet;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.DataGridView gridInputMatrix;
        private System.Windows.Forms.NumericUpDown numericSize;
        private System.Windows.Forms.DataGridView gridResultMatrix;
    }
}

