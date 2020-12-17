using MatriculaWebApplicationEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatriculaWebApplicationEF.DataContext
{
    public class MateriaMap : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.ToTable("Materias", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.Codigo).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Nombre).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.HasOne(e => e.Curso)
                .WithMany(e => e.Materias)
                .HasForeignKey(e => e.CursoId);
        }
    }
}
