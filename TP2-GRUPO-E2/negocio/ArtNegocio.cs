using program;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class ArtNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearQuery("SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio, COALESCE(I.ImagenUrl, 'Sin imagen') AS Imagen FROM ARTICULOS A INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id;");
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Tipo = (string)datos.Lector["Categoria"];
                    aux.Precio = datos.Lector.GetDecimal(6);
                    aux.Imagen = new Imagen();
                    aux.Imagen.URL = (string)datos.Lector["Imagen"];
                    
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("hay un error en la BD" + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void agregar(Articulo art)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearQuery("insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio); insert into IMAGENES(IdArticulo, ImagenUrl) values(SCOPE_IDENTITY(), @UrlImagen)");
                datos.setearParametro("@Codigo", art.Codigo);
                datos.setearParametro("@Nombre", art.Nombre);
                datos.setearParametro("@Descripcion", art.Descripcion);
                datos.setearParametro("@IdMarca", art.Marca.IDMarca);
                datos.setearParametro("@IdCategoria", art.Categoria.ID);
                datos.setearParametro("@Precio", art.Precio);
                datos.setearParametro("@UrlImagen", art.Imagen.URL);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                datos.cerrarConexion(); 
            }
        }

    }

    
}
