namespace Journal
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
            this.studentsListBox = new System.Windows.Forms.ListBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.classTextBox = new System.Windows.Forms.TextBox();
            this.showAllButton = new System.Windows.Forms.Button();
            this.addStudentButton = new System.Windows.Forms.Button();
            this.deleteStudentButton = new System.Windows.Forms.Button();
            this.searchStudentButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.classLabel = new System.Windows.Forms.Label();
            this.marksListBox = new System.Windows.Forms.ListBox();
            this.changeMarksButton = new System.Windows.Forms.Button();
            this.controlTextBox1 = new System.Windows.Forms.TextBox();
            this.controlTextBox2 = new System.Windows.Forms.TextBox();
            this.controlTextBox3 = new System.Windows.Forms.TextBox();
            this.controlTextBox4 = new System.Windows.Forms.TextBox();
            this.controlLabel1 = new System.Windows.Forms.Label();
            this.controlLabel2 = new System.Windows.Forms.Label();
            this.controlLabel3 = new System.Windows.Forms.Label();
            this.controlLabel4 = new System.Windows.Forms.Label();
            this.numbersListBox = new System.Windows.Forms.ListBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.mathLabel = new System.Windows.Forms.Label();
            this.physLabel = new System.Windows.Forms.Label();
            this.rpksLabel = new System.Windows.Forms.Label();
            this.databaseLabel = new System.Windows.Forms.Label();
            this.changeInfoButton = new System.Windows.Forms.Button();
            this.isAutoSetCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // studentsListBox
            // 
            this.studentsListBox.FormattingEnabled = true;
            this.studentsListBox.Location = new System.Drawing.Point(37, 46);
            this.studentsListBox.Name = "studentsListBox";
            this.studentsListBox.Size = new System.Drawing.Size(245, 524);
            this.studentsListBox.TabIndex = 0;
            this.studentsListBox.SelectedIndexChanged += new System.EventHandler(this.studentsListBox_SelectedIndexChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(320, 46);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(91, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(449, 46);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(117, 20);
            this.surnameTextBox.TabIndex = 2;
            // 
            // classTextBox
            // 
            this.classTextBox.Location = new System.Drawing.Point(612, 46);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(53, 20);
            this.classTextBox.TabIndex = 3;
            // 
            // showAllButton
            // 
            this.showAllButton.Location = new System.Drawing.Point(320, 94);
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.Size = new System.Drawing.Size(165, 23);
            this.showAllButton.TabIndex = 4;
            this.showAllButton.Text = "Показать всех";
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.Click += new System.EventHandler(this.showAllButton_Click);
            // 
            // addStudentButton
            // 
            this.addStudentButton.Location = new System.Drawing.Point(320, 134);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(165, 23);
            this.addStudentButton.TabIndex = 5;
            this.addStudentButton.Text = "Добавить ученика";
            this.addStudentButton.UseVisualStyleBackColor = true;
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // deleteStudentButton
            // 
            this.deleteStudentButton.Location = new System.Drawing.Point(504, 134);
            this.deleteStudentButton.Name = "deleteStudentButton";
            this.deleteStudentButton.Size = new System.Drawing.Size(161, 23);
            this.deleteStudentButton.TabIndex = 6;
            this.deleteStudentButton.Text = "Удалить ученика";
            this.deleteStudentButton.UseVisualStyleBackColor = true;
            this.deleteStudentButton.Click += new System.EventHandler(this.deleteStudentButton_Click);
            // 
            // searchStudentButton
            // 
            this.searchStudentButton.AllowDrop = true;
            this.searchStudentButton.Location = new System.Drawing.Point(504, 94);
            this.searchStudentButton.Name = "searchStudentButton";
            this.searchStudentButton.Size = new System.Drawing.Size(161, 23);
            this.searchStudentButton.TabIndex = 7;
            this.searchStudentButton.Text = "Найти";
            this.searchStudentButton.UseVisualStyleBackColor = true;
            this.searchStudentButton.Click += new System.EventHandler(this.searchStudentButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(317, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 13);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "Имя";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(446, 13);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(56, 13);
            this.surnameLabel.TabIndex = 10;
            this.surnameLabel.Text = "Фамилия";
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(609, 13);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(38, 13);
            this.classLabel.TabIndex = 11;
            this.classLabel.Text = "Класс";
            // 
            // marksListBox
            // 
            this.marksListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.marksListBox.FormattingEnabled = true;
            this.marksListBox.ItemHeight = 38;
            this.marksListBox.Location = new System.Drawing.Point(474, 281);
            this.marksListBox.Name = "marksListBox";
            this.marksListBox.Size = new System.Drawing.Size(191, 156);
            this.marksListBox.TabIndex = 13;
            this.marksListBox.SelectedIndexChanged += new System.EventHandler(this.marksListBox_SelectedIndexChanged);
            // 
            // changeMarksButton
            // 
            this.changeMarksButton.Location = new System.Drawing.Point(365, 547);
            this.changeMarksButton.Name = "changeMarksButton";
            this.changeMarksButton.Size = new System.Drawing.Size(300, 23);
            this.changeMarksButton.TabIndex = 14;
            this.changeMarksButton.Text = "Изменить оценки";
            this.changeMarksButton.UseVisualStyleBackColor = true;
            this.changeMarksButton.Click += new System.EventHandler(this.changeMarksButton_Click);
            // 
            // controlTextBox1
            // 
            this.controlTextBox1.Location = new System.Drawing.Point(365, 489);
            this.controlTextBox1.Name = "controlTextBox1";
            this.controlTextBox1.Size = new System.Drawing.Size(39, 20);
            this.controlTextBox1.TabIndex = 15;
            this.controlTextBox1.TextChanged += new System.EventHandler(this.controlTextBox1_TextChanged);
            // 
            // controlTextBox2
            // 
            this.controlTextBox2.Location = new System.Drawing.Point(426, 489);
            this.controlTextBox2.Name = "controlTextBox2";
            this.controlTextBox2.Size = new System.Drawing.Size(39, 20);
            this.controlTextBox2.TabIndex = 16;
            this.controlTextBox2.TextChanged += new System.EventHandler(this.controlTextBox2_TextChanged);
            // 
            // controlTextBox3
            // 
            this.controlTextBox3.Location = new System.Drawing.Point(490, 489);
            this.controlTextBox3.Name = "controlTextBox3";
            this.controlTextBox3.Size = new System.Drawing.Size(39, 20);
            this.controlTextBox3.TabIndex = 17;
            this.controlTextBox3.TextChanged += new System.EventHandler(this.controlTextBox3_TextChanged);
            // 
            // controlTextBox4
            // 
            this.controlTextBox4.Location = new System.Drawing.Point(554, 489);
            this.controlTextBox4.Name = "controlTextBox4";
            this.controlTextBox4.Size = new System.Drawing.Size(39, 20);
            this.controlTextBox4.TabIndex = 18;
            this.controlTextBox4.TextChanged += new System.EventHandler(this.controlTextBox4_TextChanged);
            // 
            // controlLabel1
            // 
            this.controlLabel1.AutoSize = true;
            this.controlLabel1.Location = new System.Drawing.Point(367, 469);
            this.controlLabel1.Name = "controlLabel1";
            this.controlLabel1.Size = new System.Drawing.Size(37, 13);
            this.controlLabel1.TabIndex = 19;
            this.controlLabel1.Text = "КСР 1";
            // 
            // controlLabel2
            // 
            this.controlLabel2.AutoSize = true;
            this.controlLabel2.Location = new System.Drawing.Point(428, 469);
            this.controlLabel2.Name = "controlLabel2";
            this.controlLabel2.Size = new System.Drawing.Size(37, 13);
            this.controlLabel2.TabIndex = 20;
            this.controlLabel2.Text = "КСР 2";
            // 
            // controlLabel3
            // 
            this.controlLabel3.AutoSize = true;
            this.controlLabel3.Location = new System.Drawing.Point(487, 469);
            this.controlLabel3.Name = "controlLabel3";
            this.controlLabel3.Size = new System.Drawing.Size(37, 13);
            this.controlLabel3.TabIndex = 21;
            this.controlLabel3.Text = "КСР 3";
            // 
            // controlLabel4
            // 
            this.controlLabel4.AutoSize = true;
            this.controlLabel4.Location = new System.Drawing.Point(556, 469);
            this.controlLabel4.Name = "controlLabel4";
            this.controlLabel4.Size = new System.Drawing.Size(37, 13);
            this.controlLabel4.TabIndex = 22;
            this.controlLabel4.Text = "КСР 4";
            // 
            // numbersListBox
            // 
            this.numbersListBox.Enabled = false;
            this.numbersListBox.FormattingEnabled = true;
            this.numbersListBox.Location = new System.Drawing.Point(12, 46);
            this.numbersListBox.Name = "numbersListBox";
            this.numbersListBox.Size = new System.Drawing.Size(26, 524);
            this.numbersListBox.TabIndex = 25;
            // 
            // totalTextBox
            // 
            this.totalTextBox.Location = new System.Drawing.Point(613, 489);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(52, 20);
            this.totalTextBox.TabIndex = 26;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(610, 469);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(55, 13);
            this.totalLabel.TabIndex = 27;
            this.totalLabel.Text = "Итоговая";
            // 
            // mathLabel
            // 
            this.mathLabel.AutoSize = true;
            this.mathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mathLabel.Location = new System.Drawing.Point(288, 281);
            this.mathLabel.Name = "mathLabel";
            this.mathLabel.Size = new System.Drawing.Size(168, 31);
            this.mathLabel.TabIndex = 28;
            this.mathLabel.Text = "Математика";
            // 
            // physLabel
            // 
            this.physLabel.AutoSize = true;
            this.physLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.physLabel.Location = new System.Drawing.Point(288, 321);
            this.physLabel.Name = "physLabel";
            this.physLabel.Size = new System.Drawing.Size(110, 31);
            this.physLabel.TabIndex = 29;
            this.physLabel.Text = "Физика";
            // 
            // rpksLabel
            // 
            this.rpksLabel.AutoSize = true;
            this.rpksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rpksLabel.Location = new System.Drawing.Point(288, 364);
            this.rpksLabel.Name = "rpksLabel";
            this.rpksLabel.Size = new System.Drawing.Size(90, 31);
            this.rpksLabel.TabIndex = 30;
            this.rpksLabel.Text = "РПКС";
            // 
            // databaseLabel
            // 
            this.databaseLabel.AutoSize = true;
            this.databaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.databaseLabel.Location = new System.Drawing.Point(288, 406);
            this.databaseLabel.Name = "databaseLabel";
            this.databaseLabel.Size = new System.Drawing.Size(180, 31);
            this.databaseLabel.TabIndex = 31;
            this.databaseLabel.Text = "Базы данных";
            // 
            // changeInfoButton
            // 
            this.changeInfoButton.Location = new System.Drawing.Point(320, 173);
            this.changeInfoButton.Name = "changeInfoButton";
            this.changeInfoButton.Size = new System.Drawing.Size(345, 23);
            this.changeInfoButton.TabIndex = 32;
            this.changeInfoButton.Text = "Изменить информацию об ученике";
            this.changeInfoButton.UseVisualStyleBackColor = true;
            this.changeInfoButton.Click += new System.EventHandler(this.changeInfoButton_Click);
            // 
            // isAutoSetCheckBox
            // 
            this.isAutoSetCheckBox.AutoSize = true;
            this.isAutoSetCheckBox.Location = new System.Drawing.Point(365, 515);
            this.isAutoSetCheckBox.Name = "isAutoSetCheckBox";
            this.isAutoSetCheckBox.Size = new System.Drawing.Size(205, 17);
            this.isAutoSetCheckBox.TabIndex = 33;
            this.isAutoSetCheckBox.Text = "Автовыставление итоговой оценки";
            this.isAutoSetCheckBox.UseVisualStyleBackColor = true;
            this.isAutoSetCheckBox.CheckedChanged += new System.EventHandler(this.isAutoSetCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 619);
            this.Controls.Add(this.isAutoSetCheckBox);
            this.Controls.Add(this.changeInfoButton);
            this.Controls.Add(this.databaseLabel);
            this.Controls.Add(this.rpksLabel);
            this.Controls.Add(this.physLabel);
            this.Controls.Add(this.mathLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.numbersListBox);
            this.Controls.Add(this.controlLabel4);
            this.Controls.Add(this.controlLabel3);
            this.Controls.Add(this.controlLabel2);
            this.Controls.Add(this.controlLabel1);
            this.Controls.Add(this.controlTextBox4);
            this.Controls.Add(this.controlTextBox3);
            this.Controls.Add(this.controlTextBox2);
            this.Controls.Add(this.controlTextBox1);
            this.Controls.Add(this.changeMarksButton);
            this.Controls.Add(this.marksListBox);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.searchStudentButton);
            this.Controls.Add(this.deleteStudentButton);
            this.Controls.Add(this.addStudentButton);
            this.Controls.Add(this.showAllButton);
            this.Controls.Add(this.classTextBox);
            this.Controls.Add(this.surnameTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.studentsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox studentsListBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox classTextBox;
        private System.Windows.Forms.Button showAllButton;
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.Button deleteStudentButton;
        private System.Windows.Forms.Button searchStudentButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.ListBox marksListBox;
        private System.Windows.Forms.Button changeMarksButton;
        private System.Windows.Forms.TextBox controlTextBox1;
        private System.Windows.Forms.TextBox controlTextBox2;
        private System.Windows.Forms.TextBox controlTextBox3;
        private System.Windows.Forms.TextBox controlTextBox4;
        private System.Windows.Forms.Label controlLabel1;
        private System.Windows.Forms.Label controlLabel2;
        private System.Windows.Forms.Label controlLabel3;
        private System.Windows.Forms.Label controlLabel4;
        private System.Windows.Forms.ListBox numbersListBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label mathLabel;
        private System.Windows.Forms.Label physLabel;
        private System.Windows.Forms.Label rpksLabel;
        private System.Windows.Forms.Label databaseLabel;
        private System.Windows.Forms.Button changeInfoButton;
        private System.Windows.Forms.CheckBox isAutoSetCheckBox;
    }
}

