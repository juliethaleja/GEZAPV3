using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GEZAPV3.Models
{
    public partial class DataBaseProyectoContext : DbContext
    {
        public DataBaseProyectoContext()
        {
        }

        public DataBaseProyectoContext(DbContextOptions<DataBaseProyectoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cambio> Cambios { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Ingreso> Ingresos { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<MarcaCateg> MarcaCategs { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<TipoCambio> TipoCambios { get; set; }
        public virtual DbSet<TipoPersona> TipoPersonas { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:proyectouni.database.windows.net,1433;Initial Catalog=DataBaseProyecto;Persist Security Info=False;User ID=adminPrincipal;Password=CeroUno01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cambio>(entity =>
            {
                entity.HasKey(e => e.IdCambios)
                    .HasName("PK__CAMBIOS__DC1EFE51D3958933");

                entity.ToTable("CAMBIOS");

                entity.Property(e => e.IdCambios).HasColumnName("ID_CAMBIOS");

                entity.Property(e => e.CodProducto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COD_PRODUCTO");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.IdTipoC).HasColumnName("ID_TIPO_C");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.Cambios)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CAMBIOS__COD_PRO__18EBB532");

                entity.HasOne(d => d.IdTipoCNavigation)
                    .WithMany(p => p.Cambios)
                    .HasForeignKey(d => d.IdTipoC)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CAMBIOS__ID_TIPO__19DFD96B");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__CATEGORI__4BD51FA57828419A");

                entity.ToTable("CATEGORIAS");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CATEGORIA");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__DETALLE___4A921BED587F86ED");

                entity.ToTable("DETALLE_FACTURA");

                entity.Property(e => e.IdFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_FACTURA");

                entity.Property(e => e.CantidadVenta).HasColumnName("CANTIDAD_VENTA");

                entity.Property(e => e.CodProducto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COD_PRODUCTO");

                entity.Property(e => e.IdDetalle)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_DETALLE");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLE_F__COD_P__2CF2ADDF");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithOne(p => p.DetalleFactura)
                    .HasForeignKey<DetalleFactura>(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLE_F__ID_FA__2DE6D218");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__FACTURAS__4A921BED5A88112E");

                entity.ToTable("FACTURAS");

                entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");

                entity.Property(e => e.DIdentidad).HasColumnName("D_IDENTIDAD");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdCodF)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ID_COD_F")
                    .HasComputedColumnSql("(right('0000'+CONVERT([varchar],[ID_FACTURA]),(4)))", false);

                entity.HasOne(d => d.DIdentidadNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.DIdentidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FACTURAS__D_IDEN__2A164134");
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.HasKey(e => e.IdIngreso)
                    .HasName("PK__INGRESO__627D3FC4826E4846");

                entity.ToTable("INGRESO");

                entity.Property(e => e.IdIngreso).HasColumnName("ID_INGRESO");

                entity.Property(e => e.DescripcionEstado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION_ESTADO");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_INGRESO");

                entity.Property(e => e.Impuesto).HasColumnName("IMPUESTO");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdBodega)
                    .HasName("PK__INVENTAR__4983276178EDA8E2");

                entity.ToTable("INVENTARIOS");

                entity.Property(e => e.IdBodega)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ID_BODEGA");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.CodProducto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COD_PRODUCTO");

                entity.Property(e => e.IdIngreso).HasColumnName("ID_INGRESO");

                entity.Property(e => e.PrecioC).HasColumnName("PRECIO_C");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVENTARI__COD_P__208CD6FA");

                entity.HasOne(d => d.IdIngresoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdIngreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVENTARI__ID_IN__2180FB33");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__MARCAS__A9FDC4BBB1D30C7B");

                entity.ToTable("MARCAS");

                entity.Property(e => e.IdMarca).HasColumnName("ID_MARCA");

                entity.Property(e => e.NombreMarca)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_MARCA");
            });

            modelBuilder.Entity<MarcaCateg>(entity =>
            {
                entity.HasKey(e => e.IdMarcaCateg)
                    .HasName("PK__MARCA_CA__C4D18B13D583509F");

                entity.ToTable("MARCA_CATEG");

                entity.Property(e => e.IdMarcaCateg).HasColumnName("ID_MARCA_CATEG");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.IdMarca).HasColumnName("ID_MARCA");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.MarcaCategs)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MARCA_CAT__ID_CA__10566F31");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.MarcaCategs)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MARCA_CAT__ID_MA__114A936A");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.DIdentidad)
                    .HasName("PK__PERSONA__924008C6DFA3B653");

                entity.ToTable("PERSONA");

                entity.Property(e => e.DIdentidad)
                    .ValueGeneratedNever()
                    .HasColumnName("D_IDENTIDAD");

                entity.Property(e => e.CElectronico)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("C_ELECTRONICO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.FNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("F_NACIMIENTO");

                entity.Property(e => e.IdTipoP).HasColumnName("ID_TIPO_P");

                entity.Property(e => e.IdUsers).HasColumnName("ID_USERS");

                entity.Property(e => e.PApellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("P_APELLIDO");

                entity.Property(e => e.PNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("P_NOMBRE");

                entity.Property(e => e.SApellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("S_APELLIDO");

                entity.Property(e => e.SNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("S_NOMBRE");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SEXO");

                entity.Property(e => e.Telefono).HasColumnName("TELEFONO");

                entity.Property(e => e.TipoD)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_D");

                entity.HasOne(d => d.IdTipoPNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdTipoP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PERSONA__ID_TIPO__2645B050");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdUsers)
                    .HasConstraintName("FK__PERSONA__ID_USER__2739D489");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodProducto)
                    .HasName("PK__PRODUCTO__8DF7FD2D27AF29CB");

                entity.ToTable("PRODUCTOS");

                entity.Property(e => e.CodProducto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COD_PRODUCTO");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("COLOR");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.IdProducto)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.PrecioVenta).HasColumnName("PRECIO_VENTA");

                entity.Property(e => e.Stock).HasColumnName("STOCK");

                entity.Property(e => e.Talla).HasColumnName("TALLA");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUCTOS__ID_CA__14270015");
            });

            modelBuilder.Entity<TipoCambio>(entity =>
            {
                entity.HasKey(e => e.IdTipoC)
                    .HasName("PK__TIPO_CAM__5D7025199D139B23");

                entity.ToTable("TIPO_CAMBIO");

                entity.Property(e => e.IdTipoC).HasColumnName("ID_TIPO_C");

                entity.Property(e => e.NombreC)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_C");
            });

            modelBuilder.Entity<TipoPersona>(entity =>
            {
                entity.HasKey(e => e.IdTipoP)
                    .HasName("PK__TIPO_PER__5D7025EA492CBCF3");

                entity.ToTable("TIPO_PERSONA");

                entity.Property(e => e.IdTipoP).HasColumnName("ID_TIPO_P");

                entity.Property(e => e.NombreP)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_P");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUsers)
                    .HasName("PK__USERS__1DDB35C3D64F0DF6");

                entity.ToTable("USERS");

                entity.Property(e => e.IdUsers).HasColumnName("ID_USERS");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASEÑA");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
