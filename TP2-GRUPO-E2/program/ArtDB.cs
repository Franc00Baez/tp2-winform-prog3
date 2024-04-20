using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace program
{
    public class ArtDB
    {
        private string connectionString = "Data Source=WOROWARCRA\\SQLEXPRESS;Initial Catalog=CATALOGO_P3_DB;"+"Integrated Security=True";

        public bool ok()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch
            {
                return false;
                
            }
            return true;
        }

        public List<Articulo> Get()
        {
            List<Articulo> list = new List<Articulo>();
            string query = "select Id,Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio from ARTICULOS";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();  
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Articulo articulo = new Articulo();
                        articulo.Id = reader.GetInt32(0);
                        articulo.Codigo = reader.GetString(1);
                        articulo.Nombre = reader.GetString(2);
                        articulo.Descripcion = reader.GetString(3);
                        articulo.idMarca = reader.GetInt32(4);
                        articulo.idCategoria = reader.GetInt32(5);
                        articulo.Precio = reader.GetDecimal(6);
                        list.Add(articulo);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch(Exception ex)
                {
                    throw new Exception("hay un error en la BD" + ex.Message);
                    
                }
            }
            return list;
        }

        public void Add(string Codigo,string Nombre,string Descripcion,int idMarca,int idCategoria,decimal Precio)
        {
            string query = "insert into ARTICULOS(Codigo, Nombre, Descripcion, idMarca, idCategoria, Precio) values" + "(@Codigo, @Nombre, @Descripcion, @idMarca, @idCategoria, @Precio) ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codigo", Codigo);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Descripcion", Descripcion);
                command.Parameters.AddWithValue("@idMarca", idMarca);
                command.Parameters.AddWithValue("@idCategoria", idCategoria);
                command.Parameters.AddWithValue("@Precio", Precio);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("hay un error en la BD" + ex.Message);

                }

            }
        }

        public void Update(int Id,string Codigo, string Nombre, string Descripcion, int idMarca, int idCategoria, decimal Precio)
        {
            string query = "update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, idMarca = @idMarca, idCategoria = @idCategoria, Precio = @Precio" +
                " where Id=@Id"
;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codigo", Codigo);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Descripcion", Descripcion);
                command.Parameters.AddWithValue("@idMarca", idMarca);
                command.Parameters.AddWithValue("@idCategoria", idCategoria);
                command.Parameters.AddWithValue("@Precio", Precio);
                command.Parameters.AddWithValue("@Id", Id);


                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("hay un error en la BD" + ex.Message);

                }

            }
        }
    }
}
