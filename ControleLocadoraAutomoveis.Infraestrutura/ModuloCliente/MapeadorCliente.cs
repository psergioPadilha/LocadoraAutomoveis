using ControleLocadoraAutomoveis.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloCliente;
public class MapeadorCliente : IEntityTypeConfiguration<Cliente>
{
	public void Configure(EntityTypeBuilder<Cliente> builder)
	{
		builder.ToTable("TBCliente");

		builder.Property(c => c.Id)
			.HasColumnType("int")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(c => c.Nome)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(c => c.Email)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(c => c.Telefone)
			.HasColumnType("varchar(15)")
			.IsRequired();

		builder.Property(c => c.TipoCliente)
			.HasColumnType("int")
			.IsRequired();

		builder.Property(c => c.NumeroDocumento)
			.HasColumnType("varchar(20)")
			.IsRequired();

		builder.Property(c => c.Estado)
			.HasColumnType("varchar(50)")
			.IsRequired();

		builder.Property(c => c.Cidade)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(c => c.Bairro)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(c => c.Rua)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(c => c.NumeroEndereco)
			.HasColumnType("varchar(10)")
			.IsRequired();

		builder.Property(s => s.IdEmpresa)
			.HasColumnType("int")
			.HasColumnName("Id_Empresa")
			.IsRequired();

		builder.HasOne(g => g.Empresa)
			.WithMany()
			.HasForeignKey(s => s.IdEmpresa)
			.OnDelete(DeleteBehavior.Restrict);
	}
}