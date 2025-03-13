using System;
using System.Collections.Generic;

namespace WorksSP.AppWebMVC.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<OfertaTrabajo> OfertaTrabajos { get; set; } = new List<OfertaTrabajo>();

    public virtual ICollection<PerfilTrabajo> PerfilTrabajos { get; set; } = new List<PerfilTrabajo>();
}
