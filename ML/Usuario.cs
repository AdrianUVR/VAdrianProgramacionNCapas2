﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int? IdUsuario { get; set; }
     


        public ML.Rol Rol { get; set; }

        public ML.Pais Pais { get; set; }

        public ML.Direccion Direccion { get; set; }
       


   
        
        
        public string Nombre { get; set; }
      
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
       
        public string Telefono { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }




        public string Password { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
    
        public string Celular { get; set; }

        public string CURP { get; set; }
        public string Imagen { get; set; }


        public List<object> Usuarios { get; set; }

        public bool Status { get; set; }
    }
}
