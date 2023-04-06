using System;
using System.Collections.Generic;

namespace DL;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public decimal Total { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdMetodoDePago { get; set; }

    public virtual MetodoDePago? IdMetodoDePagoNavigation { get; set; }
}
