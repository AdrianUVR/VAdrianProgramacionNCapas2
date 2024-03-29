﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }

        public string Nombre { get; set; }
        public string Calle { get; set; }

        public string NumeroInteriror { get; set; }

        public string NumeroExterior { get; set; }

        public List<object> Direcciones { get; set; }

        public ML.Usuario Usuario { get; set; }

        public ML.Colonia Colonia { get; set; }

    }
}
