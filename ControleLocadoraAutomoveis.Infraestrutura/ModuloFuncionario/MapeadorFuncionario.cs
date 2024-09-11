using ControleLocadoraAutomoveis.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleLocadoraAutomoveis.Infraestrutura.ModuloFuncionario;

public class MapeadorFuncionario : IEntityTypeConfiguration<Funcionario>
{
	public void Configure(EntityTypeBuilder<Funcionario> builder)
	{
		builder.ToTable("TBFuncionario");

		builder.Property(f => f.Id)
			.HasColumnType("int")
			.ValueGeneratedOnAdd()
			.IsRequired();

		builder.Property(f => f.Nome)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(f => f.Email)
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(f => f.DataAdmissão)
			.HasColumnType("datetime2")
			.IsRequired();

		builder.Property(f => f.Salario)
			.HasColumnType("decimal(18,2)")
			.IsRequired();

		builder.Property(c => c.IdEmpresa)
			.HasColumnType("int")
			.IsRequired();

		builder.HasOne(c => c.Empresa)
			.WithMany()
			.HasForeignKey(f => f.IdEmpresa)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(c => c.IdUsuario)
			.HasColumnType("int")
			.IsRequired();
	}
}