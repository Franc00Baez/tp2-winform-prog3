using program;
using System;
using System.Collections.Generic;
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
                datos.setearQuery("select A.Id,Codigo,Nombre,A.Descripcion,M.Descripcion as Marca,C.Descripcion as Categoria,Precio, I.ImagenUrl as Imagen from ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I Where M.Id = A.IdMarca And C.Id = A.IdCategoria and I.IdArticulo = A.Id");
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
    }

        
}
