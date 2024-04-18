using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    class Articulo
    {
        private int CodigoDeArticulo;
        private string Nombre;
        private string Descripcion;
        private Marca marca;
        private Categoria categoria;
        private List<string> imagenes;
        decimal precio;

        public Articulo()
        {
            imagenes = new List<string>();
        }
        
    }
}
