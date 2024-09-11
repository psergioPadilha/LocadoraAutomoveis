using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocadoraAutomoveis.Dominio.ModuloLocacao;

public enum MarcadorCombustivelEnum
{
	Vazio,
	[Display(Name = "Um Quarto")] UmQuarto,
	[Display(Name = "Meio Tanque")] MeioTanque,
	[Display(Name = "Três Quarto")] TresQuartos,
	Completo
}