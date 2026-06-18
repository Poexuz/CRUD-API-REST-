namespace Tp2.Service;
using Microsoft.Data.Sqlite;
using Tp2.Dto;
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
    Descripcion TEXT NOT NULL
    )";
    cmd.ExecuteNonQuery();
    } 

    public void CrearJuego(Juego juego){

        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        INSERT INTO Juego (Nombre, Descripcion)
        VALUES ($nombre, $descripcion);
        ";
        cmd.Parameters.AddWithValue("$nombre", juego.Nombre);   
        cmd.Parameters.AddWithValue("$descripcion", juego.Descripcion);
        cmd.ExecuteNonQuery();
    }

    public List<JuegosDto> ObtenerJuegos(){
        var listaJuegos = new List<JuegosDto>();

        using var cn = new SqliteConnection(_connection);
        cn.Open();

        using var cmd = cn.CreateCommand();
        cmd.CommandText=@"SELECT Nombre, Descripcion FROM Juego";
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            var juego = new Juego{
                Nombre = reader.GetString(0),
                Descripcion = reader.GetString(1),
            };
            listaJuegos.Add(new JuegosDto(juego));
        }
        return listaJuegos;
    }


    public void UpdateJuego(Juego juego){
        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        UPDATE Juego
        SET Nombre = $nombre, Descripcion = $descripcion
        WHERE Id = $id;
        ";
        cmd.Parameters.AddWithValue("$id", juego.Id);
        cmd.Parameters.AddWithValue("$nombre", juego.Nombre);   
        cmd.Parameters.AddWithValue("$descripcion", juego.Descripcion);
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



}