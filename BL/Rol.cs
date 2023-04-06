using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public class Rol
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    var query = context.Rols.FromSqlRaw("RolGeTAll").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Rol rol = new ML.Rol();

                            rol.IdRol = obj.Idrol;
                            rol.Nombre = obj.Nombre;


                            result.Objects.Add(rol);

                        }

                    }


                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
    }


}

