using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DepartamentoController : Controller
    {

        [HttpGet]
        public ActionResult DepartamentoGetAll()
        {
            ML.Departamento departamento =new ML.Departamento();
            ML.Result result = BL.Departamento.GetAll();




            if (result.Correct)
            {
                departamento.Departamentos = result.Objects;

                return View(departamento);

            }
            else
            {
                return View(departamento);
            }


        }
        [HttpPost]


        public ActionResult GetAll()
        {

            ML.Result result = BL.Departamento.GetAll();


            ML.Departamento departamento=new ML.Departamento(); 

            if (result.Correct)
            {
                departamento.Departamentos= result.Objects;


                return View(departamento);
            }
            else
            {
                return View(departamento);
            }


        }

    }
}
