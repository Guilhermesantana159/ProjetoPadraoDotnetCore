﻿// <auto-generated />
using System;
using Infraestrutura.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Infraestrutura.Entity.Menu", b =>
                {
                    b.Property<int>("IdMenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMenu"), 1L, 1);

                    b.Property<string>("DescricaoMenu")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoMenu");

                    b.Property<int>("IdModulo")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Link");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("IdMenu");

                    b.HasIndex("IdModulo");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("Infraestrutura.Entity.Modulo", b =>
                {
                    b.Property<int>("IdModulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdModulo"), 1L, 1);

                    b.Property<string>("DescricaoLabel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoLabel");

                    b.Property<string>("DescricaoModulo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoModulo");

                    b.Property<string>("Icone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Icone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("IdModulo");

                    b.ToTable("Modulo", (string)null);
                });

            modelBuilder.Entity("Infraestrutura.Entity.Notificacao", b =>
                {
                    b.Property<int>("IdNotificacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNotificacao"), 1L, 1);

                    b.Property<int>("ClassficacaoMensagem")
                        .HasColumnType("int")
                        .HasColumnName("ClassficacaoMensagem");

                    b.Property<string>("Corpo")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)")
                        .HasColumnName("Corpo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<DateTime?>("DataVisualização")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataVisualização");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int>("Lido")
                        .HasColumnType("int")
                        .HasColumnName("Lido");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Titulo");

                    b.HasKey("IdNotificacao");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Notificacao", (string)null);
                });

            modelBuilder.Entity("Infraestrutura.Entity.Profissao", b =>
                {
                    b.Property<int>("IdProfissao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProfissao"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.HasKey("IdProfissao");

                    b.ToTable("Profissao", (string)null);
                });

            modelBuilder.Entity("Infraestrutura.Entity.SkillUsuario", b =>
                {
                    b.Property<int>("IdSkill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSkill"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdSkill");

                    b.HasIndex("IdUsuario");

                    b.ToTable("SkillUsuario", (string)null);
                });

            modelBuilder.Entity("Infraestrutura.Entity.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cidade");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cep");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cidade1");

                    b.Property<int?>("CodigoRecuperarSenha")
                        .HasColumnType("int")
                        .HasColumnName("CodigoRecuperarSenha");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("CPF");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNascimento");

                    b.Property<DateTime?>("DataRecuperacaoSenha")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataRecuperacaoSenha");

                    b.Property<int>("Dedicacao")
                        .HasColumnType("int")
                        .HasColumnName("Dedicacao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Estado");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genero")
                        .HasColumnType("int")
                        .HasColumnName("Genero");

                    b.Property<int?>("IdProfissao")
                        .HasColumnType("int")
                        .HasColumnName("IdProfissao");

                    b.Property<int?>("IdUsuarioCadastro")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeMae")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeMae");

                    b.Property<string>("NomePai")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomePai");

                    b.Property<int?>("Numero")
                        .HasColumnType("int")
                        .HasColumnName("Numero");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Observacao");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Pais");

                    b.Property<bool>("PerfilAdministrador")
                        .HasColumnType("bit")
                        .HasColumnName("PerfilAdministrador");

                    b.Property<string>("Rg")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Rg");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Rua");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Senha");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefone");

                    b.Property<int?>("TentativasRecuperarSenha")
                        .HasColumnType("int")
                        .HasColumnName("TentativasRecuperarSenha");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdProfissao");

                    b.HasIndex("IdUsuarioCadastro");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Infraestrutura.Entity.Menu", b =>
                {
                    b.HasOne("Infraestrutura.Entity.Modulo", "Modulo")
                        .WithMany("lMenus")
                        .HasForeignKey("IdModulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("Infraestrutura.Entity.Notificacao", b =>
                {
                    b.HasOne("Infraestrutura.Entity.Usuario", "Usuario")
                        .WithMany("LNotificacaoUsuarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Infraestrutura.Entity.SkillUsuario", b =>
                {
                    b.HasOne("Infraestrutura.Entity.Usuario", "Usuario")
                        .WithMany("LSkillUsuarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Infraestrutura.Entity.Usuario", b =>
                {
                    b.HasOne("Infraestrutura.Entity.Profissao", "Profissao")
                        .WithMany("LUsuario")
                        .HasForeignKey("IdProfissao");

                    b.HasOne("Infraestrutura.Entity.Usuario", "UsuarioFk")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCadastro");

                    b.Navigation("Profissao");

                    b.Navigation("UsuarioFk");
                });

            modelBuilder.Entity("Infraestrutura.Entity.Modulo", b =>
                {
                    b.Navigation("lMenus");
                });

            modelBuilder.Entity("Infraestrutura.Entity.Profissao", b =>
                {
                    b.Navigation("LUsuario");
                });

            modelBuilder.Entity("Infraestrutura.Entity.Usuario", b =>
                {
                    b.Navigation("LNotificacaoUsuarios");

                    b.Navigation("LSkillUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
