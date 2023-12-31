﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;

[Table("cargos")]
public partial class Cargo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nome { get; set; }

    [Column("salario", TypeName = "decimal(9, 2)")]
    public decimal? Salario { get; set; }

    [InverseProperty("Cargo")]
    public virtual ICollection<Colaborador> Colaborador { get; set; } = new List<Colaborador>();
}