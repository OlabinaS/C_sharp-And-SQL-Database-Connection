using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.Model;
using Z3_PR_8.Service;
using Z3_PR_8.ConnectionPool;
using Z3_PR_8.Connection;
using System.Data;
using Z3_PR_8.Utils;

namespace Z3_PR_8.DAO.Impl
{
	public class FilmDAOImpl : IFilmDAO
	{
		public int Count()
		{
			throw new NotImplementedException();
		}

		public int Delete(Film entity)
		{
			throw new NotImplementedException();
		}

		public int DeleteAll()
		{
			throw new NotImplementedException();
		}

		public int DeleteById(int id)
		{
			throw new NotImplementedException();
		}

		public bool ExistsById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Film> FindAll()
		{
			string upit = "select * from film";

			List<Film> filmskaLista = new List<Film>();
			using(IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using (IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;
					command.Prepare();

					using(IDataReader reader = command.ExecuteReader())
					{
						while(reader.Read())
						{
							Film film = new Film(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), 
												 reader.GetString(3), reader.GetInt32(4));
							filmskaLista.Add(film);
						}
					}
				}
			}
			return filmskaLista;
		}

		public IEnumerable<Film> FindAllById(IEnumerable<int> ids)
		{
			throw new NotImplementedException();
		}

		public Film FindById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Film> FindAllId(int id)
		{
			string upit = "select * from film where zanrf=:zanrf";
			List<Film> filmskaLista = new List<Film>();

			using (IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using (IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;

					Parametri.AddParameter(command, "zanrf", DbType.Int32);
					command.Prepare();

					Parametri.SetParameterValue(command, "zanrf", id);
					using (IDataReader reader = command.ExecuteReader())
					{
						while(reader.Read())
						{
							Film film = new Film(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
													reader.GetString(3), reader.GetInt32(4));
							filmskaLista.Add(film);
						}
					}
				}
			}

			return filmskaLista;
		}

		public int Save(Film entity)
		{
			throw new NotImplementedException();
		}

		public int SaveAll(IEnumerable<Film> entities)
		{
			throw new NotImplementedException();
		}

		public string ZanrName(int id)
		{
			string upit = "select nazivz from zanr where idz = :idz";
			string naziv = "";

			using (IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using (IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;

					Parametri.AddParameter(command, "idz", DbType.Int32);
					command.Prepare();

					Parametri.SetParameterValue(command, "idz", id);
					using(IDataReader reader = command.ExecuteReader())
					{
						if(reader.Read())
						{
							naziv += reader.GetString(0);
						}
					}
				}
			}
			return naziv;
		}
	}
}
