using System;
using System.Collections.Generic;

namespace WorksSP.AppWebMVC.Models;

public partial class PerfilTrabajo
{
    public int Id { get; set; }

    public int IdCategoria { get; set; }

    public int IdTrabajador { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? Telefono { get; set; }

    public byte? Estado { get; set; }

    public DateTime FechaPublicacion { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Trabajadore IdTrabajadorNavigation { get; set; } = null!;

    public virtual ICollection<Valoracione> Valoraciones { get; set; } = new List<Valoracione>();
}
