using System.ComponentModel;
using System.Windows.Forms.VisualStyles;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();


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
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = getRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);
            SetCbAuthor(carReport.Author);
            SetCbCarName(carReport.CarName);
            InputItemsAllClear();  //入力項目の全クリア

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
        }

        private void dgvRecords_Click(object sender, EventArgs e) {

            if(dgvRecords.CurrentRow is null ) return;

            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;
            SetRadioButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;
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
    }
}
