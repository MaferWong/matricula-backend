using MatriculaWebApplicationEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatriculaWebApplicationEF.DataContext
{
    public class ProfesorMap : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            builder.ToTable("Profesores", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.Nombre).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Edad).HasColumnType("int").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Sexo).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Correo).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Contrasena).HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(e => e.IsActive).HasColumnType("varchar(50)");

            builder.HasOne(e => e.Pais)
                .WithMany(e => e.Profesores)
                .HasForeignKey(e => e.PaisId);
            builder.HasOne(e => e.Materia)
                .WithMany(e => e.Profesores)
                .HasForeignKey(e => e.MateriaId);
        }
    }
}
