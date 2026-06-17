namespace Tp2.Service;
<<<<<<< HEAD
using Tp2.Models;
public class JuegosService
{
=======
using Microsoft.Data.Sqlite;
using Tp2.Models;
public class JuegoService  {
    string _connection = "Data Source=BD/Juego.db";

    public JuegoService(){
    using var cn = new SqliteConnection(_connection);
    cn.Open(); 
    
    using var cmd = cn.CreateCommand();
    cmd.CommandText=@"
    CREATE TABLE IF NOT EXISTS Juego(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL,
    Descripcion TEXT NOT NULL,
    Costo INTEGER NOT NULL
    )";
    cmd.ExecuteNonQuery();
    } 

    public void CrearJuego(Juego juego){

        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        INSERT INTO Juego (Nombre, Descripcion, Costo)
        VALUES ($nombre, $descripcion, $costo);
        ";
        cmd.Parameters.AddWithValue("$nombre", juego.Nombre);   
        cmd.Parameters.AddWithValue("$descripcion", juego.Descripcion);
        cmd.Parameters.AddWithValue("$costo", juego.Costo);
        cmd.ExecuteNonQuery();
    }

    public List<Juego> ObtenerJuegos(){
        var listaJuegos = new List<Juego>();

        using var cn = new SqliteConnection(_connection);
        cn.Open();

        using var cmd = cn.CreateCommand();
        cmd.CommandText=@"SELECT Id, Nombre, Descripcion, Costo FROM Juego";
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            listaJuegos.Add(new Juego{
            Id= reader.GetInt32(0),
            Nombre=reader.GetString(1),
            Descripcion=reader.GetString(2),
            Costo=reader.GetInt32(3)
            });
        }
        return listaJuegos;
    }


    public void UpdateJuego(Juego juego){
        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        UPDATE Juego
        SET Nombre = $nombre, Descripcion = $descripcion, Costo = $costo
        WHERE Id = $id;
        ";
        cmd.Parameters.AddWithValue("$id", juego.Id);
        cmd.Parameters.AddWithValue("$nombre", juego.Nombre);   
        cmd.Parameters.AddWithValue("$descripcion", juego.Descripcion);
        cmd.Parameters.AddWithValue("$costo", juego.Costo);
        cmd.ExecuteNonQuery();
    }

    public void DeleteJuego(int id){
        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        DELETE FROM Juego
        WHERE Id = $id;
        ";
        cmd.Parameters.AddWithValue("$id", id);
        cmd.ExecuteNonQuery();
    }

>>>>>>> origin/Miguel

}