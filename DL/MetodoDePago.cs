using System;
using System.Collections.Generic;

namespace DL;

public partial class MetodoDePago
{
    public int IdMetodoDePago { get; set; }

    public string? Metodo { get; set; }

    public virtual ICollection<Ventum> Venta { get; } = new List<Ventum>();
}
