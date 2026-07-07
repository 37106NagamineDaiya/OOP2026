namespace Section01 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dtpDate = new DateTimePicker();
            btGet = new Button();
            tbOut = new TextBox();
            label1 = new Label();
            nudDay = new NumericUpDown();
            dtpBirth = new DateTimePicker();
            btBirthCalc = new Button();
            label2 = new Label();
            tbOut2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            tbOut3 = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(12, 12);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(222, 39);
            dtpDate.TabIndex = 0;
            // 
            // btGet
            // 
            btGet.Location = new Point(285, 6);
            btGet.Name = "btGet";
            btGet.Size = new Size(103, 45);
            btGet.TabIndex = 1;
            btGet.Text = "計算";
            btGet.UseVisualStyleBackColor = true;
            btGet.Click += btGet_Click;
            // 
            // tbOut
            // 
            tbOut.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut.Location = new Point(96, 278);
            tbOut.Name = "tbOut";
            tbOut.Size = new Size(332, 39);
            tbOut.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(190, 84);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 4;
            label1.Text = "日後";
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(64, 82);
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 39);
            nudDay.TabIndex = 5;
            // 
            // dtpBirth
            // 
            dtpBirth.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpBirth.Location = new Point(12, 195);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(222, 39);
            dtpBirth.TabIndex = 6;
            // 
            // btBirthCalc
            // 
            btBirthCalc.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btBirthCalc.Location = new Point(252, 195);
            btBirthCalc.Name = "btBirthCalc";
            btBirthCalc.Size = new Size(75, 39);
            btBirthCalc.TabIndex = 7;
            btBirthCalc.Text = "計算";
            btBirthCalc.UseVisualStyleBackColor = true;
            btBirthCalc.Click += bt_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 177);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 8;
            label2.Text = "生年月日";
            // 
            // tbOut2
            // 
            tbOut2.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut2.Location = new Point(96, 346);
            tbOut2.Name = "tbOut2";
            tbOut2.Size = new Size(332, 39);
            tbOut2.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 302);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 10;
            label3.Text = "年齢";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 363);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 11;
            label4.Text = "経過日数";
            // 
            // tbOut3
            // 
            tbOut3.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut3.Location = new Point(96, 425);
            tbOut3.Multiline = true;
            tbOut3.Name = "tbOut3";
            tbOut3.Size = new Size(332, 87);
            tbOut3.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(66, 461);
            label5.Name = "label5";
            label5.Size = new Size(24, 15);
            label5.TabIndex = 11;
            label5.Text = "メモ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 757);
            Controls.Add(tbOut3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tbOut2);
            Controls.Add(label2);
            Controls.Add(btBirthCalc);
            Controls.Add(dtpBirth);
            Controls.Add(nudDay);
            Controls.Add(label1);
            Controls.Add(tbOut);
            Controls.Add(btGet);
            Controls.Add(dtpDate);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private Button btGet;
        private TextBox tbOut;
        private Label label1;
        private NumericUpDown nudDay;
        private DateTimePicker dtpBirth;
        private Button btBirthCalc;
        private Label label2;
        private TextBox tbOut2;
        private Label label3;
        private Label label4;
        private TextBox tbOut3;
        private Label label5;
    }
}
