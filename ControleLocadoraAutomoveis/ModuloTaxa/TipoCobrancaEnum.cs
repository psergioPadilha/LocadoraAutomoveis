using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocadoraAutomoveis.Dominio.ModuloTaxa;

public enum TipoCobrancaEnum
{
	[Display(Name = "Diária")]
	Diaria,
	Fixa
}
