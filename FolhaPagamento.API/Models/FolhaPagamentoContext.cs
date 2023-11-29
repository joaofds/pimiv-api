﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models;

public partial class FolhaPagamentoContext : DbContext
{
    public FolhaPagamentoContext()
    {
    }

    public FolhaPagamentoContext(DbContextOptions<FolhaPagamentoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beneficio> Beneficio { get; set; }

    public virtual DbSet<Cargo> Cargo { get; set; }

    public virtual DbSet<Colaborador> Colaborador { get; set; }

    public virtual DbSet<ColaboradorBeneficio> ColaboradorBeneficio { get; set; }

    public virtual DbSet<Endereco> Endereco { get; set; }

    public virtual DbSet<FolhaPagamento> FolhaPagamento { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Reserva> Reserva{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LOCALHOST;Initial Catalog=FolhaPagamento;User ID=sa;Password=root;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beneficio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_beneficios_id");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_cargos_id");
        });

        modelBuilder.Entity<Colaborador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_colaboradores_id");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Colaborador).HasConstraintName("FK_colaboradores_cargo_id__cargos_id");
        });

        modelBuilder.Entity<ColaboradorBeneficio>(entity =>
        {
            entity.HasOne(d => d.Beneficio).WithMany().HasConstraintName("FK_colaboradores_beneficios_beneficio_id__beneficios_id");

            entity.HasOne(d => d.Colaborador).WithMany().HasConstraintName("FK_colaboradores_beneficios_colaborador_id__colaboradores_id");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_enderecos_id");

            entity.Property(e => e.Uf).IsFixedLength();

            entity.HasOne(d => d.Colaborador).WithMany(p => p.Enderecos).HasConstraintName("FK_enderecos_colaborador_id__colaboradores_id");
        });

        modelBuilder.Entity<FolhaPagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_folha_pagamentos_id");

            entity.HasOne(d => d.Colaborador).WithMany(p => p.FolhaPagamentos).HasConstraintName("FK_folha_pagamentos_colaborador_id__colaborador_id");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_usuarios_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}