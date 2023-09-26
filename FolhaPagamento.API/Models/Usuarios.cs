﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FolhaPagamento.API.Models;

/// <summary>
/// tabela de usuarios
/// </summary>
[Table("usuarios")]
[Index("Email", Name = "email_UNIQUE", IsUnique = true)]
[Index("Id", Name = "id_UNIQUE", IsUnique = true)]
public partial class Usuarios
{
    [Key]
    [Column("id")]
    public uint Id { get; set; }

    [Required]
    [Column("nome")]
    [StringLength(100)]
    public string Nome { get; set; }

    [Column("sobrenome")]
    [StringLength(200)]
    public string Sobrenome { get; set; }

    [Required]
    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [Column("senha")]
    [StringLength(255)]
    public string Senha { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}