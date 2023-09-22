using midterm_project.Models;
using MySql.Data.MySqlClient;

namespace midterm_project.Repositories;



public class SqlPetRepository : IPetRepository
{

    private static string _myConnectionString = "server=127.0.0.1;uid=root;pwd=root;database=petdb";

    public Fish CreateFish(Fish newFish)
{
    var conn = new MySqlConnection(_myConnectionString);
    conn.Open();

    string query = "INSERT INTO fish (petName, description, color, url) VALUES ( @name, @description, @color, @url);";
    var command = new MySqlCommand(query, conn);

    command.Parameters.AddWithValue("@name", newFish.Name);
    command.Parameters.AddWithValue("@description", newFish.Description);
    command.Parameters.AddWithValue("@color", newFish.Color);
    command.Parameters.AddWithValue("@url", newFish.Url);
    command.Prepare();

    command.ExecuteNonQuery();
    int id = (int)command.LastInsertedId;
    conn.Close();

    if (id > 0)
    {
        newFish.Id = id;
    }

    return newFish;
}


  
    public void DeleteFishById(int Id)
    {
        var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
        conn.Open();

        string query = "DELETE FROM fish WHERE Id = @id;";
        var command = new MySqlCommand(query, conn);

        command.Parameters.AddWithValue("@id", Id);
        command.Prepare();

        command.ExecuteNonQuery();

        conn.Close();
    }

    public IEnumerable<Fish> GetAllFish()
    {
         var fishList = new List<Fish>();

    var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
    conn.Open();

    string query = "SELECT * FROM fish;";
    var command = new MySqlCommand(query, conn);
    var reader = command.ExecuteReader();

    while (reader.Read())
    {
        fishList.Add(new Fish {
            Id = reader.GetInt32("Id"),
            Name = reader.GetString("petName"),
            Description = reader.GetString("description"),
            Color = reader.GetString("color"),
            Url = reader.GetString("url")
        });
    }

    reader.Close();
    conn.Close();

    return fishList;
    }

    public Fish GetFishById(int Id)
    {
          Fish fish = null;

    var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
    conn.Open();

    string query = "SELECT * FROM fish WHERE Id = @id;";
    var command = new MySqlCommand(query, conn);

    command.Parameters.AddWithValue("@id", Id);
    command.Prepare();

    var reader = command.ExecuteReader();

    reader.Read();

    if (reader.HasRows) {
        fish = new Fish {
            Id = reader.GetInt32("Id"),
            Name = reader.GetString("petName"),
            Description = reader.GetString("description"),
            Color = reader.GetString("color"),
            Url = reader.GetString("url")
        };
    }      

    reader.Close();
    conn.Close();

    return fish;
    }

    public Fish UpdateFish(Fish newFish)
    {
         var conn = new MySql.Data.MySqlClient.MySqlConnection(_myConnectionString);
    conn.Open();

    string query = "UPDATE fish SET petName = @Name, description = @description, color = @color, url = @url " +
        "WHERE Id = @id";
    var command = new MySqlCommand(query, conn);

    command.Parameters.AddWithValue("@Name", newFish.Name);
    command.Parameters.AddWithValue("@description", newFish.Description);
    command.Parameters.AddWithValue("@color", newFish.Color);
    command.Parameters.AddWithValue("@url", newFish.Url);
    command.Parameters.AddWithValue("@id", newFish.Id);
    command.Prepare();

    command.ExecuteNonQuery();

    conn.Close();
    
    return newFish;
    } 
    }
