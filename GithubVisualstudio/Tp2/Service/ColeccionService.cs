namespace Tp2.Service;
using Microsoft.Data.Sqlite;
using Tp2.Models;
using Tp2.Dto;
public class ColeccionService
{

    string _connection = "Data Source=BD/Juego.db";

    // Crear la tabla de coleccion si no existe.
    public ColeccionService()
    {
        using var cn = new SqliteConnection(_connection);
        cn.Open(); 
    
        using var cmd = cn.CreateCommand();
        cmd.CommandText=@"
        CREATE TABLE IF NOT EXISTS Coleccion(
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        UsuarioId INTEGER NOT NULL,
        JuegoId INTEGER NOT NULL,
        CONSTRAINT UsuarioId FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id),
        CONSTRAINT JuegoId FOREIGN KEY (JuegoId) REFERENCES Juego(Id)
        )";
        cmd.ExecuteNonQuery();
        }
    

    // Crear una coleccion con la id del juego y del usuario.
    public void CrearColeccion(Coleccion coleccion){
        
        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        INSERT INTO Coleccion (UsuarioId, JuegoId)
        VALUES ($usuarioId, $juegoId);
        ";
        cmd.Parameters.AddWithValue("$usuarioId", coleccion.UsuarioId);   
        cmd.Parameters.AddWithValue("$juegoId", coleccion.JuegoId);
        cmd.ExecuteNonQuery();
    }

    // Obtener el contenido de coleccion por usuario.
    public List<ColeccionDto> ObtenerColeccion(){
        var listaColeccion = new List<ColeccionDto>();

        using var cn = new SqliteConnection(_connection);
        cn.Open();

        using var cmd = cn.CreateCommand();
        cmd.CommandText=@"
            SELECT u.Nombre, j.Nombre
            FROM Coleccion c
            JOIN Usuario u ON c.UsuarioId = u.Id
            JOIN Juego j ON c.JuegoId = j.Id";
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            var usuario = new Usuario{
                Nombre = reader.GetString(0)
            };
            var juego = new Juego{
                Nombre = reader.GetString(1)
            };
            listaColeccion.Add(new ColeccionDto(usuario, juego));
        }
        return listaColeccion;
    }

    // Obtener coleccion por id de usuario.
    public List<ColeccionDto> ObtenerColeccionUsuario(int usuarioId){
        var listaColeccion = new List<ColeccionDto>();

        using var cn = new SqliteConnection(_connection);
        cn.Open();

        using var cmd = cn.CreateCommand();
        cmd.CommandText=@"
            SELECT u.Nombre, j.Nombre
            FROM Coleccion c
            JOIN Usuario u ON c.UsuarioId = u.Id
            JOIN Juego j ON c.JuegoId = j.Id
            WHERE c.UsuarioId = $usuarioId";
        cmd.Parameters.AddWithValue("$usuarioId", usuarioId);
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            var usuario = new Usuario{
                Nombre = reader.GetString(0)
            };
            var juego = new Juego{
                Nombre = reader.GetString(1)
            };
            listaColeccion.Add(new ColeccionDto(usuario, juego));
        }
        return listaColeccion;
    }

    // Obtener coleccion por id de Juego.
    public List<ColeccionDto> ObtenerColeccionJuego(int juegoId){
        var listaColeccion = new List<ColeccionDto>();

        using var cn = new SqliteConnection(_connection);
        cn.Open();

        using var cmd = cn.CreateCommand();
        cmd.CommandText=@"
            SELECT u.Nombre, j.Nombre
            FROM Coleccion c
            JOIN Usuario u ON c.UsuarioId = u.Id
            JOIN Juego j ON c.JuegoId = j.Id
            WHERE c.JuegoId = $juegoId";
        cmd.Parameters.AddWithValue("$juegoId", juegoId);
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            var usuario = new Usuario{
                Nombre = reader.GetString(0)
            };
            var juego = new Juego{
                Nombre = reader.GetString(1)
            };
            listaColeccion.Add(new ColeccionDto(usuario, juego));
        }
        return listaColeccion;
    }

    public void UpdateColeccionUsuario(Coleccion coleccion){
        
        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        UPDATE Coleccion
        SET UsuarioId = $usuarioId, JuegoId = $juegoId
        WHERE Id = $id;
        ";
        cmd.Parameters.AddWithValue("$id", coleccion.Id);   
        cmd.Parameters.AddWithValue("$usuarioId", coleccion.UsuarioId);   
        cmd.Parameters.AddWithValue("$juegoId", coleccion.JuegoId);
        cmd.ExecuteNonQuery();
    }

    public void DeleteColeccionUsuario(int id){
        
        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        DELETE FROM Coleccion
        WHERE Id = $id;
        ";
        cmd.Parameters.AddWithValue("$id", id);
        cmd.ExecuteNonQuery();
        }
}