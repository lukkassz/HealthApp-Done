namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabPage2 = new TabPage();
            refreshButton = new Button();
            dataGridView1 = new DataGridView();
            tabPage1 = new TabPage();
            btnUpdate = new Button();
            title = new Label();
            panel1 = new Panel();
            exercise0 = new RadioButton();
            exercise3 = new RadioButton();
            exercise1 = new RadioButton();
            exercise2 = new RadioButton();
            rbFruit3 = new RadioButton();
            rbFruit0 = new RadioButton();
            rbFruit2 = new RadioButton();
            rbFruit1 = new RadioButton();
            btnSubmit = new Button();
            lblExerciseQuestion = new Label();
            lblFruitQuestion = new Label();
            txtName = new TextBox();
            lblName = new Label();
            tabControl = new TabControl();
            btnExcelExport = new Button();
            label1 = new Label();
            btnPdfExport = new Button();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnPdfExport);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(btnExcelExport);
            tabPage2.Controls.Add(refreshButton);
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1139, 478);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(809, 411);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(138, 47);
            refreshButton.TabIndex = 1;
            refreshButton.Text = "Refresh data";
            refreshButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(30, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(773, 461);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.Controls.Add(btnUpdate);
            tabPage1.Controls.Add(title);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(rbFruit3);
            tabPage1.Controls.Add(rbFruit0);
            tabPage1.Controls.Add(rbFruit2);
            tabPage1.Controls.Add(rbFruit1);
            tabPage1.Controls.Add(btnSubmit);
            tabPage1.Controls.Add(lblExerciseQuestion);
            tabPage1.Controls.Add(lblFruitQuestion);
            tabPage1.Controls.Add(txtName);
            tabPage1.Controls.Add(lblName);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1139, 478);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.Click += tabPage1_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Transparent;
            btnUpdate.Font = new Font("Maiandra GD", 15F, FontStyle.Bold);
            btnUpdate.ForeColor = SystemColors.ActiveCaptionText;
            btnUpdate.Location = new Point(254, 383);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(198, 58);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Maiandra GD", 45F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = SystemColors.ActiveCaptionText;
            title.Location = new Point(659, 58);
            title.Name = "title";
            title.Size = new Size(450, 90);
            title.TabIndex = 14;
            title.Text = "Health App ";
            // 
            // panel1
            // 
            panel1.Controls.Add(exercise0);
            panel1.Controls.Add(exercise3);
            panel1.Controls.Add(exercise1);
            panel1.Controls.Add(exercise2);
            panel1.Location = new Point(33, 281);
            panel1.Name = "panel1";
            panel1.Size = new Size(304, 64);
            panel1.TabIndex = 13;
            // 
            // exercise0
            // 
            exercise0.AutoSize = true;
            exercise0.Location = new Point(6, 17);
            exercise0.Name = "exercise0";
            exercise0.Size = new Size(38, 24);
            exercise0.TabIndex = 8;
            exercise0.TabStop = true;
            exercise0.Text = "0";
            exercise0.UseVisualStyleBackColor = true;
            // 
            // exercise3
            // 
            exercise3.AutoSize = true;
            exercise3.Location = new Point(138, 17);
            exercise3.Name = "exercise3";
            exercise3.Size = new Size(48, 24);
            exercise3.TabIndex = 11;
            exercise3.TabStop = true;
            exercise3.Text = "3+";
            exercise3.UseVisualStyleBackColor = true;
            // 
            // exercise1
            // 
            exercise1.AutoSize = true;
            exercise1.Location = new Point(50, 17);
            exercise1.Name = "exercise1";
            exercise1.Size = new Size(38, 24);
            exercise1.TabIndex = 9;
            exercise1.TabStop = true;
            exercise1.Text = "1";
            exercise1.UseVisualStyleBackColor = true;
            // 
            // exercise2
            // 
            exercise2.AutoSize = true;
            exercise2.Location = new Point(94, 17);
            exercise2.Name = "exercise2";
            exercise2.Size = new Size(38, 24);
            exercise2.TabIndex = 10;
            exercise2.TabStop = true;
            exercise2.Text = "2";
            exercise2.UseVisualStyleBackColor = true;
            // 
            // rbFruit3
            // 
            rbFruit3.AutoSize = true;
            rbFruit3.Location = new Point(171, 203);
            rbFruit3.Name = "rbFruit3";
            rbFruit3.Size = new Size(48, 24);
            rbFruit3.TabIndex = 5;
            rbFruit3.TabStop = true;
            rbFruit3.Text = "3+";
            rbFruit3.UseVisualStyleBackColor = true;
            // 
            // rbFruit0
            // 
            rbFruit0.AutoSize = true;
            rbFruit0.Location = new Point(39, 203);
            rbFruit0.Name = "rbFruit0";
            rbFruit0.Size = new Size(38, 24);
            rbFruit0.TabIndex = 2;
            rbFruit0.TabStop = true;
            rbFruit0.Text = "0";
            rbFruit0.UseVisualStyleBackColor = true;
            // 
            // rbFruit2
            // 
            rbFruit2.AutoSize = true;
            rbFruit2.Location = new Point(127, 203);
            rbFruit2.Name = "rbFruit2";
            rbFruit2.Size = new Size(38, 24);
            rbFruit2.TabIndex = 4;
            rbFruit2.TabStop = true;
            rbFruit2.Text = "2";
            rbFruit2.UseVisualStyleBackColor = true;
            // 
            // rbFruit1
            // 
            rbFruit1.AutoSize = true;
            rbFruit1.Location = new Point(83, 203);
            rbFruit1.Name = "rbFruit1";
            rbFruit1.Size = new Size(38, 24);
            rbFruit1.TabIndex = 3;
            rbFruit1.TabStop = true;
            rbFruit1.Text = "1";
            rbFruit1.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.Transparent;
            btnSubmit.Font = new Font("Maiandra GD", 15F, FontStyle.Bold);
            btnSubmit.ForeColor = SystemColors.ActiveCaptionText;
            btnSubmit.Location = new Point(33, 383);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(198, 58);
            btnSubmit.TabIndex = 12;
            btnSubmit.Text = "Insert";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblExerciseQuestion
            // 
            lblExerciseQuestion.AutoSize = true;
            lblExerciseQuestion.Font = new Font("Maiandra GD", 15F, FontStyle.Bold);
            lblExerciseQuestion.Location = new Point(33, 248);
            lblExerciseQuestion.Name = "lblExerciseQuestion";
            lblExerciseQuestion.Size = new Size(466, 30);
            lblExerciseQuestion.TabIndex = 7;
            lblExerciseQuestion.Text = "How often do you exercise in a week?";
            // 
            // lblFruitQuestion
            // 
            lblFruitQuestion.AutoSize = true;
            lblFruitQuestion.Font = new Font("Maiandra GD", 15F, FontStyle.Bold);
            lblFruitQuestion.Location = new Point(33, 170);
            lblFruitQuestion.Name = "lblFruitQuestion";
            lblFruitQuestion.Size = new Size(455, 30);
            lblFruitQuestion.TabIndex = 6;
            lblFruitQuestion.Text = "How many fruits do you eat per day?";
            // 
            // txtName
            // 
            txtName.Location = new Point(33, 95);
            txtName.Name = "txtName";
            txtName.Size = new Size(132, 27);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Maiandra GD", 15F, FontStyle.Bold);
            lblName.Location = new Point(33, 58);
            lblName.Name = "lblName";
            lblName.Size = new Size(231, 30);
            lblName.TabIndex = 0;
            lblName.Text = "Whats your name?";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Location = new Point(3, 2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1147, 511);
            tabControl.TabIndex = 0;
            // 
            // btnExcelExport
            // 
            btnExcelExport.Location = new Point(826, 88);
            btnExcelExport.Name = "btnExcelExport";
            btnExcelExport.Size = new Size(121, 39);
            btnExcelExport.TabIndex = 2;
            btnExcelExport.Text = "Excel";
            btnExcelExport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Maiandra GD", 20F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(879, 20);
            label1.Name = "label1";
            label1.Size = new Size(165, 41);
            label1.TabIndex = 15;
            label1.Text = "Export to";
            // 
            // btnPdfExport
            // 
            btnPdfExport.Location = new Point(977, 88);
            btnPdfExport.Name = "btnPdfExport";
            btnPdfExport.Size = new Size(121, 39);
            btnPdfExport.TabIndex = 16;
            btnPdfExport.Text = "PDF";
            btnPdfExport.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1149, 510);
            Controls.Add(tabControl);
            Name = "Form1";
            Text = "Form1";
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private TabPage tabPage1;
        private Button btnUpdate;
        private Label title;
        private Panel panel1;
        private RadioButton exercise0;
        private RadioButton exercise3;
        private RadioButton exercise1;
        private RadioButton exercise2;
        private RadioButton rbFruit3;
        private RadioButton rbFruit0;
        private RadioButton rbFruit2;
        private RadioButton rbFruit1;
        private Button btnSubmit;
        private Label lblExerciseQuestion;
        private Label lblFruitQuestion;
        private TextBox txtName;
        private Label lblName;
        private TabControl tabControl;
        private Button refreshButton;
        private Label label1;
        private Button btnExcelExport;
        private Button btnPdfExport;
    }
}
