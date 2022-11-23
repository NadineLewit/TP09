namespace TP09.Models;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
 
public class BD
{
    private static string _connectionString = @"Server=A-PHZ2-AMI-013;DataBase=TP08;Trusted_Connection=True";
 
    public static List<Pelicula> ObtenerPeliculas()
    {
        List<Pelicula> lista = new List<Pelicula>();
        string sql = "SELECT * FROM Pelicula";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            lista = db.Query<Pelicula>(sql).ToList();
        }
        return lista;
    }
    
    public static void AgregarPelicula(Pelicula Peli)
    {
        string sql = "INSERT INTO Pelicula VALUES (@pNombre, @pFoto, @pDescripcion, @pEstrellas, @pFkCategoria)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pNombre = Peli.Nombre, pFoto = Peli.Foto, pDescripcion = Peli.Descripcion, pEstrellas = Peli.Estrellas, pFkCategoria = Peli.FkCategoria });
        }
    }

     public static void EliminarReseñas(int FkPelicula)
    {
        int RegistrosEliminados = 0;
        string sql = "DELETE FROM Reseña WHERE FkPelicula = @pFkPelicula ";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            RegistrosEliminados = db.Execute(sql, new { pFkPelicula = FkPelicula});
        }
    }
    public static void EliminarPelicula(int IdPelicula)
    {
        int RegistrosEliminados = 0;
        string sql = "DELETE FROM Pelicula WHERE IdPelicula = @pIdPelicula ";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            RegistrosEliminados = db.Execute(sql, new { pIdPelicula = IdPelicula});
        }
    }
    public static Pelicula VerInfoPelicula(int IdPelicula)
    {
        Pelicula peli = null;
        string sql = "SELECT Pelicula.*, Categoria.Nombre as NombreCategoria FROM Pelicula inner join Categoria on Pelicula.FkCategoria = Categoria.IdCategoria WHERE IdPelicula = @pIdPelicula ";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            peli = db.QueryFirstOrDefault<Pelicula>(sql, new { pIdPelicula = IdPelicula});
        }
        return peli;
    }
}