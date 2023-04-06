using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.OleDb;

namespace BL
{
    public class Usuario
    {


        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    //  var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Telefono, usuario.Rol.IdRol,
                    var query = context.Database.ExecuteSqlRaw($"UsuarioAdd  '{usuario.UserName }' ,'{usuario.Nombre}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.Email}','{usuario.Password}', '{usuario.FechaNacimiento}','{usuario.Sexo}','{usuario.Telefono}','{usuario.Celular}','{usuario.CURP}','{usuario.Imagen}',{usuario.Rol.IdRol}, '{usuario.Direccion.Calle}','{usuario.Direccion.NumeroInteriror}', '{usuario.Direccion.NumeroExterior}',{usuario.Direccion.Colonia.IdColonia} ");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdUsuario)
        {

            ML.Result result = new ML.Result(); //instancia
            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioDelete {IdUsuario}");


                    if (query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); //instancia
            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    var query = context.Usuarios.FromSqlRaw("UsuarioUpdate" +
                        $"'{usuario.Nombre} ',  " +
                        $"'{usuario.ApellidoPaterno} ',  " +
                        $"'{usuario.ApellidoMaterno} ',  " +
                        $"'{usuario.Telefono} ',  " +
                        $"{usuario.Rol.IdRol} ," +
                        $"'{usuario.UserName} ' ," +
                        $"'{usuario.Email}',  " +
                        $"'{usuario.Password}' ," +
                        $"'{usuario.FechaNacimiento}'  , " +
                        $"'{usuario.Sexo}'," +
                        $"'{usuario.Celular}'," +
                        $"'{usuario.CURP}'," +
                        $"'{usuario.Imagen}'," +
                        $"'{usuario.Rol.IdRol}'," +
                        $" '{usuario.Direccion.Calle}'," +
                        $"'{usuario.Direccion.NumeroInteriror}'," +
                        $"'{usuario.Direccion.NumeroExterior}'," +
                        $"'{usuario.Direccion.Colonia.IdColonia}' ");


                    if (query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = (query != null);
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                    {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGeTAll '{usuario.Nombre}',  '{usuario.ApellidoPaterno}',  '{usuario.ApellidoMaterno}'" ).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                           usuario = new ML.Usuario();// aqui va limpiar el codigo 


                            usuario.IdUsuario = obj.ID;
                            usuario.Nombre = obj.Nombre.ToString();
                            usuario.ApellidoPaterno = obj.ApellidoPaterno.ToString();
                            usuario.ApellidoMaterno = obj.ApellidoMaterno.ToString();
                            usuario.Telefono = obj.Telefono;
                            usuario.UserName = obj.UserName;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            usuario.Sexo = obj.Sexo;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.CURP;
                            usuario.Imagen = obj.Imagen;
                            usuario.Status=(bool)obj.Status;
                           

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol.Value;



                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = obj.IdDireccion;
                            usuario.Direccion.Calle = obj.Calle;
                            usuario.Direccion.NumeroInteriror = obj.NumeroInteriror;
                            usuario.Direccion.NumeroExterior = obj.NumeroExterior;


                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia =obj.IdColonia;
                            usuario.Direccion.Colonia.Nombre = obj.Nombre;
                            usuario.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = obj.Nombre;

                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.Nombre;

                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.Nombre;






                            if (obj.ID != null)
                            {
                                result.ErrorMessage = "El usuario se asigno";
                            }
                            else
                            {
                                usuario.Rol.IdRol = obj.ID;
                            }


                            result.Objects.Add(usuario);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetById {IdUsuario}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.ID;

                        usuario.Nombre = query.Nombre.ToString();
                        usuario.ApellidoPaterno = query.ApellidoPaterno.ToString();
                        usuario.ApellidoMaterno = query.ApellidoMaterno.ToString();
                        usuario.Telefono = query.Telefono;
                        usuario.UserName = query.UserName;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        usuario.Sexo = query.Sexo;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;
                        usuario.Imagen = query.Imagen;
                        usuario.Status = query.Status.Value;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;



                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = query.IdDireccion;
                        usuario.Direccion.Calle = query.Calle;
                        usuario.Direccion.NumeroInteriror = query.NumeroInteriror;
                        usuario.Direccion.NumeroExterior = query.NumeroExterior;


                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = query.IdColonia;
                        usuario.Direccion.Colonia.Nombre = query.Nombre;
                        usuario.Direccion.Colonia.CodigoPostal = query.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = query.Nombre;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.Nombre;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.Nombre;


                        result.Object = usuario; //boxin

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result UsuarioStatus(int IdUsuario, bool Status) 
        
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    //  var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Telefono, usuario.Rol.IdRol,
                    var query = context.Database.ExecuteSqlRaw($"UsuarioStatus {IdUsuario},{Status} ");
           


                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetByUserName(string UserName)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.VadrianProgramasNcapas3Context context = new DL.VadrianProgramasNcapas3Context())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetByUserName '{UserName}'").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        //usuario.IdUsuario = query.ID;

                        //usuario.Nombre = query.Nombre.ToString();
                        //usuario.ApellidoPaterno = query.ApellidoPaterno.ToString();
                        //usuario.ApellidoMaterno = query.ApellidoMaterno.ToString();
                        //usuario.Telefono = query.Telefono;
                        usuario.UserName = query.UserName;
                        //usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        //usuario.FechaNacimiento = (DateTime)query.FechaNacimiento;
                        //usuario.Sexo = query.Sexo;
                        //usuario.Celular = query.Celular;
                        //usuario.CURP = query.CURP;
                        //usuario.Imagen = query.Imagen;
                        //usuario.Status = query.Status.Value;

                        //usuario.Rol = new ML.Rol();
                        //usuario.Rol.IdRol = query.IdRol.Value;



                        //usuario.Direccion = new ML.Direccion();
                        //usuario.Direccion.IdDireccion = query.IdDireccion;
                        //usuario.Direccion.Calle = query.Calle;
                        //usuario.Direccion.NumeroInteriror = query.NumeroInteriror;
                        //usuario.Direccion.NumeroExterior = query.NumeroExterior;


                        //usuario.Direccion.Colonia = new ML.Colonia();
                        //usuario.Direccion.Colonia.IdColonia = query.IdColonia;
                        //usuario.Direccion.Colonia.Nombre = query.Nombre;
                        //usuario.Direccion.Colonia.CodigoPostal = query.CodigoPostal;

                        //usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        //usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio;
                        //usuario.Direccion.Colonia.Municipio.Nombre = query.Nombre;

                        //usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

                        //usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.Nombre;

                        //usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        //usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                        //usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.Nombre;


                        result.Object = usuario; //boxin

                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result ConvertXSLXtoDataTable(string connString)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OleDbConnection context = new OleDbConnection(connString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;


                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;

                        DataTable tableUsuario = new DataTable();

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                               
                                usuario.Nombre = row[0].ToString();
                                //row[1] = (row[1] == null) ? 0 : usuario.Creditos;
                                //usuario.Creditos = (usuario.Creditos == null) ? 0 : usuario.Creditos;
                                usuario.ApellidoPaterno = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();                             
                                usuario.UserName = row[3].ToString();
                                usuario.Email = row[4].ToString();                              
                                usuario.FechaNacimiento = row[5].ToString();
                                usuario.Sexo = row[6].ToString();
                                usuario.Password = row[7].ToString();
                                usuario.Telefono = row[8].ToString();
                                usuario.Celular = row[9].ToString();
                                usuario.CURP = row[10].ToString();


                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = byte.Parse(row[11].ToString());

                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Calle = row[12].ToString();
                                usuario.Direccion.NumeroInteriror = (string)row[13];
                                usuario.Direccion.NumeroExterior = (string)row[14];

                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Colonia.IdColonia= byte.Parse(row[15].ToString());



                                result.Objects.Add(usuario);
                            }

                            result.Correct = true;

                        }

                        result.Object = tableUsuario;

                        if (tableUsuario.Rows.Count > 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en el excel";
                        }
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
        public static ML.Result ValidarExcel(List<object> Object)
        {
            ML.Result result = new ML.Result();

            try
            {
                result.Objects = new List<object>();
                //DataTable  //Rows //Columns
                int i = 1;
                foreach (ML.Usuario usuario in Object)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = i++;

                    if (usuario.Nombre == "")
                    {
                        error.Mensaje += "Ingresar el nombre  ";
                    }
                    if (usuario.ApellidoPaterno == "")
                    {
                        error.Mensaje += "Ingresar los creditos ";
                    }
                    if (usuario.ApellidoMaterno == "")
                    {
                        error.Mensaje += "Ingresar el Costo ";
                    }
                    if (usuario.Telefono == "")
                    {
                        error.Mensaje += "Ingresar el semestre ";
                    }
                    if (usuario.UserName == "")
                    {
                        error.Mensaje += "Ingresar el horario ";
                    }
                    if (usuario.Email == "")
                    {
                        error.Mensaje += "Ingresar el plantel ";
                    }
                    if (usuario.FechaNacimiento == null)
                    {
                        error.Mensaje += "Ingresar el status ";
                    }
                    if (usuario.CURP == "")
                    {
                        error.Mensaje += "Ingresar el status ";
                    }
                    if (error.Mensaje != null)
                    {
                        result.Objects.Add(error);
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