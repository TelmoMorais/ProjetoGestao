﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoGestao.Data;

namespace ProjetoGestao.Migrations
{
    [DbContext(typeof(ProjetoGestaoContext))]
    [Migration("20211112135332_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NovoColaboradorNovoProjeto", b =>
                {
                    b.Property<int>("ColaboradorsNovoColaboradorId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetosNovoProjetoId")
                        .HasColumnType("int");

                    b.HasKey("ColaboradorsNovoColaboradorId", "ProjetosNovoProjetoId");

                    b.HasIndex("ProjetosNovoProjetoId");

                    b.ToTable("NovoColaboradorNovoProjeto");
                });

            modelBuilder.Entity("ProjetoGestao.Models.NovoColaborador", b =>
                {
                    b.Property<int>("NovoColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeColaborador")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("NovoColaboradorId");

                    b.ToTable("NovoColaborador");
                });

            modelBuilder.Entity("ProjetoGestao.Models.NovoGestor", b =>
                {
                    b.Property<int>("NovoGestorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeGestor")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("NovoGestorId");

                    b.ToTable("NovoGestor");
                });

            modelBuilder.Entity("ProjetoGestao.Models.NovoProjeto", b =>
                {
                    b.Property<int>("NovoProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescricaoProjeto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("NovoGestorId")
                        .HasColumnType("int");

                    b.HasKey("NovoProjetoId");

                    b.HasIndex("NovoGestorId");

                    b.ToTable("NovoProjeto");
                });

            modelBuilder.Entity("NovoColaboradorNovoProjeto", b =>
                {
                    b.HasOne("ProjetoGestao.Models.NovoColaborador", null)
                        .WithMany()
                        .HasForeignKey("ColaboradorsNovoColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoGestao.Models.NovoProjeto", null)
                        .WithMany()
                        .HasForeignKey("ProjetosNovoProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoGestao.Models.NovoProjeto", b =>
                {
                    b.HasOne("ProjetoGestao.Models.NovoGestor", "NovoGestor")
                        .WithMany("Projetos")
                        .HasForeignKey("NovoGestorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NovoGestor");
                });

            modelBuilder.Entity("ProjetoGestao.Models.NovoGestor", b =>
                {
                    b.Navigation("Projetos");
                });
#pragma warning restore 612, 618
        }
    }
}
