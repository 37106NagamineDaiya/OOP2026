namespace CarReportSystem {
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
            label1 = new Label();
            dtpDate = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            rbOther = new RadioButton();
            rbImport = new RadioButton();
            rbSubaru = new RadioButton();
            rbHonda = new RadioButton();
            rbNissan = new RadioButton();
            rbToyota = new RadioButton();
            cbAuthor = new ComboBox();
            label4 = new Label();
            cbCarName = new ComboBox();
            label5 = new Label();
            dgvRecords = new DataGridView();
            tbReport = new TextBox();
            label6 = new Label();
            btNewInput = new Button();
            label7 = new Label();
            btOpenPicture = new Button();
            btDeletePicture = new Button();
            btAddRecord = new Button();
            btModifyRecord = new Button();
            btDeleteRecord = new Button();
            pbPicture = new PictureBox();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            menuStrip1 = new MenuStrip();
            ファイルFToolStripMenuItem = new ToolStripMenuItem();
            開くToolStripMenuItem = new ToolStripMenuItem();
            保存ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            色設定ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            終了ToolStripMenuItem = new ToolStripMenuItem();
            ヘルプHToolStripMenuItem = new ToolStripMenuItem();
            このアプリについてToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            tsslbMessage = new ToolStripStatusLabel();
            ofdPicFileOpen = new OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(37, 40);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(105, 35);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 39);
            dtpDate.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(13, 93);
            label2.Name = "label2";
            label2.Size = new Size(86, 32);
            label2.TabIndex = 2;
            label2.Text = "記録者";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(20, 145);
            label3.Name = "label3";
            label3.Size = new Size(79, 32);
            label3.TabIndex = 3;
            label3.Text = "メーカー";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbOther);
            groupBox1.Controls.Add(rbImport);
            groupBox1.Controls.Add(rbSubaru);
            groupBox1.Controls.Add(rbHonda);
            groupBox1.Controls.Add(rbNissan);
            groupBox1.Controls.Add(rbToyota);
            groupBox1.Location = new Point(105, 145);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(372, 52);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // rbOther
            // 
            rbOther.AutoSize = true;
            rbOther.Location = new Point(293, 22);
            rbOther.Name = "rbOther";
            rbOther.Size = new Size(56, 19);
            rbOther.TabIndex = 0;
            rbOther.TabStop = true;
            rbOther.Text = "その他";
            rbOther.UseVisualStyleBackColor = true;
            // 
            // rbImport
            // 
            rbImport.AutoSize = true;
            rbImport.Location = new Point(239, 22);
            rbImport.Name = "rbImport";
            rbImport.Size = new Size(49, 19);
            rbImport.TabIndex = 0;
            rbImport.TabStop = true;
            rbImport.Text = "外車";
            rbImport.UseVisualStyleBackColor = true;
            // 
            // rbSubaru
            // 
            rbSubaru.AutoSize = true;
            rbSubaru.Location = new Point(179, 22);
            rbSubaru.Name = "rbSubaru";
            rbSubaru.Size = new Size(54, 19);
            rbSubaru.TabIndex = 0;
            rbSubaru.TabStop = true;
            rbSubaru.Text = "スバル";
            rbSubaru.UseVisualStyleBackColor = true;
            // 
            // rbHonda
            // 
            rbHonda.AutoSize = true;
            rbHonda.Location = new Point(120, 22);
            rbHonda.Name = "rbHonda";
            rbHonda.Size = new Size(53, 19);
            rbHonda.TabIndex = 0;
            rbHonda.TabStop = true;
            rbHonda.Text = "ホンダ";
            rbHonda.UseVisualStyleBackColor = true;
            // 
            // rbNissan
            // 
            rbNissan.AutoSize = true;
            rbNissan.Location = new Point(65, 22);
            rbNissan.Name = "rbNissan";
            rbNissan.Size = new Size(49, 19);
            rbNissan.TabIndex = 0;
            rbNissan.TabStop = true;
            rbNissan.Text = "日産";
            rbNissan.UseVisualStyleBackColor = true;
            // 
            // rbToyota
            // 
            rbToyota.AutoSize = true;
            rbToyota.Location = new Point(9, 23);
            rbToyota.Name = "rbToyota";
            rbToyota.Size = new Size(50, 19);
            rbToyota.TabIndex = 0;
            rbToyota.TabStop = true;
            rbToyota.Text = "トヨタ";
            rbToyota.UseVisualStyleBackColor = true;
            // 
            // cbAuthor
            // 
            cbAuthor.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(105, 93);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(233, 40);
            cbAuthor.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(37, 220);
            label4.Name = "label4";
            label4.Size = new Size(62, 32);
            label4.TabIndex = 2;
            label4.Text = "車名";
            // 
            // cbCarName
            // 
            cbCarName.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbCarName.FormattingEnabled = true;
            cbCarName.Location = new Point(105, 217);
            cbCarName.Name = "cbCarName";
            cbCarName.Size = new Size(233, 40);
            cbCarName.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(37, 485);
            label5.Name = "label5";
            label5.Size = new Size(62, 32);
            label5.TabIndex = 2;
            label5.Text = "一覧";
            // 
            // dgvRecords
            // 
            dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecords.Location = new Point(105, 500);
            dgvRecords.MultiSelect = false;
            dgvRecords.Name = "dgvRecords";
            dgvRecords.ReadOnly = true;
            dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecords.Size = new Size(752, 250);
            dgvRecords.TabIndex = 6;
            dgvRecords.Click += dgvRecords_Click;
            // 
            // tbReport
            // 
            tbReport.Location = new Point(105, 294);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(405, 164);
            tbReport.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(16, 294);
            label6.Name = "label6";
            label6.Size = new Size(83, 32);
            label6.TabIndex = 2;
            label6.Text = "レポート";
            // 
            // btNewInput
            // 
            btNewInput.BackColor = SystemColors.GradientInactiveCaption;
            btNewInput.Location = new Point(333, 35);
            btNewInput.Name = "btNewInput";
            btNewInput.Size = new Size(101, 39);
            btNewInput.TabIndex = 8;
            btNewInput.Text = "新規入力";
            btNewInput.UseVisualStyleBackColor = false;
            btNewInput.Click += btNewInput_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(525, 46);
            label7.Name = "label7";
            label7.Size = new Size(62, 32);
            label7.TabIndex = 0;
            label7.Text = "画像";
            // 
            // btOpenPicture
            // 
            btOpenPicture.BackColor = SystemColors.GradientActiveCaption;
            btOpenPicture.Location = new Point(614, 44);
            btOpenPicture.Name = "btOpenPicture";
            btOpenPicture.Size = new Size(101, 34);
            btOpenPicture.TabIndex = 8;
            btOpenPicture.Text = "開く";
            btOpenPicture.UseVisualStyleBackColor = false;
            btOpenPicture.Click += btOpenPicture_Click;
            // 
            // btDeletePicture
            // 
            btDeletePicture.BackColor = Color.Tomato;
            btDeletePicture.Location = new Point(747, 44);
            btDeletePicture.Name = "btDeletePicture";
            btDeletePicture.Size = new Size(97, 34);
            btDeletePicture.TabIndex = 8;
            btDeletePicture.Text = "削除";
            btDeletePicture.UseVisualStyleBackColor = false;
            // 
            // btAddRecord
            // 
            btAddRecord.BackColor = Color.LightGreen;
            btAddRecord.Location = new Point(542, 424);
            btAddRecord.Name = "btAddRecord";
            btAddRecord.Size = new Size(123, 34);
            btAddRecord.TabIndex = 8;
            btAddRecord.Text = "追加";
            btAddRecord.UseVisualStyleBackColor = false;
            btAddRecord.Click += btAddRecord_Click;
            // 
            // btModifyRecord
            // 
            btModifyRecord.BackColor = Color.LightGoldenrodYellow;
            btModifyRecord.Location = new Point(671, 424);
            btModifyRecord.Name = "btModifyRecord";
            btModifyRecord.Size = new Size(101, 34);
            btModifyRecord.TabIndex = 8;
            btModifyRecord.Text = "修正";
            btModifyRecord.UseVisualStyleBackColor = false;
            // 
            // btDeleteRecord
            // 
            btDeleteRecord.BackColor = Color.Tomato;
            btDeleteRecord.Location = new Point(778, 424);
            btDeleteRecord.Name = "btDeleteRecord";
            btDeleteRecord.Size = new Size(75, 34);
            btDeleteRecord.TabIndex = 8;
            btDeleteRecord.Text = "削除";
            btDeleteRecord.UseVisualStyleBackColor = false;
            // 
            // pbPicture
            // 
            pbPicture.BorderStyle = BorderStyle.FixedSingle;
            pbPicture.Location = new Point(542, 93);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(311, 312);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.TabIndex = 9;
            pbPicture.TabStop = false;
            // 
            // button7
            // 
            button7.Location = new Point(756, 756);
            button7.Name = "button7";
            button7.Size = new Size(101, 34);
            button7.TabIndex = 8;
            button7.Text = "終了";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.BackColor = SystemColors.GradientActiveCaption;
            button8.Location = new Point(37, 538);
            button8.Name = "button8";
            button8.Size = new Size(62, 34);
            button8.TabIndex = 8;
            button8.Text = "開く";
            button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.BackColor = Color.PaleGreen;
            button9.Location = new Point(37, 578);
            button9.Name = "button9";
            button9.Size = new Size(62, 34);
            button9.TabIndex = 8;
            button9.Text = "保存";
            button9.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルFToolStripMenuItem, ヘルプHToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(888, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            ファイルFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 開くToolStripMenuItem, 保存ToolStripMenuItem, toolStripSeparator1, 色設定ToolStripMenuItem, toolStripSeparator2, 終了ToolStripMenuItem });
            ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            ファイルFToolStripMenuItem.Size = new Size(67, 20);
            ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 開くToolStripMenuItem
            // 
            開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            開くToolStripMenuItem.Size = new Size(155, 22);
            開くToolStripMenuItem.Text = "開く...";
            // 
            // 保存ToolStripMenuItem
            // 
            保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            保存ToolStripMenuItem.Size = new Size(155, 22);
            保存ToolStripMenuItem.Text = "保存...";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(152, 6);
            // 
            // 色設定ToolStripMenuItem
            // 
            色設定ToolStripMenuItem.Name = "色設定ToolStripMenuItem";
            色設定ToolStripMenuItem.Size = new Size(155, 22);
            色設定ToolStripMenuItem.Text = "色設定...";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(152, 6);
            // 
            // 終了ToolStripMenuItem
            // 
            終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            終了ToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            終了ToolStripMenuItem.Size = new Size(155, 22);
            終了ToolStripMenuItem.Text = "終了(&X)";
            // 
            // ヘルプHToolStripMenuItem
            // 
            ヘルプHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { このアプリについてToolStripMenuItem });
            ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            ヘルプHToolStripMenuItem.Size = new Size(65, 20);
            ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // このアプリについてToolStripMenuItem
            // 
            このアプリについてToolStripMenuItem.Name = "このアプリについてToolStripMenuItem";
            このアプリについてToolStripMenuItem.Size = new Size(164, 22);
            このアプリについてToolStripMenuItem.Text = "このアプリについて...";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslbMessage });
            statusStrip1.Location = new Point(0, 794);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(888, 22);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslbMessage
            // 
            tsslbMessage.Name = "tsslbMessage";
            tsslbMessage.Size = new Size(0, 17);
            // 
            // ofdPicFileOpen
            // 
            ofdPicFileOpen.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 816);
            Controls.Add(statusStrip1);
            Controls.Add(pbPicture);
            Controls.Add(button7);
            Controls.Add(btDeleteRecord);
            Controls.Add(button9);
            Controls.Add(btDeletePicture);
            Controls.Add(btModifyRecord);
            Controls.Add(btAddRecord);
            Controls.Add(button8);
            Controls.Add(btOpenPicture);
            Controls.Add(btNewInput);
            Controls.Add(tbReport);
            Controls.Add(dgvRecords);
            Controls.Add(cbCarName);
            Controls.Add(cbAuthor);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(dtpDate);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "試乗レポート管理システム";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDate;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private RadioButton rbOther;
        private RadioButton rbImport;
        private RadioButton rbSubaru;
        private RadioButton rbHonda;
        private RadioButton rbNissan;
        private RadioButton rbToyota;
        private ComboBox cbAuthor;
        private Label label4;
        private ComboBox cbCarName;
        private Label label5;
        private DataGridView dgvRecords;
        private TextBox tbReport;
        private Label label6;
        private Button btNewInput;
        private Label label7;
        private Button btOpenPicture;
        private Button btDeletePicture;
        private Button btAddRecord;
        private Button btModifyRecord;
        private Button btDeleteRecord;
        private PictureBox pbPicture;
        private Button button7;
        private Button button8;
        private Button button9;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルFToolStripMenuItem;
        private ToolStripMenuItem 開くToolStripMenuItem;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 色設定ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem 終了ToolStripMenuItem;
        private ToolStripMenuItem ヘルプHToolStripMenuItem;
        private ToolStripMenuItem このアプリについてToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslbMessage;
        private OpenFileDialog ofdPicFileOpen;
    }
}
