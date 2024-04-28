using program;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                datos.setearQuery("SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio, COALESCE(I.ImagenUrl, 'Sin imagen') AS Imagen, IdMarca, IdCategoria FROM ARTICULOS A INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id;");
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.Marca = new Marca();
                    aux.Marca.IDMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = datos.Lector.GetDecimal(6);
                    aux.Imagen = new Imagen();
                    aux.Imagen.URL = (string)datos.Lector["Imagen"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("hay un error en la BD " + ex.Message);
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

        public void editar(Articulo editado)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearQuery("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio FROM ARTICULOS A INNER JOIN IMAGENES I ON A.Id = I.IdArticulo WHERE A.Id = @IdArticulo; UPDATE IMAGENES SET ImagenUrl = @NuevaImagenUrl WHERE IdArticulo = @IdArticulo;");
                datos.setearParametro("@Codigo", editado.Codigo);
                datos.setearParametro("@Nombre", editado.Nombre);
                datos.setearParametro("@Descripcion", editado.Descripcion);
                datos.setearParametro("@IdMarca", editado.Marca.IDMarca);
                datos.setearParametro("@IdCategoria", editado.Categoria.ID);
                datos.setearParametro("@Precio", editado.Precio);
                datos.setearParametro("@NuevaImagenUrl", editado.Imagen.URL);
                datos.setearParametro("@IdArticulo", editado.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    
        public void eliminar(int id)
        {
            try
            {
                AccesoDB datos = new AccesoDB();
                datos.setearQuery("delete FROM ARTICULOS where id = @id; delete from IMAGENES where IdArticulo = @id;");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        public List<Articulo> Filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDB datos = new AccesoDB();
            string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio, COALESCE(I.ImagenUrl, 'Sin imagen') AS Imagen, IdMarca, IdCategoria FROM ARTICULOS A INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id WHERE ";

            switch (campo)
            {
                case "Precio":
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor que":
                            consulta += "Precio < " + filtro;
                            break;
                        case "Igual a":
                            consulta += "Precio = " + filtro;
                            break;
                    }
                    break;
                case "Nombre":
                    switch (criterio)
                    {
                        case "Comienza por":
                            consulta += "Nombre LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre Like '" + filtro + "'";
                            break;
                    }
                    break;
                case "Marca":
                    switch (criterio)
                    {
                        case "Comienza por":
                            consulta += "M.Descripcion LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion Like '" + filtro + "'";
                            break;
                    }
                    break;
                default:
                    switch (criterio)
                    {
                        case "Comienza por":
                            consulta += "C.Descripcion LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion Like '" + filtro + "'";
                            break;
                    }
                    break;
            }
            try
            {
                datos.setearQuery(consulta);
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);
                    aux.Marca = new Marca();
                    aux.Marca.IDMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.ID = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = datos.Lector.GetDecimal(6);
                    aux.Imagen = new Imagen();
                    aux.Imagen.URL = (string)datos.Lector["Imagen"];

                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return listar();
            }
        }
    } 
}
