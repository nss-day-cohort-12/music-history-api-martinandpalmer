using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using api_music_history.Models;

namespace apimusichistory.Migrations
{
    [DbContext(typeof(MusicHistoryContext))]
    [Migration("20160610162820_FixKeys3")]
    partial class FixKeys3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api_music_history.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artist");

                    b.Property<string>("Title");

                    b.Property<int>("Year");

                    b.HasKey("AlbumId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("api_music_history.Models.AppUser", b =>
                {
                    b.Property<int>("AppUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Username");

                    b.HasKey("AppUserId");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("api_music_history.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<int>("AppUserId");

                    b.Property<string>("Author");

                    b.Property<string>("Genre");

                    b.Property<string>("Title");

                    b.HasKey("TrackId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("AppUserId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("api_music_history.Models.Track", b =>
                {
                    b.HasOne("api_music_history.Models.Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api_music_history.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
