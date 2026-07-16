using System.ComponentModel;
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
            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;
            
            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;
        }
    }
}
