
namespace CourseWork
{
    partial class MainForm
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
            this.solveButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.labelDeterminant = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.importButton = new System.Windows.Forms.Button();
            this.gridInputMatrix = new System.Windows.Forms.DataGridView();
            this.numericSize = new System.Windows.Forms.NumericUpDown();
            this.gridResultMatrix = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkShowSolution = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.solutionBox = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.statsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridInputMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultMatrix)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Розмір матриці: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(178, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Метод розв\'язання:";
            // 
            // method
            // 
            this.method.FormattingEnabled = true;
            this.method.Location = new System.Drawing.Point(181, 59);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(134, 21);
            this.method.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(14, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "det(A) = ";
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(192, 86);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(110, 35);
            this.solveButton.TabIndex = 7;
            this.solveButton.Text = "Розв\'язати";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(37, 89);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(92, 32);
            this.generateButton.TabIndex = 35;
            this.generateButton.Text = "Згенерувати";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // labelDeterminant
            // 
            this.labelDeterminant.AutoSize = true;
            this.labelDeterminant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDeterminant.Location = new System.Drawing.Point(77, 14);
            this.labelDeterminant.Name = "labelDeterminant";
            this.labelDeterminant.Size = new System.Drawing.Size(0, 16);
            this.labelDeterminant.TabIndex = 37;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(607, 545);
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
            this.gridInputMatrix.Location = new System.Drawing.Point(10, 39);
            this.gridInputMatrix.Name = "gridInputMatrix";
            this.gridInputMatrix.Size = new System.Drawing.Size(318, 265);
            this.gridInputMatrix.TabIndex = 39;
            this.gridInputMatrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInputMatrix_CellValueChanged);
            // 
            // numericSize
            // 
            this.numericSize.Location = new System.Drawing.Point(37, 60);
            this.numericSize.Name = "numericSize";
            this.numericSize.Size = new System.Drawing.Size(104, 20);
            this.numericSize.TabIndex = 40;
            this.numericSize.ValueChanged += new System.EventHandler(this.numericSize_ValueChanged);
            // 
            // gridResultMatrix
            // 
            this.gridResultMatrix.AllowUserToOrderColumns = true;
            this.gridResultMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultMatrix.Location = new System.Drawing.Point(343, 39);
            this.gridResultMatrix.Name = "gridResultMatrix";
            this.gridResultMatrix.Size = new System.Drawing.Size(318, 265);
            this.gridResultMatrix.TabIndex = 41;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkShowSolution);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.method);
            this.groupBox1.Controls.Add(this.numericSize);
            this.groupBox1.Controls.Add(this.solveButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.generateButton);
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 167);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // checkShowSolution
            // 
            this.checkShowSolution.AutoSize = true;
            this.checkShowSolution.Location = new System.Drawing.Point(104, 136);
            this.checkShowSolution.Name = "checkShowSolution";
            this.checkShowSolution.Size = new System.Drawing.Size(117, 17);
            this.checkShowSolution.TabIndex = 41;
            this.checkShowSolution.Text = "Виводити рішення";
            this.checkShowSolution.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.gridInputMatrix);
            this.groupBox2.Controls.Add(this.gridResultMatrix);
            this.groupBox2.Location = new System.Drawing.Point(10, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 316);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(340, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 16);
            this.label6.TabIndex = 43;
            this.label6.Text = "Обернена матриця";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 16);
            this.label5.TabIndex = 42;
            this.label5.Text = "Початкова матриця";
            // 
            // solutionBox
            // 
            this.solutionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.solutionBox.Location = new System.Drawing.Point(7, 12);
            this.solutionBox.Name = "solutionBox";
            this.solutionBox.ReadOnly = true;
            this.solutionBox.Size = new System.Drawing.Size(305, 194);
            this.solutionBox.TabIndex = 45;
            this.solutionBox.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.solutionBox);
            this.groupBox3.Location = new System.Drawing.Point(363, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 213);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.labelDeterminant);
            this.groupBox4.Location = new System.Drawing.Point(10, 177);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(348, 40);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(526, 545);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 48;
            this.saveButton.Text = "Зберегти";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // statsButton
            // 
            this.statsButton.Location = new System.Drawing.Point(445, 545);
            this.statsButton.Name = "statsButton";
            this.statsButton.Size = new System.Drawing.Size(75, 23);
            this.statsButton.TabIndex = 49;
            this.statsButton.Text = "Статистика";
            this.statsButton.UseVisualStyleBackColor = true;
            this.statsButton.Click += new System.EventHandler(this.statsButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 573);
            this.Controls.Add(this.statsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.importButton);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Обернення матриці";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.gridInputMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultMatrix)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label labelDeterminant;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.DataGridView gridInputMatrix;
        private System.Windows.Forms.NumericUpDown numericSize;
        private System.Windows.Forms.DataGridView gridResultMatrix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.RichTextBox solutionBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox checkShowSolution;
        private System.Windows.Forms.Button statsButton;
    }
}

