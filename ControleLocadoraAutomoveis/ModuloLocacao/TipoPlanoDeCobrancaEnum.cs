using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocadoraAutomoveis.Dominio.ModuloLocacao;

public enum TipoPlanoDeCobrancaEnum
{
	[Display(Name = "Diário")] Diario, Controlado, Livre
}