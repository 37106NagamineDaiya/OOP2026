using Microsoft.Data.Sqlite;
using System.Xml.Schema;

namespace SQLiteProductSample;

public class ProductRepository
{
    //全商品を取得する。Read（SELECT）に相当する
    public List<Product> GetAll() {
        var products = new List<Product>();
        using var connection = Database.GetConnection();
        connection.Open();

        //SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        //Productsテーブルに作るSQL
        command.CommandText =
            """
            SELECT Id,Name,Price
            FROM Products
            ORDER BY Id;
            """;
        //SELECTを実行し、複数行の検索結果を読み取る
        using var reader = command.ExecuteReader();

        while (reader.Read()) {
            products.Add(new Product {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetInt32(2)
            });
           
        }
        return products;
    }

    public void Add(string name, int price) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
            """
            INSERT INTO Products (Name,Price)
            VALUES ($name,$price);
            """;

        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("&price", price);

        command.ExecuteNonQuery();
    }

    public void Update(Product product) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
            """
            UPDATE Products
            SET Name = $name,
                Price = $price
            WHERE Id = $id;
            """;

        command.Parameters.AddWithValue("$name",product.Name);
        command.Parameters.AddWithValue("$price",product.Price);
        command.Parameters.AddWithValue("$id",product.Id);

        command.ExecuteNonQuery();
    }

    public void Delete(int id) {
        using var connection = Database.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText =
            """
            DELETE FROM Products
            WHERE Id = $id;
            """;
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

}
