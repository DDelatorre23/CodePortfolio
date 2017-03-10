using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CommunityWebSite.Models;

namespace CommunityWebSite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170215232634_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommunityWebSite.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("MemberID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CommunityWebSite.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("SenderMemberID");

                    b.Property<string>("Subject");

                    b.Property<string>("Topic");

                    b.HasKey("MessageID");

                    b.HasIndex("SenderMemberID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CommunityWebSite.Models.Message", b =>
                {
                    b.HasOne("CommunityWebSite.Models.Member", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderMemberID");
                });
        }
    }
}
