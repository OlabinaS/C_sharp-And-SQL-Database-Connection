using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.Service;
using Z3_PR_8.Model;
using System.Data.Common;

namespace Z3_PR_8.UIHandler
{
	public class FilmUIHandler
	{
		private static readonly FilmskiServis filmskiServis = new FilmskiServis();

		public void HandlerFilmMenu()
		{
			string unos;

			do
			{
				Console.WriteLine("Odaberite opciju:");
				Console.WriteLine("1. --> Prikaz svih Filmova");
				Console.WriteLine("2. --> Prikazi filmova po znaru");
				Console.WriteLine("X --> Izlaz");

				unos = Console.ReadLine();
				Console.WriteLine();
				switch (unos)
				{
					case "1":
						PrikazSvih(); break;
					case "2":
						PrikazPoZanru(); break;
				}
			} while (!unos.ToUpper().Equals("X"));
		}

		private void PrikazSvih()
		{
			Console.WriteLine(Film.GetForamttedHeader());
			Console.WriteLine();

			try
			{
				foreach(Film film in filmskiServis.FindAll())
				{
					Console.WriteLine(film.ToString());
				}
				Console.WriteLine();
			}
			catch(DbException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void PrikazPoZanru()
		{
			Console.WriteLine("Odaberite broj zanra:");
			int id = Convert.ToInt32(Console.ReadLine());

			try
			{
				Console.WriteLine(filmskiServis.ZanrName(id));

				foreach(Film film in filmskiServis.FindAllId(id))
				{
					Console.WriteLine(string.Format("{0,-5} {1, -30} {2, -7}", film.Idf, film.Nazivf, film.Godf));
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
