using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoCrud.Models;

namespace ProyectoCrud.DAL.DataContext
{
    public partial class DBPRUEBASContext : DbContext
    {
        public DBPRUEBASContext()
        {
        }

        public DBPRUEBASContext(DbContextOptions<DBPRUEBASContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            

            modelBuilder.Entity<Inventario>(entity =>
            {
                // Clave primaria compuesta
                entity.HasKey(e => new
                {
                    e.CodCia,
                    e.CompaniaVenta3,
                    e.AlmacenVenta,
                    e.TipoMovimiento,
                    e.TipoDocumento,
                    e.NroDocumento,
                    e.CodItem2
                })
                .HasName("PK_MOV_INVENTARIO");

                // Nombre de la tabla
                entity.ToTable("MOV_INVENTARIO");

                // Columnas obligatorias (not null) y longitudes
                entity.Property(e => e.CodCia)
                    .HasColumnName("COD_CIA")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.CompaniaVenta3)
                    .HasColumnName("COMPANIA_VENTA_3")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.AlmacenVenta)
                    .HasColumnName("ALMACEN_VENTA")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.TipoMovimiento)
                    .HasColumnName("TIPO_MOVIMIENTO")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.TipoDocumento)
                    .HasColumnName("TIPO_DOCUMENTO")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.NroDocumento)
                    .HasColumnName("NRO_DOCUMENTO")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.CodItem2)
                    .HasColumnName("COD_ITEM_2")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

                // Columnas opcionales
                entity.Property(e => e.Proveedor)
                    .HasColumnName("PROVEEDOR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AlmacenDestino)
                    .HasColumnName("ALMACEN_DESTINO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cantidad)
                    .HasColumnName("CANTIDAD");

                entity.Property(e => e.DocRef1)
                    .HasColumnName("DOC_REF_1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocRef2)
                    .HasColumnName("DOC_REF_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocRef3)
                    .HasColumnName("DOC_REF_3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocRef4)
                    .HasColumnName("DOC_REF_4")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocRef5)
                    .HasColumnName("DOC_REF_5")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                // Fecha de transacción como DATE
                entity.Property(e => e.FechaTransaccion)
                    .HasColumnName("FECHA_TRANSACCION")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
