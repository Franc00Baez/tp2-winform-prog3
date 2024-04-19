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
        private string CodArt;
        private string Nombre;
        private string Descripcion;
        private Marca IDMarca;
        private Categoria IDCategoria;
        private List<Imagen> Imagenes;
        decimal Precio;

        public Articulo()
        {
            Imagenes = new List<Imagen>();
        }
        
    }
}
