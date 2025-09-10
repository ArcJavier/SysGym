using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGym.Domain.Entities;

[Index("IdSuscripcion", Name = "IdSuscripcion")]
public partial class Congelacion
{
    [Key]
    public int IdCongelacion { get; set; }

    public int IdSuscripcion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaInicio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaFin { get; set; }

    public sbyte Estado { get; set; }

    [ForeignKey("IdSuscripcion")]
    [InverseProperty("Congelacion")]
    public virtual Suscripcion IdSuscripcionNavigation { get; set; } = null!;
}
