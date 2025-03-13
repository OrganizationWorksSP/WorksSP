using System;
using System.Collections.Generic;

namespace WorksSP.AppWebMVC.Models;

public partial class Contratista
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public byte? Estado { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<OfertaTrabajo> OfertaTrabajos { get; set; } = new List<OfertaTrabajo>();

    public virtual ICollection<Valoracione> Valoraciones { get; set; } = new List<Valoracione>();
}
