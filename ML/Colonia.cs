using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Colonia
    {
        

        public string Nombre { get; set; }

        public string CodigoPostal { get; set; }

        public List<object> COLONIAS { get; set; }

        public ML.Direccion Direccion { get; set; }

        public ML.Municipio Municipio { get; set; }
        public int IdColonia { get; set; }
    }
}
