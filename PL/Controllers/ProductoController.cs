using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public ActionResult GetAllProducto(string nombre, int IdDepartamento, int IdArea)
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAllEF(nombre, IdDepartamento, IdArea);




            if (result.Correct)
            {
                producto.Productos = result.Objects;

                return View(producto);

            }
            else
            {
                return View(producto);
            }


        }
        [HttpPost]


        public ActionResult GetAll(string nombre, int IdDepartamento, int IdArea)
        {

            ML.Result result = BL.Producto.GetAllEF(nombre, IdDepartamento, IdArea);


            ML.Producto producto = new ML.Producto();

            if (result.Correct)
            {
                producto.Productos = result.Objects;


                return View(producto);
            }
            else
            {
                return View(producto);
            }


        }
    }

}
