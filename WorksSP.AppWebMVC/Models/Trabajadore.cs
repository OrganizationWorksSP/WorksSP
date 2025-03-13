using System;
using System.Collections.Generic;

namespace WorksSP.AppWebMVC.Models;

public partial class Trabajadore
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public byte? Estado { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<PerfilTrabajo> PerfilTrabajos { get; set; } = new List<PerfilTrabajo>();

    public virtual ICollection<SolicitarOferta> SolicitarOferta { get; set; } = new List<SolicitarOferta>();
}
