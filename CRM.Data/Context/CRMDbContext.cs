using Microsoft.EntityFrameworkCore;
using CRM.Domain;

namespace CRM.Data
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> option) : base(option)
        {

        }

        #region DB SETs

        public DbSet<Estado> Estados => Set<Estado>();
        public DbSet<Pais> Paises => Set<Pais>();
        public DbSet<Pessoa> Pessoas => Set<Pessoa>();
        public DbSet<PessoaEndereco> PessoaEnderecos => Set<PessoaEndereco>();
        public DbSet<Regiao> Regioes => Set<Regiao>();
        public DbSet<Municipio> Municipios => Set<Municipio>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new MunicipioMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new PessoaEnderecoMap());
            modelBuilder.ApplyConfiguration(new RegiaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PapelMap());
            modelBuilder.ApplyConfiguration(new ComponenteMap());
            modelBuilder.ApplyConfiguration(new ComponenteEndPointMap());
            modelBuilder.ApplyConfiguration(new PapelComponenteMap());
            modelBuilder.ApplyConfiguration(new UsuarioPapelMap());

            modelBuilder.ApplyGlobalConfigurations();
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
