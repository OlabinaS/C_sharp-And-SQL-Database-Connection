using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_8.Model
{
	public class Ocena
	{
		public int Ido { get; set; }
		public int Ocenao { get; set; }
		public string Vazecao { get; set; }
		public int Filmo { get; set; }
		public string Korimeo { get; set; }

		public Ocena(int ido, int ocenao, string vazecao, int filmo, string korimeo)
		{
			this.Ido = ido;
			this.Ocenao = ocenao;
			this.Vazecao = vazecao;
			this.Filmo = filmo;
			this.Korimeo = korimeo;
		}
	}
}
