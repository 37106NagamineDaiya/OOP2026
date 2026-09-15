using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;


namespace CarReportSystem {
    public partial class Form1 : Form {

        // カーレポート管理用リスト
        BindingList<CarReport> listCarReports =
            new BindingList<CarReport>();

        // DB操作用
        private readonly CarReportRepository repository =
            new CarReportRepository();

        public Form1() {
            InitializeComponent();

            // DataGridViewの自動列生成
            dgvRecords.AutoGenerateColumns = true;

            // DBからカーレポートを読み込む
            ReloadCarReport();

            // 使用中のDB
            tsslbMessage.Text = $"DB: {Database.FilePath}";

            // BindingListをDataGridViewに設定
            dgvRecords.DataSource = listCarReports;
        }

        private void ReloadCarReport() {
            listCarReports.Clear();

            var reports = repository.GetAll();

            foreach (var report in reports) {
                listCarReports.Add(report);

            }
        }




        private void Form1_Load(object sender, EventArgs e) {
            //設定ファイルを読み込み背景色を設定する（逆シリアル化）

            //ファイルが存在するか？
            if (File.Exists("setting.xml")) {
                try {
                    Settings.Instance.Load();
                    BackColor = Color.FromArgb(Settings.Instance.MainFormBackColor);
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "設定ファイル読み込みエラー";
                    MessageBox.Show(ex.Message);//←より具体的なエラーを出力         
                }
            } else {
                tsslbMessage.Text = "設定ファイルがありません";
            }
        }

        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {
            tsslbMessage.Text = string.Empty;

            if (String.IsNullOrWhiteSpace(cbAuthor.Text) ||
                String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            try {
                repository.Add(
                    dtpDate.Value.Date,
                    cbAuthor.Text.Trim(),
                    GetRadioButtonMaker(),
                    cbCarName.Text.Trim(),
                    tbReport.Text,
                    pbPicture.Image);


                ReloadCarReport();

                SetCbAuthor(cbAuthor.Text.Trim());
                SetCbCarName(cbCarName.Text.Trim());

                InputItemsAllClear();

                tsslbMessage.Text = "レポートを保存しました";
            }
            catch (Exception ex) {
                tsslbMessage.Text = "保存に失敗しました";
                MessageBox.Show(
                    ex.Message,
                    "保存エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


            }
        }




        private MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbImport.Checked)
                return MakerGroup.外車;

            return MakerGroup.その他;
        }
        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }
        private void btNewInput_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;

            dgvRecords.ClearSelection();//セルの選択を解除する
        }

        private void SetRadioButtonMaker(MakerGroup targetMaker) {

            switch (targetMaker) {

                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.外車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }
        //記録者の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCbAuthor(string author) {
            //未登録なら登録【登録済みなら何もしない】
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }
        //車名の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCbCarName(string carName) {
            //未登録なら登録【登録済みなら何もしない】
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);

        }
        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }
        private void btDeleteRecord_Click(object sender, EventArgs e) {
            if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport selectedReport) {
                tsslbMessage.Text = "削除するレポートを選択してください";
                return;
            }

            if (MessageBox.Show(
                    $"{selectedReport.CarName}のレポートを削除しますか？",
                    "削除確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            }

            try {
                // DBから削除
                repository.Delete(selectedReport.Id);

                // DBから再読み込み
                ReloadCarReport();

                InputItemsAllClear();

                tsslbMessage.Text = "レポートを削除しました";
            }
            catch (Exception ex) {
                tsslbMessage.Text = "削除に失敗しました";
                MessageBox.Show(
                    ex.Message,
                    "削除エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        //データグリッドビューを更新したら呼ぶメソッド
        private void InputItemsUpdate() {
            if (dgvRecords.CurrentRow is null || !dgvRecords.CurrentRow.Selected)
                InputItemsAllClear();
        }
        private void btModifyRecord_Click(object sender, EventArgs e) {
            if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport selectedReport) {
                tsslbMessage.Text = "修正するレポートを選択してください";
                return;
            }

            if (String.IsNullOrWhiteSpace(cbAuthor.Text) ||
                String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            try {
                // 選択されたレポートの内容を変更
                selectedReport.Date = dtpDate.Value.Date;
                selectedReport.Author = cbAuthor.Text.Trim();
                selectedReport.Maker = GetRadioButtonMaker();
                selectedReport.CarName = cbCarName.Text.Trim();
                selectedReport.Report = tbReport.Text;
                selectedReport.Picture = pbPicture.Image;

                // DBを更新
                repository.Update(selectedReport);

                // DBから再読み込み
                ReloadCarReport();

                SetCbAuthor(cbAuthor.Text.Trim());
                SetCbCarName(cbCarName.Text.Trim());

                InputItemsAllClear();

                tsslbMessage.Text = "レポートを修正しました";
            }
            catch (Exception ex) {
                tsslbMessage.Text = "修正に失敗しました";
                MessageBox.Show(
                    ex.Message,
                    "修正エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
                    || (!dgvRecords.CurrentRow.Selected)) return;

            dtpDate.Value = carReport.Date;
            cbAuthor.Text = carReport.Author;
            SetRadioButtonMaker(carReport.Maker);
            cbCarName.Text = carReport.CarName;
            tbReport.Text = carReport.Report;
            pbPicture.Image = carReport.Picture;

            InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                //変更された色の情報を保存
                Settings.Instance.MainFormBackColor = cdColor.Color.ToArgb();
            }
        }

        //フォームが閉じたら呼ばれるイベントハンドラ
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保存する処理（シリアル化）
            //P284以降を参考にする（ファイル名：setting.xml）

            Settings.Instance.Save();


        }

        private void このアプリについてToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(
                "Car Report System\n\n" +
                "【アプリ概要】\n" +
                "自動車に関するレポートを登録・管理するためのアプリです。\n\n" +
                "【主な機能】\n" +
                "・カーレポートの登録\n" +
                "・登録したレポートの修正・削除\n" +
                "・メーカーや車名の管理\n" +
                "・車両写真の登録\n" +
                "・レポート情報のデータベース保存\n\n" +
                "【バージョン】\n" +
                "Version 1.0\n\n" +
                "Car Report Systemを利用して、\n" +
                "車に関する情報を簡単に管理できます。",

                "このアプリについて",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


    }
}
