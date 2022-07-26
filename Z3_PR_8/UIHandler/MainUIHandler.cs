using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.Service;

namespace Z3_PR_8.UIHandler
{
	public class MainUIHandler
	{
		private static readonly KorisnikUIHandler korisnikUIHandler = new KorisnikUIHandler();
		private static readonly ZanrUIHandler zanrUIHandler = new ZanrUIHandler();
		private static readonly FilmUIHandler filmUIHandler = new FilmUIHandler();
		private static readonly ComplexService complexService = new ComplexService();
		public void HandleMainMenu()
		{
			string unos;
			do
			{
				Console.WriteLine("Odaberite opciju:");
				Console.WriteLine("1. --> Rukovanje korisnicima");
				Console.WriteLine("2. --> Rukovanje zanrovima");
				Console.WriteLine("3. --> Rukovanje filmovima");
				Console.WriteLine("4. --> Izvestaj 4.");
				Console.WriteLine("5. --> Izvestaj 6.");
				Console.WriteLine("X --> Izlaz");

				unos = Console.ReadLine();
				Console.WriteLine();

				switch (unos)
				{
					case "1":
						korisnikUIHandler.HandlerKorisnikMenu(); break;
					case "2":
						zanrUIHandler.HandlerZanrMenu(); break;
					case "3":
						filmUIHandler.HandlerFilmMenu(); break;
					case "4":
						complexService.IspisIzvestaja4(); break;
					case "5":
						complexService.IspisIzvestaja6(); break;
				}
			} while (!unos.ToUpper().Equals("X"));
		}
	}
}
