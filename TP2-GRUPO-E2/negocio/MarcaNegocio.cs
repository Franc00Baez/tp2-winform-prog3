using program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDB datos = new AccesoDB();

            try
            {
                datos.setearQuery("select Id, Descripcion FROM MARCAS");
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IDMarca = datos.Lector.GetInt32(0);
                    aux.Descripcion = datos.Lector.GetString(1);

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

    public void agregar(Marca mar)
    {
        AccesoDB datos = new AccesoDB();
        try
        {
            datos.setearQuery("insert into MARCAS(Descripcion) values(@Descripcion)");
            datos.setearParametro("@Descripcion", mar.Descripcion);
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

    public void editar(Marca editado)
        {
            AccesoDB datos = new AccesoDB();
            try
            {
                datos.setearQuery("UPDATE MARCAS SET Descripcion = @Descripcion WHERE Id = @IdMarca;");
                datos.setearParametro("@Descripcion", editado.Descripcion);
                datos.setearParametro("@IdMarca", editado.IDMarca);

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
                datos.setearQuery("delete FROM MARCAS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Marca> Filtrar(string campo, string criterio, string filtro)
        {
            List<Marca> lista = new List<Marca>();
            AccesoDB datos = new AccesoDB();
            string consulta = "select Id, Descripcion FROM MARCAS Where ";

            if(campo == "Id")
            {
                switch(criterio)
                {
                    case "Mayor a":
                        consulta += "Id > " + filtro;
                        break;
                    case "Menor que":
                        consulta += "Id < " + filtro;
                        break;
                    default:
                        consulta += "Id = " + filtro;
                        break;
                }
            }else
            {
                switch(criterio)
                {
                    case "Comienza con":
                        consulta += "Descripcion Like '" + filtro + "%'";
                        break;
                    case "Termina por":
                        consulta += "Descripcion Like '%" + filtro + "'";
                        break;
                    default:
                        consulta += "Descripcion like '" + filtro + "'";
                        break;
                }
            }

            try
            {
                datos.setearQuery(consulta);
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IDMarca = datos.Lector.GetInt32(0);
                    aux.Descripcion = datos.Lector.GetString(1);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return lista;
            }

        }
    }

}