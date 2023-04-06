﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    internal class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }

        public ML.Producto Producto { get; set; }

        public List<object> Proveedores { get; set; }
    }
}
