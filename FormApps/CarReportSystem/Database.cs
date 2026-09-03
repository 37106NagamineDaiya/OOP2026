using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    internal class Database {
        //DBファイルの保存場所
        private static readonly string DatabasePath =
            Path.Combine(AppContext.BaseDirectory, "carreport.db");

        //SQLiteへ接続するための接続文字列
        private static readonly string ConnectionString =
            $"Data Source = {DatabasePath}";

        //新しいSQLiteConnectionを生成して返す
        public static SqliteConnection GetConnection()
            => new SqliteConnection(ConnectionString);

        //DBの初期化処理
        public static void Initialize() {
            //接続オブジェクトを生成する。
            using var connection = GetConnection();
            //DBを開く
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                """
            CREATE TABLE IF NOT EXISTS CarReports (
                Id      INTEGER PRIMARY KEY AUTOINCREMENT,
                Date    TEXT NOT NULL,
                Author  TEXT NOT NULL,
                Maker   INTEGER NOT NULL,
                CarName TEXT NOT NULL,
                Report  TEXT NOT NULL,
                Picture BLOB
            );
            """;

            //結果行を返さないSQLを実行する
            command.ExecuteNonQuery();

        }
    }
}
