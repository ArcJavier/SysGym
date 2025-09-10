using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGym.Domain.Entities;

[Index("IdCliente", Name = "IdCliente")]
[Index("IdSucursal", Name = "IdSucursal")]
public partial class Acceso
{
    [Key]
    public int IdAcceso { get; set; }

    public int IdCliente { get; set; }

    public int IdSucursal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaEntrada { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaSalida { get; set; }

    [Column(TypeName = "enum('QR','PIN','RFID')")]
    public string Fuente { get; set; } = null!;

    public sbyte Estado { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("Acceso")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdSucursal")]
    [InverseProperty("Acceso")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
