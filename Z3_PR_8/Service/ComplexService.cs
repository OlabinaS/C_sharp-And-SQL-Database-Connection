using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.ConnectionPool;
using Z3_PR_8.DAO;
using Z3_PR_8.DAO.Impl;
using Z3_PR_8.Model;
using Z3_PR_8.Utils;

namespace Z3_PR_8.Service
{
	public class ComplexService
	{
		public void IspisIzvestaja4()
		{
			Console.WriteLine("Pol (M/Z): ");
			string pol = Console.ReadLine();

			Console.WriteLine(string.Format("{0, -6} {1, -20} {2, -6} {3, -7} {4, -8}", "IDO", "KORIMEO", "FILMO", "OCENAO", "VAZECAO"));

			IspisOcena(pol);
		}

		private void IspisOcena(string pol)
		{
			string upit = "select * " +
						  "from korisnik, ocena, film " +
						  "where korimek = korimeo and filmo = idf and polk = :polk";

			Korisnik korisnik = null;
			Ocena ocena = null;
			Film film = null;
			double suma_trajanja = 0, suma_ocena = 0;
			int cnt = 0;
			
			using(IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using(IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;

					Parametri.AddParameter(command, "polk", DbType.String);
					command.Prepare();

					Parametri.SetParameterValue(command, "polk", pol);

					using(IDataReader reader = command.ExecuteReader())
					{
						while(reader.Read())
						{
							korisnik = new Korisnik(reader.GetString(0), reader.GetString(1), reader.GetString(2),
													reader.GetString(3), reader.GetString(4));

							ocena = new Ocena(reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7),
											  reader.GetInt32(8), reader.GetString(9));

							film = new Film(reader.GetInt32(10), reader.GetString(11), reader.GetInt32(12),
											reader.GetString(13), reader.GetInt32(14));

							Console.WriteLine("{0, -6} {1, -20} {2, -6} {3, -7} {4, -8}", ocena.Ido, ocena.Korimeo, ocena.Filmo, ocena.Ocenao, ocena.Vazecao);

							suma_trajanja += film.Trajanjef;
							suma_ocena += ocena.Ocenao;
							cnt++;
						}
					}
				}
			}

			suma_trajanja = suma_trajanja / cnt;
			suma_ocena = suma_ocena / cnt;

			Console.WriteLine("Prosecna ocena: {0}\t Prosecno trajanje: {1}", suma_ocena, suma_trajanja);
			Console.WriteLine();
		}

		public void IspisIzvestaja6()
		{
			Console.WriteLine("Ocena: ");
			string ocena_str = Console.ReadLine();
			int ocena_int = Convert.ToInt32(ocena_str);

			Console.WriteLine();
			Console.WriteLine("Filmovi:");

			IspisFilmova(ocena_int);
			IspisNajstarijeg();
		}

		private void IspisFilmova(int unetaOcena)
		{
			string upit = "select * " +
						  "from film, ocena " +
						  "where filmo = idf and ocenao = :ocenao";

			Film film = null;
			Ocena ocena = null;

			int godina = 3000;
			double trajanje = 0;
			string naziv = "";

			using (IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using (IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;

					Parametri.AddParameter(command, "ocenao", DbType.Int32);
					command.Prepare();

					Parametri.SetParameterValue(command, "ocenao", unetaOcena);
					
					using(IDataReader reader = command.ExecuteReader())
					{
						while(reader.Read())
						{
							film = new Film(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
											reader.GetString(3), reader.GetInt32(4));

							ocena = new Ocena(reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7),
											  reader.GetInt32(8), reader.GetString(9));

							Console.WriteLine(film.Nazivf);
							if(Convert.ToInt32(film.Godf) < godina)
							{
								godina = Convert.ToInt32(film.Godf);
								trajanje = film.Trajanjef;
								naziv = film.Nazivf;
							}

						}
					}
				}
			}

			Console.WriteLine();
			if(trajanje != 0)
			{
				trajanje /= 60;

				Console.WriteLine($"Najstariji film sa zadatom ocenom je \"{naziv}\" i traje {Math.Round(trajanje, 2)} sati.");
			}
			else
			{
				Console.WriteLine("Nema filmova sa zadatom ocenom.");
			}
		}

		private void IspisNajstarijeg()
		{
			string upit = "select * " +
						  "from film, ocena " +
						  "where filmo = idf";

			Film film = null;
			Ocena ocena = null;

			int godina = 3000;
			double trajanje = 0;
			string naziv = "";

			using (IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using (IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;
					command.Prepare();

					using (IDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							film = new Film(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
											reader.GetString(3), reader.GetInt32(4));

							ocena = new Ocena(reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7),
											  reader.GetInt32(8), reader.GetString(9));

							if (Convert.ToInt32(film.Godf) < godina)
							{
								godina = Convert.ToInt32(film.Godf);
								trajanje = film.Trajanjef;
								naziv = film.Nazivf;
							}

						}
					}
				}
			}

			Console.WriteLine();

			trajanje /= 60;

			Console.WriteLine($"Najstariji film je \"{naziv}\" i traje {Math.Round(trajanje, 2)} sati.");
			Console.WriteLine();
		}
	}
}
