using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGym.Domain.Entities;

[Index("CorreoE", Name = "CorreoE", IsUnique = true)]
[Index("Dui", Name = "DUI", IsUnique = true)]
public partial class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [StringLength(150)]
    public string Nombre { get; set; } = null!;

    [StringLength(150)]
    public string Apellido { get; set; } = null!;

    [Column("DUI")]
    [StringLength(100)]
    public string Dui { get; set; } = null!;

    [StringLength(250)]
    public string CorreoE { get; set; } = null!;

    [StringLength(250)]
    public string Telefono { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaRegistro { get; set; }

    public sbyte Estado { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Acceso> Acceso { get; set; } = new List<Acceso>();

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Suscripcion> Suscripcion { get; set; } = new List<Suscripcion>();
}
