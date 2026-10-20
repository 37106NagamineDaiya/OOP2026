using System.Diagnostics;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            //Thread.Sleep(5000);
            //MessageBox.Show("Š®—¹");

            //await Task.Delay(5000);
            //MessageBox.Show("Š®—¹");

            //await Task.Run(() => DoLongTimeWork());

            //await DoLongTimeWorkAsync();
            //MessageBox.Show("Š®—¹");

            var elapsed = await DoLongTimeWorkAsync(4000);
            MessageBox.Show($"Š®—¹,{elapsed}ƒ~ƒŠ•b");

        }

        //private void DoLongTimeWork() {
        //    Thread.Sleep(5000);
        //}

        private async Task DoLongTimeWorkAsync() {
            await Task.Run(() => {
                Thread.Sleep(5000);

            });
        }

        private async Task<long> DoLongTimeWorkAsync(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                Thread.Sleep(5000);

            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
