using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Sinco.Models
{
    public partial class ColegiosincoContext : DbContext
    {
        public ColegiosincoContext()
        {
        }

        public ColegiosincoContext(DbContextOptions<ColegiosincoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<PersonaAsignatura> PersonaAsignaturas { get; set; }
        public virtual DbSet<ReportemateriasView> ReportemateriasViews { get; set; }
        public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=12345;database=colegiosinco", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb3")
                .UseCollation("utf8_bin");

            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.Idmateria)
                    .HasName("PRIMARY");

                entity.ToTable("asignatura");

                entity.Property(e => e.Idmateria).HasColumnName("idmateria");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PRIMARY");

                entity.ToTable("persona");

                entity.HasIndex(e => e.IdMateria, "materia_idx");

                entity.HasIndex(e => e.IdTipoPersona, "tipo_persona_idx");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("apellido");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("direccion");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.IdMateria)
                    .HasColumnName("idMateria")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IdTipoPersona).HasColumnName("idTipoPersona");

                entity.Property(e => e.Identificacion).HasColumnName("identificacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdMateria)
                    .HasConstraintName("fk_asignatura");
            });

            modelBuilder.Entity<PersonaAsignatura>(entity =>
            {
                entity.HasKey(e => e.IdpersonaMateria)
                    .HasName("PRIMARY");

                entity.ToTable("persona_asignatura");

                entity.HasIndex(e => e.IdMateria, "fk_idMateria_idx");

                entity.HasIndex(e => e.IdPersona, "fk_idPersona_idx");

                entity.Property(e => e.IdpersonaMateria).HasColumnName("idpersona_materia");

                entity.Property(e => e.Anio)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("anio");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.PersonaAsignaturas)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idMateria");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonaAsignaturas)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idPersona");
            });

            modelBuilder.Entity<ReportemateriasView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("reportematerias_view");

                entity.Property(e => e.Anio)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("anio");

                entity.Property(e => e.Aprobo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_0900_ai_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.IdMateria).HasColumnName("idMateria");

                entity.Property(e => e.IdProfesor).HasColumnName("idProfesor");

                entity.Property(e => e.Identificacion).HasColumnName("identificacion");

                entity.Property(e => e.Materia)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("materia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Profesor)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("profesor");
            });

            modelBuilder.Entity<TipoPersona>(entity =>
            {
                entity.HasKey(e => e.IdtipoPersona)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_persona");

                entity.Property(e => e.IdtipoPersona).HasColumnName("idtipo_persona");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
