using Azure.Core;
using BL;
using DL;
using Microsoft.AspNetCore.Mvc;
using ML;
using System.Net.Http;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        //Inyeccion de dependencias-- patron de diseño
        private readonly IConfiguration _configuration;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public UsuarioController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Usuario usuario = new ML.Usuario();

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            try
            {

                using (var client = new HttpClient())
                {
                    string urlApi = _configuration["urlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.GetAsync("Usuario/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }
                    }
                    usuario.Usuarios = result.Objects;
                }

            }
            catch (Exception ex)
            {
            }

            return View(usuario);
        }
        [HttpPost]


        public ActionResult GetAll(ML.Usuario usuario)
        {

            ML.Result result = BL.Usuario.GetAllEF(usuario);


            ML.Direccion direcciones = new ML.Direccion();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                direcciones.Direcciones = result.Objects;

                return View(usuario);
            }
            else
            {
                return View(usuario);
            }


        }

        [HttpGet]

        public ActionResult Form(int IdUsuario)
        {
            ML.Result resultRol = BL.Rol.GetAllEF();
            ML.Result resultPais = BL.Pais.GetAllEF();



            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();



            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();




            if (resultRol.Correct && resultPais.Correct)

            //Editar
            {
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
            }

            if (IdUsuario != null)
            {
                //add //formulario vacio


                return View(usuario);
            }

            else
            {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);


                if (result.Correct)
                {

                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

                    ML.Result resultEstado = BL.Estado.EstadoGetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    ML.Result resultMunicipio = BL.Municipio.MunicipioGetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Result resultColonia = BL.Colonia.COLONIAGetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);


                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                    usuario.Direccion.Colonia.COLONIAS = resultColonia.Objects;



                    return View(usuario);
                }

                else
                {
                    //update 
                    ViewBag.Message = "Ocurrio al consultar la información del usuario";
                    return View("Modal");

                }
            }


        }

        [HttpPost] //Hacer el registro
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();


            //HttpPostedFileBase file = Request.Files["fuImage"];
            IFormFile file = Request.Form.Files["fuImage"];

            if (file != null)
            {
                byte[] imagen = ConvertToBytes(file);

                usuario.Imagen = Convert.ToBase64String(imagen);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["urlApi"]);
                var postTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Add", usuario);
                postTask.Wait();
                var result1 = postTask.Result;
                if (result1.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Se ha registrado el alumno";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Mensaje = "No se ha registrado el alumno";
                    return PartialView("Modal");
                }



            }






            //if (ModelState.IsValid == true)
            //{
            //    if (usuario.IdUsuario != null)
            //    {
            //        result = BL.Usuario.AddEF(usuario);

            //        if (result.Correct)
            //        {

            //            ViewBag.Message = "Se completo el registro satisfactoriamente";
            //        }
            //        else
            //        {
            //            ViewBag.Message = "Ocurrio un error al insertar el registro";
            //        }
            //        return View("Modal");
            //    }
            //    else
            //    {


            //    result = BL.Usuario.UpdateEF(usuario);

            //    if (result.Correct)
            //    {
            //        ViewBag.Message = "Se actualizo la información satisfactoriamente";
            //    }
            //    else
            //    {
            //        ViewBag.Message = "Ocurrio un error al actualizar el registro";
            //    }
            //    return View("Modal");
            //}




            //}
            //else

            //{
            //    usuario.Rol = new ML.Rol();
            //    usuario.Direccion = new ML.Direccion();
            //    usuario.Direccion.Colonia = new ML.Colonia();
            //    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            //    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            //    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();




            //    ML.Result resultRol = BL.Rol.GetAllEF();
            //    ML.Result resultPais = BL.Pais.GetAllEF();

            //    usuario = (ML.Usuario)result.Object;
            //    usuario.Rol.Roles = resultRol.Objects;
            //    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;


            //    return View(usuario);


            //}
        
    }
        [HttpGet]
        public ActionResult Delete(ML.Usuario usuario)
        {
            ML.Result resultListProduct = new ML.Result();
            int id = usuario.IdUsuario.Value;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("urlApi");

                //HTTP POST
                var postTask = client.GetAsync("Usuario/delete" + id);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    resultListProduct = BL.Usuario.GetAllEF(usuario);
                    return RedirectToAction("GetAll", resultListProduct);
                }
            }


            resultListProduct = BL.Usuario.GetAllEF(usuario);

            return View("GetAll", resultListProduct);

        }

    

        [HttpGet]
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["urlApi"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.GetAsync("Usuario/GetById/{IdUsuario}");
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Usuario resultItemList = new ML.Usuario();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

        [HttpPost]

        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = new ML.Result();
            result = BL.Estado.EstadoGetByIdPais(IdPais);


            return Json(result.Objects);

        }
        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);


            return Json(result.Objects);

        }
        public JsonResult COLONIAGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();
            result = BL.Colonia.COLONIAGetByIdMunicipio(IdMunicipio);


            return Json(result.Objects);

        }

        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }

        public JsonResult UsuarioStatus(int IdUsaurio, bool Status)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.UsuarioStatus(IdUsaurio, Status);

            return Json(result.Objects);

        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            ML.Result result = BL.Usuario.GetByUserName(UserName);
            if (result.Correct)
            {
                ML.Usuario usuario=(ML.Usuario )result.Object;
                if(Password == usuario.Password) 
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.Massage = "La contraseña no es la que incerto";
                    return PartialView("modal");  
                }
              
            }
            else
            {
                ViewBag.Massage = "UserName incorrecto";
                return View("modal");

            }
        }

    }

    




}
