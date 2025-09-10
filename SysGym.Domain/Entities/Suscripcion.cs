using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGym.Domain.Entities;

[Index("IdCliente", Name = "IdCliente")]
[Index("IdPlan", Name = "IdPlan")]
[Index("IdUsuario", Name = "IdUsuario")]
public partial class Suscripcion
{
    [Key]
    public int IdSuscripcion { get; set; }

    public int IdUsuario { get; set; }

    public int IdPlan { get; set; }

    public int IdCliente { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaInicio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaFin { get; set; }

    public sbyte Estado { get; set; }

    public bool Renovar { get; set; }

    [InverseProperty("IdSuscripcionNavigation")]
    public virtual ICollection<Congelacion> Congelacion { get; set; } = new List<Congelacion>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Suscripcion")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdPlan")]
    [InverseProperty("Suscripcion")]
    public virtual PlanMembresia IdPlanNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Suscripcion")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    [InverseProperty("IdSuscripcionNavigation")]
    public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();
}
