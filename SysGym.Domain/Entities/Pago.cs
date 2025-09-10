using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGym.Domain.Entities;

[Index("IdSuscripcion", Name = "IdSuscripcion")]
public partial class Pago
{
    [Key]
    public int IdPago { get; set; }

    public int IdSuscripcion { get; set; }

    [Precision(6, 2)]
    public decimal Monto { get; set; }

    [StringLength(50)]
    public string MetodoPago { get; set; } = null!;

    [StringLength(50)]
    public string? Referencia { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaPago { get; set; }

    public sbyte Estado { get; set; }

    [ForeignKey("IdSuscripcion")]
    [InverseProperty("Pago")]
    public virtual Suscripcion IdSuscripcionNavigation { get; set; } = null!;
}
