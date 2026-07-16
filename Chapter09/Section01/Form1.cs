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
            var culture = new CultureInfo("ja-JP");
            var dayOfWeek = culture.DateTimeFormat.GetShortestDayName(birth.DayOfWeek);
            DateTime nextBirthday = new DateTime(today.Year, birth.Month, birth.Day);

            TimeSpan diff = today - birth;
            tbOut2.Text = diff.Days.ToString();


            //int age = today.Year - birth.Year;
            //if (today < birth.AddYears(age)) {
            //    age--;
            //}
            
            tbOut.Text = $"‚ ‚È‚½‚Í{GetAge(birth,today)}Î‚Å‚·";

            tbOut3.Text = $"¶‚Ü‚ê‚½{birth.Month}ŒŽ{birth.Day}“ú‚Í‘æ{NthWeek(birth)}T‚Ì{dayOfWeek}—j“ú‚Å‚·";

            if(today.Month == birth.Month && today.Day == birth.Day) {
                tbOut4.Text = "’a¶“ú‚Í¡“ú‚Å‚·";
            } else if (nextBirthday < today) {
                nextBirthday = nextBirthday.AddYears(1);
                int days = (nextBirthday - today).Days;
                tbOut4.Text = $"ŽŸ‚Ì’a¶“ú‚Í—ˆ”N‚Å‚ ‚Æ{days}“úŒã‚Å‚·";
            } else {
                int days = (nextBirthday - today).Days;
                tbOut4.Text = $"ŽŸ‚Ì’a¶“ú‚Ü‚Å‚ ‚Æ{days}“ú‚Å‚·";
            }







        }

        static int GetAge(DateTime birthday,DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if(targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }

    }
}
