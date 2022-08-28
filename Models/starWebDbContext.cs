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
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Segmento> Segmentos { get; set; } = null!;
        public virtual DbSet<SegmentoAgencium> SegmentoAgencia { get; set; } = null!;
        public virtual DbSet<SegmentoCliente> SegmentoClientes { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;

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
                    .HasName("PK__Agencia__2F17429240C749C2");

                entity.Property(e => e.IdAgencia).HasColumnName("idAgencia");

                entity.Property(e => e.Aforo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("aforo");

                entity.Property(e => e.AforoCajero).HasColumnName("aforoCajero");

                entity.Property(e => e.Altitud)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("altitud");

                entity.Property(e => e.CapacidadActual)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("capacidadActual");

                entity.Property(e => e.CapacidadCajeroActual).HasColumnName("capacidadCajeroActual");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("distrito");

                entity.Property(e => e.HorarioCierreAtencion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("horarioCierreAtencion");

                entity.Property(e => e.HorarioInicioAtencion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("horarioInicioAtencion");

                entity.Property(e => e.IdRegion).HasColumnName("idRegion");

                entity.Property(e => e.IdSegmento).HasColumnName("idSegmento");

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

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Agencia)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agencia__idRegio__01142BA1");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__885457EE4DD9F8F4");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.FlgEsCliente).HasColumnName("flgEsCliente");

                entity.Property(e => e.IdSegmento).HasColumnName("idSegmento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("numeroDocumento");
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
                entity.HasKey(e => e.IdSegmento)
                    .HasName("PK__Segmento__8942DA4DFF8F0139");

                entity.ToTable("Segmento");

                entity.Property(e => e.IdSegmento).HasColumnName("idSegmento");

                entity.Property(e => e.Jerarquia).HasColumnName("jerarquia");

                entity.Property(e => e.NombreSegmento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreSegmento");
            });

            modelBuilder.Entity<SegmentoAgencium>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdAgencia).HasColumnName("idAgencia");

                entity.Property(e => e.IdSegmento).HasColumnName("idSegmento");

                entity.HasOne(d => d.IdAgenciaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAgencia)
                    .HasConstraintName("FK__SegmentoA__idAge__787EE5A0");

                entity.HasOne(d => d.IdSegmentoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSegmento)
                    .HasConstraintName("FK__SegmentoA__idSeg__797309D9");
            });

            modelBuilder.Entity<SegmentoCliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SegmentoCliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdSegmento).HasColumnName("idSegmento");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__SegmentoC__idCli__7A672E12");

                entity.HasOne(d => d.IdSegmentoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSegmento)
                    .HasConstraintName("FK__SegmentoC__idSeg__7B5B524B");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .HasName("PK__Ticket__22B1456F12FB081F");

                entity.ToTable("Ticket");

                entity.Property(e => e.IdTicket).HasColumnName("idTicket");

                entity.Property(e => e.AtendidoPor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("atendidoPor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaHoraIngreso)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fechaHoraIngreso");

                entity.Property(e => e.FechaHoraSalida)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fechaHoraSalida");

                entity.Property(e => e.IdAgencia).HasColumnName("idAgencia");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.HasOne(d => d.IdAgenciaNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdAgencia)
                    .HasConstraintName("FK__Ticket__idAgenci__70DDC3D8");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Ticket__idClient__72C60C4A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
