namespace TP09.Models;
 
public class Pelicula
{
    private int _IdPelicula;
    private string _Nombre;
    private string _Foto;
    private string _Descripcion;
    private int _Estrellas;
    private int _FkCategoria;
    private string _NombreCategoria;
 
 
    public int IdPelicula
    {
        get{return _IdPelicula;}
        set{_IdPelicula= value;}
    }
    public string Nombre
    {
        get{return _Nombre;}
        set{_Nombre= value;}
    }
    public string Foto
    {
        get{return _Foto;}
        set{_Foto= value;}
    }
    public string Descripcion
    {
        get{return _Descripcion;}
        set{_Descripcion= value;}
    }
    public int Estrellas
    {
        get{return _Estrellas;}
        set{_Estrellas= value;}
    }
    public int FkCategoria
    {
        get{return _FkCategoria;}
        set{_FkCategoria= value;}
    }
    public string NombreCategoria
    {
        get{return _NombreCategoria;}
        set{_NombreCategoria= value;}
    }
}