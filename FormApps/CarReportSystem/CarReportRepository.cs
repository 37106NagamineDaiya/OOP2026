using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    internal class CarReportRepository {
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
            FROM CarRepors
            ORDER BY Id;
            """;
            //SELECTを実行し、複数行の検索結果を読み取る
            using var reader = command.ExecuteReader();

            while (reader.Read()) {
                carReports.Add(new CarReport {
                    Id = reader.GetInt32(0),
                    Date = reader.GetDateTime(1),
                    Author = reader.GetString(2),
                    Maker = (CarReport.MakerGroup)reader.GetInt32(3),
                    CarName = reader.GetString(4),
                    Report = reader.GetString(5),
                    Picture = null
                });

            }
            return carReports;
        }
    }
}
