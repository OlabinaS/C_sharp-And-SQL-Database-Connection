using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.Connection;
using Z3_PR_8.ConnectionPool;
using Z3_PR_8.DAO;
using Z3_PR_8.Model;
using Z3_PR_8.UIHandler;
using Z3_PR_8.Utils;
using Z3_PR_8.Service;
using System.Data.Common;

namespace Z3_PR_8.UIHandler
{
	public class KorisnikUIHandler
	{
		private static readonly KorisnickiServis korisnickiServis = new KorisnickiServis();
		public void HandlerKorisnikMenu()
		{
			String unos;

			do
			{
				Console.WriteLine("Odaberite opciju:");
				Console.WriteLine("1. --> Prikaz svih korisnika");
				Console.WriteLine("2. --> Prikazi po korisnickom imenu");
				Console.WriteLine("3. --> Unos ili izmena korisnika");
				Console.WriteLine("4. --> Unos vise korisnika");
				Console.WriteLine("5. --> Brisanje korisnika");
				Console.WriteLine("6. --> Brsianje svih korisnika");
				Console.WriteLine("7. --> Broj korisnika");
				Console.WriteLine("X --> Izlaz");

				unos = Console.ReadLine();
				Console.WriteLine();
				switch(unos)
				{
					case "1":
						PrikazSvih(); break;
					case "2":
						PrikazPoImenu(); break;
					case "3":
						UnosNovogKorisnika(); break;
					case "4":
						UnosViseKorisnia(); break;
					case "5":
						ObrisiKorisnika(); break;
					case "6":
						ObrisiSve(); break;
					case "7":
						Prebroj(); break;
				} 

			} while (!unos.ToUpper().Equals("X"));
		}

		private void PrikazSvih()
		{
			Console.WriteLine(Korisnik.GetFormattedHeader());

			try
			{
				foreach(Korisnik korisnik in korisnickiServis.FindAll())
				{
					Console.WriteLine(korisnik.ToString());
				}
				Console.WriteLine();
			}
			catch(DbException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void PrikazPoImenu()
		{
			Console.WriteLine("Korisnicko ime:");
			string id = Console.ReadLine();

			try
			{
				Korisnik korisnik = korisnickiServis.FindById(id);

				Console.WriteLine(Korisnik.GetFormattedHeader());
				Console.WriteLine(korisnik.ToString());
				Console.WriteLine();
			}
			catch(DbException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void UnosNovogKorisnika()
		{
			Console.WriteLine("KORIMEK: ");
			string korimek = Console.ReadLine();

			Console.WriteLine("IMEK: ");
			string imek = Console.ReadLine();

			Console.WriteLine("PRZK");
			string przk = Console.ReadLine();

			Console.WriteLine("POLK: ");
			string polk = Console.ReadLine();

			Console.WriteLine("AKTIVANK: ");
			string aktivank = Console.ReadLine();

			try
			{
				int isInserted = korisnickiServis.Save(new Korisnik(korimek, imek, przk, polk, aktivank));
				if(isInserted != 0)
				{
					Console.WriteLine($"Korisnik {korimek} je uspesno unet.");
				}
			}
			catch(DbException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void UnosViseKorisnia()
		{
			List<Korisnik> korisnickaLista = new List<Korisnik>();
			string unos;

			do
			{
				Console.WriteLine("KORIMEK: ");
				string korimek = Console.ReadLine();

				Console.WriteLine("IMEK: ");
				string imek = Console.ReadLine();

				Console.WriteLine("PRZK");
				string przk = Console.ReadLine();

				Console.WriteLine("POLK: ");
				string polk = Console.ReadLine();

				Console.WriteLine("AKTIVANK: ");
				string aktivank = Console.ReadLine();

				korisnickaLista.Add(new Korisnik(korimek, imek, przk, polk, aktivank));

				Console.WriteLine("Za unos jos jednog korisnika pritisnite ENTER, za izlazak pritisnite X");
				unos = Console.ReadLine();
			} while (!unos.ToUpper().Equals("X"));

			try
			{
				int numInserted = korisnickiServis.SaveAll(korisnickaLista);

				Console.WriteLine($"Uspesno je uneto {numInserted} korisnika.");
			}
			catch (DbException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}







		private void ObrisiKorisnika()
		{
			Console.WriteLine("Unesite korisnicko ime za brisanje");
			string id = Console.ReadLine();

			try
			{
				int isDeleted = korisnickiServis.DeleteById(id);

				if (isDeleted != 0)
				{
					Console.WriteLine($"Korisnik {id} je uspesno obrisan.");
				}
			}
			catch(DbException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void ObrisiSve()
		{
			try
			{
				int isDeleted = korisnickiServis.DeleteAll();

				if(isDeleted != 0)
				{
					Console.WriteLine("Svi korisnici su uspesno obrisanji");
				}
			}
			catch(DbException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void Prebroj()
		{
			Console.WriteLine("Broj korisnika je: {0}", korisnickiServis.Count());
			Console.WriteLine();
		}
	}
}
