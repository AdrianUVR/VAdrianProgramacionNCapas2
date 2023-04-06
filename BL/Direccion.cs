using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        //public static ML.Result GetByIdColonia(int IdMunicipio)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
        //        {
        //            var query = context.Direccions.FromSql("").ToList();

        //            if (query != null)
        //            {
        //                result.Objects = new List<object>();

        //                foreach (var obj in query)
        //                {
        //                    ML.COLONIA Colonia = new ML.COLONIA();

        //                    Colonia.IdColonia = obj.IdColonia;
        //                    Colonia.Nombre = obj.Nombre;


        //                    result.Objects.Add(Colonia);

        //                }

        //            }
        //        }
        //        result.Correct = true;

        //    }
        //    catch (Exception ex)
        //    {

        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;
        //}
    }
}
