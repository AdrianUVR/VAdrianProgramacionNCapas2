using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace SL.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpGet]
        [Route ("api/Usuario/GetAll")]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if (result.Correct)
            {
                return Ok (result);
            }
            else
            {
                return NotFound();
            }
           
        }

        [HttpPost]
        [Route("api/Usuario/GetAll")]
        public ActionResult GetAll([FromBody]ML.Usuario usuario)
        { 
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        [Route("api/Usuario/Add")]
        public ActionResult Add([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEF(usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpGet]
        [Route("api/Usuario/GetById/{IdUsuario}")]
        public ActionResult GetById(int IdUsuario)
        {
           
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);
           
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
          
            
            
        }
        [HttpGet]
        [Route("api/Usuario/Delete/{IdUsuario}")]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario=new ML.Usuario();
            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);
            usuario.Rol = new ML.Rol();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Usuario/Update/{IdUsuario}")]
        public ActionResult Update(ML.Usuario usuario)
        {
            ML.Result result =BL.Usuario.UpdateEF(usuario);
            if (result.Correct)
            {
                return Ok();
            }
            else
            {
                return NotFound(result);
            }
        }


    }
}
