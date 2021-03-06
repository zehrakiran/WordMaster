// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(WordMasterDbContext))]
    [Migration("20220420085526_initia")]
    partial class initia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.WordDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Word")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LangId");

                    b.ToTable("WordDefinitions");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.WordMeaning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Meaning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WordDefinitionId")
                        .HasColumnType("int");

                    b.Property<int?>("WordDefinitionId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LangId");

                    b.HasIndex("WordDefinitionId");

                    b.HasIndex("WordDefinitionId1");

                    b.ToTable("WordMeanings");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.WordDefinition", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Language", "Lang")
                        .WithMany()
                        .HasForeignKey("LangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lang");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.WordMeaning", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.Language", "Lang")
                        .WithMany()
                        .HasForeignKey("LangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Entities.Language", "wordDef")
                        .WithMany()
                        .HasForeignKey("WordDefinitionId");

                    b.HasOne("DataAccessLayer.Entities.WordDefinition", null)
                        .WithMany("WordMeanings")
                        .HasForeignKey("WordDefinitionId1");

                    b.Navigation("Lang");

                    b.Navigation("wordDef");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.WordDefinition", b =>
                {
                    b.Navigation("WordMeanings");
                });
#pragma warning restore 612, 618
        }
    }
}
