using MatriculaWebApplicationEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatriculaWebApplicationEF.DataContext
{
    public class EstudianteMap : IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder)
        {
            builder.ToTable("Estudiantes", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.Nombre).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Edad).HasColumnType("int").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Sexo).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Correo).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Contrasena).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.IsActive).HasColumnType("varchar(50)").IsRequired();

            builder.HasOne(e => e.Pais)
                .WithMany(e => e.Estudiantes)
                .HasForeignKey(e => e.PaisId); 
            builder.HasOne(e => e.Curso)
                .WithMany(e => e.Estudiantes)
                .HasForeignKey(e =>e.CursoId);
        }
    }
}
