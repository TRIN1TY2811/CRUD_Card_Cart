using System.Collections.Generic;
using Data_Logic_Layer;
using Microsoft.Data.SqlClient;
using Model_Layer;

public class SqlData : IDataService
{
    string connectionString =
    "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=CRUD_Cart_Card_DB;Integrated Security=True;TrustServerCertificate=True;";

    // card
    public List<Models.Cards> cardlist => GetCards();
    public List<Models.Carts> cartlist => GetCarts();

    public List<Models.Cards> GetCards()
    {
        var list = new List<Models.Cards>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Cards", conn);
            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Models.Cards
                {
                    ID = Convert.ToInt32(reader["CardId"]),
                    Name = reader["Name"].ToString() ?? ""
                });
            }
        }

        return list;
    }

    public string AddCard(int id, string name)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Cards (CardId, Name) VALUES (@id,@name)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name ?? "");

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        return "Card added successfully!";
    }

    public string DeleteCard(int choice)
    {
        var list = GetCards();
        if (choice < 1 || choice > list.Count) return "Invalid selection.";

        int id = list[choice - 1].ID;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Cards WHERE CardId=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        return "Card deleted successfully!";
    }

    public string UpdateCard(int choice, string name, int id)
    {
        var list = GetCards();
        if (choice < 1 || choice > list.Count) return "Invalid selection.";

        int oldId = list[choice - 1].ID;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE Cards SET CardId=@newId, Name=@name WHERE CardId=@oldId", conn);

            cmd.Parameters.AddWithValue("@newId", id);
            cmd.Parameters.AddWithValue("@name", name ?? "");
            cmd.Parameters.AddWithValue("@oldId", oldId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        return "Card updated successfully!";
    }

    // cart

    public List<Models.Carts> GetCarts()
    {
        var list = new List<Models.Carts>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Carts", conn);
            conn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Models.Carts
                {
                    Name = reader["Name"].ToString() ?? "",
                    Price = Convert.ToDecimal(reader["Price"]),
                    Quantity = Convert.ToInt32(reader["Quantity"])
                });
            }
        }

        return list;
    }

    public string AddCart(string name, decimal price, int quantity)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Carts (Name, Price, Quantity) VALUES (@n,@p,@q)", conn);

            cmd.Parameters.AddWithValue("@n", name ?? "");
            cmd.Parameters.AddWithValue("@p", price);
            cmd.Parameters.AddWithValue("@q", quantity);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        return "Product added successfully!";
    }

    public string DeleteCart(int choice)
    {
        var list = GetCarts();
        if (choice < 1 || choice > list.Count) return "Invalid selection.";

        string name = list[choice - 1].Name;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Carts WHERE Name=@n", conn);
            cmd.Parameters.AddWithValue("@n", name);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        return "Product deleted successfully!";
    }

    public string UpdateCart(int choice, string name, decimal price, int quantity)
    {
        var list = GetCarts();
        if (choice < 1 || choice > list.Count) return "Invalid selection.";

        string oldName = list[choice - 1].Name;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE Carts SET Name=@n, Price=@p, Quantity=@q WHERE Name=@old", conn);

            cmd.Parameters.AddWithValue("@n", name ?? "");
            cmd.Parameters.AddWithValue("@p", price);
            cmd.Parameters.AddWithValue("@q", quantity);
            cmd.Parameters.AddWithValue("@old", oldName);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        return "Product updated successfully!";
    }
}