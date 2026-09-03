using System.ComponentModel;

namespace CarReportSystem {
    [Serializable]
    internal class CarReport {
        
        //列挙型
        public enum MakerGroup {
            なし,
            トヨタ,
            日産,
            ホンダ,
            スバル,
            外車,
            その他,
        }
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("日付")]
        public DateTime Date { get; set; } //日付
        [DisplayName("記録者")]
        public string Author { get; set; } = string.Empty; //記録者
        [DisplayName("メーカー")]
        public MakerGroup Maker { get; set; } //メーカー
        [DisplayName("車名")]
        public string CarName { get; set; } = string.Empty; //車名
        [DisplayName("レポート")]
        public string Report { get; set; } = string.Empty; //レポート
        [DisplayName("画像")]
        public Image? Picture { get; set; } //画像
    }
}

