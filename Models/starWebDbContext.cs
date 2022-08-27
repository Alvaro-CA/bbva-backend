using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bbva_backend.Models
{
    public partial class starWebDbContext : DbContext
    {
        public starWebDbContext()
        {
        }

        public starWebDbContext(DbContextOptions<starWebDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencium> Agencia { get; set; } = null!;
        public virtual DbSet<Colaborador> Colaboradors { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Segmento> Segmentos { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<Ubigeo> Ubigeos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source= 129.213.122.28;initial catalog=StarWeb;user id=sa;password=EQUIPO12@BBVA");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencium>(entity =>
            {
                entity.HasKey(e => e.IdAgencia)
                    .HasName("PK__Agencia__2F174292E6C5EC13");

                entity.Property(e => e.IdAgencia).HasColumnName("idAgencia");

                entity.Property(e => e.Aforo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("aforo");

                entity.Property(e => e.Altitud)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("altitud");

                entity.Property(e => e.CapacidadActual)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("capacidadActual");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("distrito");

                entity.Property(e => e.IdRegion).HasColumnName("idRegion");

                entity.Property(e => e.IdUbigeo).HasColumnName("idUbigeo");

                entity.Property(e => e.Latitud)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("latitud");

                entity.Property(e => e.NombreAgencia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreAgencia");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("provincia");
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.HasKey(e => e.IdColaborador)
                    .HasName("PK__Colabora__A6A5C3967E1E6C7F");

                entity.ToTable("Colaborador");

                entity.Property(e => e.IdColaborador).HasColumnName("idColaborador");

                entity.Property(e => e.NombreColaborador)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreColaborador");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.IdRegion)
                    .HasName("PK__Region__82DE6872B55F5CCE");

                entity.ToTable("Region");

                entity.Property(e => e.IdRegion).HasColumnName("idRegion");

                entity.Property(e => e.NombreRegion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreRegion");
            });

            modelBuilder.Entity<Segmento>(entity =>
            {
                entity.HasKey(e => e.Segmento1)
                    .HasName("PK__Segmento__C6DE5B48B85B7790");

                entity.ToTable("Segmento");

                entity.Property(e => e.Segmento1).HasColumnName("Segmento");

                entity.Property(e => e.NombreSegmento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreSegmento");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .HasName("PK__Ticket__22B1456F11A06614");

                entity.ToTable("Ticket");

                entity.Property(e => e.IdTicket).HasColumnName("idTicket");

                entity.Property(e => e.AtendidoPor).HasColumnName("atendidoPor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.FechaHoraActualizacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaHoraActualizacion");

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaHoraCreacion");

                entity.Property(e => e.FechaHoraIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaHoraIngreso");

                entity.Property(e => e.FechaHoraSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaHoraSalida");

                entity.Property(e => e.IdAgencia).HasColumnName("idAgencia");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            });

            modelBuilder.Entity<Ubigeo>(entity =>
            {
                entity.HasKey(e => e.IdUbigeo)
                    .HasName("PK__Ubigeo__79399D5C99E243F2");

                entity.ToTable("Ubigeo");

                entity.Property(e => e.IdUbigeo).HasColumnName("idUbigeo");

                entity.Property(e => e.CodigoUbigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codigoUbigeo")
                    .IsFixedLength();

                entity.Property(e => e.IdDepartamento)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idDepartamento")
                    .IsFixedLength();

                entity.Property(e => e.IdDistrito)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idDistrito")
                    .IsFixedLength();

                entity.Property(e => e.IdProvincia)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idProvincia")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
