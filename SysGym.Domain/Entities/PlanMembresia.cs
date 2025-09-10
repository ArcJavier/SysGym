using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGym.Domain.Entities;

public partial class PlanMembresia
{
    [Key]
    public int IdPlan { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public sbyte DuracionDias { get; set; }

    [Precision(6, 2)]
    public decimal Precio { get; set; }

    public bool Acceso24h { get; set; }

    public sbyte Estado { get; set; }

    [InverseProperty("IdPlanNavigation")]
    public virtual ICollection<Suscripcion> Suscripcion { get; set; } = new List<Suscripcion>();
}
