using CodeTur.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Infra.Data.Contexts
{
    //Modelando DBO com EntityFrameworkCore e FluentAPI
    public class CodeTurContext : DbContext
    {
        //contrutor para passar o options do CodeTur e na base é o DbContext
        //relação de escada
        public CodeTurContext(DbContextOptions<CodeTurContext> options) : base(options)
        {

        }

        //Definindo tabelas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Mapeamento Tabela Usuarios
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            //Propriedades

            //Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();
            
            //Email
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();
            
            //Senha
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(30);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(250)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();
            
            //Telefone
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //Comentarios
            //Relacionamento entre tabelas - 1 pra mtos
            //https://www.entityframeworktutorial.net/code-first/configure-one-to-one-relationship-in-code-first.aspx
            modelBuilder.Entity<Usuario>()
                        .HasMany(c => c.Comentarios)
                        .WithOne(u => u.Usuario)
                        .HasForeignKey(fk => fk.IdUsuario);
            
            //Datas
            modelBuilder.Entity<Usuario>().Property(x => x.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(x => x.DataAlteracao).HasColumnType("DateTime");
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
