﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;

[Table("colaboradores")]
public partial class Colaborador
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("cargo_id")]
    public int? CargoId { get; set; }

    [Column("nome")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; }

    [Column("cpf")]
    [StringLength(20)]
    [Unicode(false)]
    public string Cpf { get; set; }

    [Column("data_admissao", TypeName = "date")]
    public DateTime? DataAdmissao { get; set; }

    [Column("data_saida", TypeName = "date")]
    public DateTime? DataSaida { get; set; }

    [Column("status")]
    public byte? Status { get; set; }

    [ForeignKey("CargoId")]
    [InverseProperty("Colaborador")]
    public virtual Cargo Cargo { get; set; }

    [InverseProperty("Colaborador")]
    public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

    [InverseProperty("Colaborador")]
    public virtual ICollection<FolhaPagamento> FolhaPagamentos { get; set; } = new List<FolhaPagamento>();
}