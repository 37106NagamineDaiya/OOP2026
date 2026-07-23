using System.ComponentModel;
using System.Windows.Forms.VisualStyles;
using static CarReportSystem.CarReport;
using System.Xml.Serialization;
using System.Xml;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのオブジェクトを生成
        Settings settings = new Settings();


        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = listCarReports;
        }

        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {
            tsslbMessage.Text = String.Empty;

            if (string.IsNullOrWhiteSpace(cbAuthor.Text) || string.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未記入です";
                return;
            }
            var carReport = new CarReport {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text.Trim(),
                Maker = getRadioButtonMaker(),
                CarName = cbCarName.Text.Trim(),
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);

            //入力履歴を登録
            SetCbAuthor(carReport.Author.Trim());
            SetCbCarName(carReport.CarName.Trim());

            dgvRecords.ClearSelection(); //セルの選択解除

            InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド

        }
        private MakerGroup getRadioButtonMaker() {
            if (rbToyota.Checked) {
                return MakerGroup.トヨタ;
            } else if (rbNissan.Checked) {
                return MakerGroup.日産;
            } else if (rbHonda.Checked) {
                return MakerGroup.ホンダ;
            } else if (rbSubaru.Checked) {
                return MakerGroup.スバル;
            } else if (rbImport.Checked) {
                return MakerGroup.外車;
            } else {
                return MakerGroup.その他;
            }
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
            cbAuthor.Text = String.Empty;
            rbOther.Checked = true;
            cbCarName.Text = String.Empty;
            tbReport.Text = String.Empty;
            pbPicture.Image = null;

            dgvRecords.ClearSelection(); //セルの選択解除
        }

        private void dgvRecords_Click(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow is null) || (!dgvRecords.CurrentRow.Selected)) return;

            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;
            SetRadioButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;

            InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
        }
        private void SetRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;

                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;

                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;

                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;

                case MakerGroup.外車:
                    rbImport.Checked = true;
                    break;

                default:
                    rbOther.Checked = true;
                    break;
            }


        }

        //記録者の入力履歴をコンボボックスへ登録(重複なし)
        private void SetCbAuthor(string author) {

            if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);

            }

        }
        //車名の入力履歴をコンボボックスへ登録(重複なし)
        private void SetCbCarName(string carName) {

            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }
        //削除したいインデックスを指定してリストから削除
        private void btDeleteRecord_Click(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow is null) || (!dgvRecords.CurrentRow.Selected)) return;

            listCarReports.RemoveAt(dgvRecords.CurrentRow.Index);
            InputItemsUpdate();
        }

        private void InputItemsUpdate() {
            if (!dgvRecords.CurrentRow.Selected)
                InputItemsAllClear();
        }

        private void btModifyRecord_Click(object sender, EventArgs e) {

            if (dgvRecords.SelectedRows.Count == 0) {
                tsslbMessage.Text = "修正するレポートを選択してください";
                return;
            }
            if (string.IsNullOrWhiteSpace(cbAuthor.Text) || string.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未記入です";
                return;
            }

            //カーレポート管理用リストの該当する要素のデータを書き換える
            if ((dgvRecords.CurrentRow is null) || (!dgvRecords.CurrentRow.Selected)) return;

            listCarReports[dgvRecords.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvRecords.CurrentRow.Index].Author = cbAuthor.Text.Trim();
            listCarReports[dgvRecords.CurrentRow.Index].Maker = getRadioButtonMaker();
            listCarReports[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text.Trim();
            listCarReports[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

            SetCbAuthor(cbAuthor.Text.Trim());
            SetCbCarName(cbCarName.Text.Trim());

            dgvRecords.Refresh();  //データグリッドビューの更新
            tsslbMessage.Text = "レポートを修正しました";
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {
            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport) || (!dgvRecords.CurrentRow.Selected)) return;

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

        private void button7_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdColor.Color;
            }
        }

        //フォームが閉じたら呼ばれるイベントハンドラ
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保存する処理(シリアル化)
            //P284以降を参考にする(ファイル名:setting.xml)
            using ( var writer = XmlWriter.Create("setting.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }
    }
}
