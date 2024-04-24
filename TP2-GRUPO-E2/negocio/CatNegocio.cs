using program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CatNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearQuery("select Id, Descripcion FROM CATEGORIAS");
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.Descripcion= datos.Lector.GetString(1);

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

        public void agregar(Categoria cat)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearQuery("insert into CATEGORIAS(Descripcion) values(@Descripcion)");
                datos.setearParametro("@Descripcion", cat.Descripcion);
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

        public void editar(Categoria editado)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearQuery("UPDATE CATEGORIAS SET Descripcion = @Descripcion WHERE Id = @IdCategoria;");
                datos.setearParametro("@Descripcion", editado.Descripcion);
                datos.setearParametro("@IdCategoria", editado.ID);

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
                datos.setearQuery("delete FROM CATEGORIAS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
