namespace Tp2.Service;
using Microsoft.Data.Sqlite;
using Tp2.Dto;
using Tp2.Models;
public class UsuarioService
{
    string _connection = "Data Source=BD/Juego.db";

    public UsuarioService(){
    using var cn = new SqliteConnection(_connection);
    cn.Open(); 
    
    using var cmd = cn.CreateCommand();
    cmd.CommandText=@"
    CREATE TABLE IF NOT EXISTS Usuario(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL,
    Mail TEXT NOT NULL
    )";
    cmd.ExecuteNonQuery();
    } 

    public void CrearUsuario(Usuario usuario){

        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        INSERT INTO Usuario (Nombre, Mail)
        VALUES ($nombre, $mail);
        ";
        cmd.Parameters.AddWithValue("$nombre", usuario.Nombre);   
        cmd.Parameters.AddWithValue("$mail", usuario.Mail);
        cmd.ExecuteNonQuery();
    }

    public List<UsuarioDto> ObtenerUsuarios(){  
        var listaUsuarios = new List<UsuarioDto>();

        using var cn = new SqliteConnection(_connection);
        cn.Open();

        using var cmd = cn.CreateCommand();
        cmd.CommandText=@"SELECT Id, Nombre, Mail FROM Usuario";
        using var reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            var usuario = new Usuario{
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Mail = reader.GetString(2),
            };
            listaUsuarios.Add(new UsuarioDto(usuario));
        }
        return listaUsuarios;
    }


    public void UpdateUsuario(Usuario usuario){
        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        UPDATE Usuario SET Nombre = $nombre, Mail = $mail
        WHERE Id = $id;
        ";
        cmd.Parameters.AddWithValue("$id", usuario.Id);
        cmd.Parameters.AddWithValue("$nombre", usuario.Nombre);   
        cmd.Parameters.AddWithValue("$mail", usuario.Mail);
        cmd.ExecuteNonQuery();
    }

    public void DeleteUsuario(int id){
        using var cn = new SqliteConnection(_connection);
        cn.Open(); 

        using var cmd = cn.CreateCommand();
        cmd.CommandText = @"
        DELETE FROM Usuario
        WHERE Id = $id;
        ";
        cmd.Parameters.AddWithValue("$id", id);
        cmd.ExecuteNonQuery();
    }

}