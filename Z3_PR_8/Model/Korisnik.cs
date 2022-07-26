using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_8.Model
{
	public class Korisnik
	{
		public string Korimek { get; set; }
		public string Imek { get; set; }
		public string Przk { get; set; }
		public string Polk { get; set; }
		public string Aktivank { get; set; }

		public Korisnik(string korimek, string imek, string przk, string polk, string aktivank)
		{
			this.Korimek = korimek;
			this.Imek = imek;
			this.Przk = przk;
			this.Polk = polk;
			this.Aktivank = aktivank;
		}

		public static string GetFormattedHeader()
		{
			return string.Format("{0,-20} {1,-12} {2,-12} {3,-6} {4,-9}", 
								"KORIMEK", "IME", "PREZIME", "POL", "AKTIVAN");
		}

		public override string ToString()
		{
			return string.Format("{0,-20} {1,-12} {2,-12} {3,-6} {4,-9}",
								Korimek, Imek, Przk, Polk, Aktivank);
		}
	}
}
