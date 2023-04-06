using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    var query = context.Pais.FromSqlRaw("PaisGetAll").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais = obj.IdPais;
                            pais.Nombre = obj.Nombre;



                            result.Objects.Add(pais);

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
