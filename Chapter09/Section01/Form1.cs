using System.Globalization;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            DateTime dt1 = dtpDate.Value;
            tbOut.Text = dt1.AddDays((double)nudDay.Value).ToString();


        }


        private void bt_Click(object sender, EventArgs e) {
            DateTime birth = dtpBirth.Value;
            DateTime today = DateTime.Today;

            TimeSpan diff = today - birth;
            tbOut2.Text = diff.Days.ToString();

            //int age = today.Year - birth.Year;
            //if (today < birth.AddYears(age)) {
            //    age--;
            //}
            
            tbOut.Text = $"‚ ‚È‚½‚Í{GetAge(birth,today)}Î‚Å‚·";
        }

        static int GetAge(DateTime birthday,DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if(targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }


    }
}
