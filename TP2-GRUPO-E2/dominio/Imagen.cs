﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public class Imagen
    {
        public int ID { get; set; }
        public int IDArticulo { get; set; }
        public string URL { get; set; }

        public override string ToString()
        {
            return URL;
        }
    }
}
