using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {

        public static ML.Result EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    var query = context.Estados.FromSqlRaw($"EstadoGetByIdPais  {IdPais} ").AsEnumerable().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Estado Estado = new ML.Estado();

                            Estado.IdEstado = obj.IdEstado;
                            Estado.Nombre = obj.Nombre;


                            result.Objects.Add(Estado);
                        }


                    }
                }
                result.Correct = true;

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
