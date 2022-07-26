using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.Model;
using Z3_PR_8.Service;

namespace Z3_PR_8.UIHandler
{
	public class ZanrUIHandler
	{
		private static readonly ZanrServis zanrServis = new ZanrServis();

		public void HandlerZanrMenu()
		{
			string unos;

			do
			{
				Console.WriteLine("Odaberite opciju:");
				Console.WriteLine("1. --> Prikaz svih zanrova");
				//Console.WriteLine("2. --> ");
				Console.WriteLine("X --> Izlaz");

				unos = Console.ReadLine();
				Console.WriteLine();

				switch (unos)
				{
					case "1":
						PrikazSvih(); break;
				}
			} while (!unos.ToUpper().Equals("X"));
		}

		public void PrikazSvih()
		{
			Console.WriteLine(Zanr.GetForamttedHeader());
			Console.WriteLine();

			try
			{
				foreach (Zanr zanr in zanrServis.FindAll())
				{
					Console.WriteLine(zanr.ToString());
				}
				Console.WriteLine();
			}
			catch(DbException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
