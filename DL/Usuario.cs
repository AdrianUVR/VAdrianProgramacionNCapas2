using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int Id { get; set; }
    public int ID { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int? IdRol { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public string? Celular { get; set; }

    public string? Curp { get; set; }

    public string? Imagen { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Direccion> Direccions { get; } = new List<Direccion>();

    public virtual Rol? IdRolNavigation { get; set; }

    public string CURP { get; set; }
    public int IdDireccion { get; set; }
    public string Calle { get; set; }
    public string NumeroInteriror { get; set; }
    public string NumeroExterior { get; set; }

    public string CodigoPostal { get; set; }

    public int IdMunicipio { get; set; }
    public int IdPais { get; set; }
    public int IdColonia { get; set; }
}
