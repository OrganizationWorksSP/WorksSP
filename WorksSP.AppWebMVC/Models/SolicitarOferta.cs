using System;
using System.Collections.Generic;

namespace WorksSP.AppWebMVC.Models;

public partial class SolicitarOferta
{
    public int Id { get; set; }

    public int IdOfertaTrabajo { get; set; }

    public int IdTrabajador { get; set; }

    public byte? Estado { get; set; }

    public string? Comentario { get; set; }

    public virtual OfertaTrabajo IdOfertaTrabajoNavigation { get; set; } = null!;

    public virtual Trabajadore IdTrabajadorNavigation { get; set; } = null!;
}
