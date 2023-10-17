﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;

[Keyless]
[Table("colaboradores_beneficios")]
public partial class ColaboradorBeneficio
{
    [Column("colaborador_id")]
    public int? ColaboradorId { get; set; }

    [Column("beneficio_id")]
    public int? BeneficioId { get; set; }

    [ForeignKey("BeneficioId")]
    public virtual Beneficio Beneficio { get; set; }

    [ForeignKey("ColaboradorId")]
    public virtual Colaborador Colaborador { get; set; }
}