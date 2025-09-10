using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGym.Domain.Entities;

[Index("CorreoE", Name = "CorreoE", IsUnique = true)]
[Index("IdRol", Name = "IdRol")]
public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    public string CorreoE { get; set; } = null!;

    [StringLength(90)]
    public string Contrasenia { get; set; } = null!;

    public bool Activo { get; set; }

    public sbyte Estado { get; set; }

    [ForeignKey("IdRol")]
    [InverseProperty("Usuario")]
    public virtual Rol IdRolNavigation { get; set; } = null!;

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Suscripcion> Suscripcion { get; set; } = new List<Suscripcion>();
}
