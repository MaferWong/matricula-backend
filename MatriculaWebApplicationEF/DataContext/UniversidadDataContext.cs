using MatriculaWebApplicationEF.Models;
using Microsoft.EntityFrameworkCore;

namespace MatriculaWebApplicationEF.DataContext
{
    public class UniversidadDataContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Materia> Materias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=WONG;DataBase=UniversidadDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EstudianteMap());
            modelBuilder.ApplyConfiguration(new ProfesorMap());
            modelBuilder.ApplyConfiguration(new MateriaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
