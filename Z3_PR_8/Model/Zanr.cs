using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_8.Model
{
	public class Zanr
	{
		public int Idz { get; set; }
		public string Nazivz { get; set; }

		public Zanr(int idz, string nazivz)
		{
			this.Idz = idz;
			this.Nazivz = nazivz;
		}

		public static string GetForamttedHeader()
		{
			return string.Format("{0,-5} {1,-25}", "IDZ", "NAZIV ZANRA");
		}

		public override string ToString()
		{
			return string.Format("{0,-4} {1,-25}", Idz, Nazivz);
		}
	}
}
