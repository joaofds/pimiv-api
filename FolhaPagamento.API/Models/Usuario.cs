﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;

[Table("usuarios")]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [StringLength(200)]
    [Unicode(false)]
    public string Nome { get; set; }

    [Column("sobrenome")]
    [StringLength(200)]
    [Unicode(false)]
    public string Sobrenome { get; set; }

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; }

    [Column("senha")]
    [StringLength(255)]
    [Unicode(false)]
    public string Senha { get; set; }

    [Column("status")]
    public byte? Status { get; set; }

    [Column("data_registro", TypeName = "datetime")]
    public DateTime? dataRegistro { get; set; }
}