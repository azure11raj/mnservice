using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MnCloudService.Models;

public partial class MnCloudContext : DbContext
{
    public MnCloudContext()
    {
    }

    public MnCloudContext(DbContextOptions<MnCloudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MnTblUser> MnTblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Data Source=LAPTOP-E6N19S8K;Initial Catalog=MnCloud;Integrated Security=True;Trust Server Certificate=True");
        => optionsBuilder.UseSqlServer("Data Source=178.212.35.110;Initial Catalog=Nlabs_MNC; connect timeout = 350; Max Pool Size=2500; uid=Mnc;password=7mbhz7?2jNMje4Hfs; Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MnTblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__MN_tblUs__1788CC4C3400F68F");

            entity.ToTable("MN_tblUser");

            entity.Property(e => e.Createddatetime).HasColumnType("datetime");
            entity.Property(e => e.Message)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Updateddatetime).HasColumnType("datetime");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(225)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
