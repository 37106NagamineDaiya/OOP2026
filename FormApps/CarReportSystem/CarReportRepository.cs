using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    internal class CarReportRepository {
        // ImageをSQLiteへ保存できるbyte[]へ変換する
        private static byte[]? ImageToBytes(Image? image) {
            if (image is null)
                return null;

            using var stream = new MemoryStream();

            // DBへはPNG形式で保存
            image.Save(stream, ImageFormat.Png);

            return stream.ToArray();
        }

        // SQLiteのBLOB（byte[]）をImageへ変換する
        private static Image BytesToImage(byte[] data) {
            using var stream = new MemoryStream(data);
            using var image = Image.FromStream(stream);

            // MemoryStream破棄後も利用できるようBitmapとしてコピーする
            return new Bitmap(image);
        }


        //全商品を取得する。Read（SELECT）に相当する
        public List<CarReport> GetAll() {
            var carReports = new List<CarReport>();
            using var connection = Database.GetConnection();
            connection.Open();

            //SQLを実行するためのコマンドオブジェクトを作る
            using var command = connection.CreateCommand();

            //Productsテーブルに作るSQL
            command.CommandText =
                """
            SELECT Id,Date,Author,Maker,CarName,Report,Picture
            FROM CarReports
            ORDER BY Id;
            """;
            //SELECTを実行し、複数行の検索結果を読み取る
            using var reader = command.ExecuteReader();

            while (reader.Read()) {
                Image? picture = null;

                if (!reader.IsDBNull(6)) {
                    byte[] data = (byte[])reader["Picture"];
                    picture = BytesToImage(data);
                }

                carReports.Add(new CarReport {
                    Id = reader.GetInt32(0),
                    Date = DateTime.Parse(reader.GetString(1)),
                    Author = reader.GetString(2),
                    Maker = (CarReport.MakerGroup)reader.GetInt32(3),
                    CarName = reader.GetString(4),
                    Report = reader.GetString(5),
                    Picture = picture
                });
            }
            return carReports;
        }
        public void Add(DateTime date, string author, CarReport.MakerGroup maker,string carName,string report,Image picture) {
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                """
            INSERT INTO CarReports
            (Date,Author,Maker,CarName,Report,Picture)
            VALUES
            ($date,$author,$maker,$carName,$report,$picture);

            SELECT last_insert_rowid();
            """;

            command.Parameters.AddWithValue(
                "$date",
                date.ToString("yyyy-MM-dd HH:mm:ss"));

            command.Parameters.AddWithValue("$author", author);
            command.Parameters.AddWithValue("$maker", (int)maker);
            command.Parameters.AddWithValue("$carName", carName);
            command.Parameters.AddWithValue("$report", report);

            byte[]? pictureData = ImageToBytes(picture);

            command.Parameters.AddWithValue(
                "$picture",
                pictureData ?? (object)DBNull.Value);

            command.ExecuteNonQuery();


        }

        public void Update(CarReport carReport) {
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                """
            UPDATE CarReports
            SET Date = $date,Author = $author,Maker = $maker,
                CarName = $carName,Report = $report,Picture = $picture
            WHERE Id = $id;
            """;

            command.Parameters.AddWithValue(
                "$date",
                carReport.Date.ToString("yyyy-MM-dd HH:mm:ss"));

            command.Parameters.AddWithValue("$author", carReport.Author);
            command.Parameters.AddWithValue("$maker", (int)carReport.Maker);
            command.Parameters.AddWithValue("$carName", carReport.CarName);
            command.Parameters.AddWithValue("$report", carReport.Report);

            byte[]? pictureData = ImageToBytes(carReport.Picture);

            command.Parameters.AddWithValue(
                "$picture",
                pictureData ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("$id", carReport.Id);

            command.ExecuteNonQuery();
        }

        public void Delete(int id) {
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                """
            DELETE FROM CarReports
            WHERE Id = $id;
            """;
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
        }
    }
}
