using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_8.Model
{
	public class Film
	{
		public int Idf { get; set; }
		public string Nazivf { get; set; }
		public int Trajanjef { get; set; }
		public string Godf { get; set; }
		public int Zanrf { get; set; }

		public Film(int idf, string nazivf, int trajanjef, string godf, int zanrf)
		{
			this.Idf = idf;
			this.Nazivf = nazivf;
			this.Trajanjef = trajanjef;
			this.Godf = godf;
			this.Zanrf = zanrf;
		}

		public static string GetForamttedHeader()
		{
			return string.Format("{0,-5} {1,-50} {2, -10} {3, -7} {4, -6}", "IDF", "NAZIV FILMA", "TRAJANJEF", "GODINA", "ZANRF");
		}

		public override string ToString()
		{
			return string.Format("{0,-5} {1,-50} {2, -10} {3, -7} {4, -6}", Idf, Nazivf, Trajanjef, Godf, Zanrf);
		}
	}
}
