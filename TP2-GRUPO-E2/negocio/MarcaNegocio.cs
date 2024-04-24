using program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

}