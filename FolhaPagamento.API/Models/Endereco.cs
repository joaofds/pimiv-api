﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;

[Table("enderecos")]
public partial class Endereco
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("colaborador_id")]
    public int? ColaboradorId { get; set; }

    [Column("logradouro")]
    [StringLength(100)]
    [Unicode(false)]
    public string Logradouro { get; set; }

    [Column("bairro")]
    [StringLength(50)]
    [Unicode(false)]
    public string Bairro { get; set; }

    [Column("cep")]
    [StringLength(12)]
    [Unicode(false)]
    public string Cep { get; set; }

    [Column("numero")]
    [StringLength(15)]
    [Unicode(false)]
    public string Numero { get; set; }

    [Column("complemento")]
    [StringLength(100)]
    [Unicode(false)]
    public string Complemento { get; set; }

    [Column("cidade")]
    [StringLength(100)]
    [Unicode(false)]
    public string Cidade { get; set; }

    [Column("uf")]
    [StringLength(2)]
    [Unicode(false)]
    public string Uf { get; set; }

    [ForeignKey("ColaboradorId")]
    [InverseProperty("Enderecos")]
    public virtual Colaboradores Colaborador { get; set; }
}