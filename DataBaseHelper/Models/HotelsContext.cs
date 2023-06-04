﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseHelper.Models;

public partial class HotelsContext : DbContext
{
    public HotelsContext()
    {
    }

    public HotelsContext(DbContextOptions<HotelsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5T0EOPC\\SQLEXPRESS;Initial Catalog=Hotels;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__2613FD24F71DC977");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("feedbackId");
            entity.Property(e => e.Comment)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.StarsCount).HasColumnName("starsCount");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Feedback__orderI__3F466844");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotels__17ADC4924BC95F3B");

            entity.Property(e => e.HotelId)
                .ValueGeneratedNever()
                .HasColumnName("hotelID");
            entity.Property(e => e.HotelName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("hotelName");
            entity.Property(e => e.LocationName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("locationName");
            entity.Property(e => e.StarsCount).HasColumnName("starsCount");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__0809335DDD29BDCB");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderId");
            entity.Property(e => e.DateEnd)
                .HasColumnType("date")
                .HasColumnName("dateEnd");
            entity.Property(e => e.DateStart)
                .HasColumnType("date")
                .HasColumnName("dateStart");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Orders)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__Orders__hotelId__3B75D760");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__userId__3C69FB99");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFFC88C3D12");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Mobile).HasColumnName("mobile");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
