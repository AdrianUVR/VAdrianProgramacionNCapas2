using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAllEF(string nombre, int IdDepartamento, int IdArea)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    var query = context.Productos.FromSqlRaw($"ProductoGetAll'{nombre}',{IdDepartamento},{IdArea}").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();


                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = (decimal)obj.PrecioUnitario;
                            producto.Descripcion = obj.Descripcion;
                            producto.Stock = obj.Stock;
                            producto.Imagen = obj.Imagen;



                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento;

                           

                           



                            result.Objects.Add(producto);

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
