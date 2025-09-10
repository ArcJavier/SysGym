using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGym.Domain.Entities;

public partial class Sucursal
{
    [Key]
    public int IdSucursal { get; set; }

    [StringLength(25)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string Direccion { get; set; } = null!;

    public sbyte Estado { get; set; }

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<Acceso> Acceso { get; set; } = new List<Acceso>();
}
