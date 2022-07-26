using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.ConnectionPool;
using Z3_PR_8.Model;
using Z3_PR_8.DAO;
using Z3_PR_8.Utils;

namespace Z3_PR_8.DAO.Impl
{
	public class KorisnikDAOImpl : IKorisnikDAO
	{
		public int Count()
		{
			string upit = "select count(korimek) from korisnik";

			using (IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using(IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;
					command.Prepare();

					return Convert.ToInt32(command.ExecuteScalar());
				}
			}
		}

		public int Delete(Korisnik entity)
		{
			return DeleteById(entity.Korimek);
		}

		public int DeleteAll()
		{
			string upit = "delete from korisnik";

			using(IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using(IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;
					command.Prepare();

					return command.ExecuteNonQuery();
				}
			}
		}

		public int DeleteById(string key)
		{
			string upit = "delete from korisnik where korimek=:korimek";

			using(IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using(IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;
					Parametri.AddParameter(command, "korimek", DbType.String);
					command.Prepare();
					Parametri.SetParameterValue(command, "korimek", key);

					return command.ExecuteNonQuery();
				}
			}
		}

		public bool ExistsById(string id)
		{
			using(IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				return ExistsById(id, connection);
			}
		}

		private bool ExistsById(string id, IDbConnection connection)
		{
			string upit = "select * from korisnik where korimek=:korimek";

			using (IDbCommand command = connection.CreateCommand())
			{
				command.CommandText = upit;
				Parametri.AddParameter(command, "korimek", DbType.String);
				command.Prepare();

				Parametri.SetParameterValue(command, "korimek", id);

				return command.ExecuteScalar() != null;
			}
		}

		public IEnumerable<Korisnik> FindAll()
		{
			string upit = "select * from korisnik";

			List<Korisnik> korisnikList = new List<Korisnik>();

			using (IDbConnection connection = Connection_Pool.GetConnection())
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
							Korisnik korisnik = new Korisnik(reader.GetString(0), reader.GetString(1), reader.GetString(2),
															 reader.GetString(3), reader.GetString(4));
							korisnikList.Add(korisnik);
						}
					}	
				}
			}

			return korisnikList;
		}

		public IEnumerable<Korisnik> FindAllById(IEnumerable<string> ids)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("select korimek, imek, przk, polk, aktivank from korisnik where korimek in (");
			foreach (string id in ids)
			{
				sb.Append(":id" + id + ",");
			}
			sb.Remove(sb.Length - 1, 1);
			sb.Append(")");

			List<Korisnik> korisnikList = new List<Korisnik>();

			using(IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using(IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = sb.ToString();
					foreach(string id in ids)
					{
						Parametri.AddParameter(command, id, DbType.String);
					}
					command.Prepare();

					foreach(string id in ids)
					{
						Parametri.SetParameterValue(command, "id" + id, id);
					}
					using(IDataReader reader = command.ExecuteReader())
					{
						while(reader.Read())
						{
							Korisnik korisnik = new Korisnik(reader.GetString(0), reader.GetString(1), reader.GetString(2),
															 reader.GetString(3), reader.GetString(4));

							korisnikList.Add(korisnik);
						}
					}
				}
			}

			return korisnikList;
		}

		public Korisnik FindById(string id)
		{
			string upit = "select korimek, imek, przk, polk, aktivank " +
				"from korisnik where korimek = :korimek";
			Korisnik korisnik = null;

			using(IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using(IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;

					Parametri.AddParameter(command, "korimek", DbType.String);
					command.Prepare();

					Parametri.SetParameterValue(command, "korimek", id);
					using(IDataReader reader = command.ExecuteReader())
					{
						if(reader.Read())
						{
							korisnik = new Korisnik(reader.GetString(0), reader.GetString(1), reader.GetString(2),
													reader.GetString(3), reader.GetString(4));
						}
					}
				}
			}

			return korisnik;
		}

		public int Save(Korisnik entity)
		{
			using (IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				return Save(entity, connection);
			}
		}

		private int Save(Korisnik entity, IDbConnection connection)
		{
			string insert = "insert into korisnik(korimek, imek, przk, polk, aktivank ) values (:korimek, :imek, :przk, :polk, :aktivank)";
			string update = "update korisnik set imek=:imek, przk=:przk, polk=:polk, aktivank=:aktivank" +
				"where korimek=:korimek";

			using(IDbCommand command = connection.CreateCommand())
			{
				command.CommandText = ExistsById(entity.Korimek, connection) ? update : insert;
				Parametri.AddParameter(command, "korimek", DbType.String, 30);
				Parametri.AddParameter(command, "imek", DbType.String, 30);
				Parametri.AddParameter(command, "przk", DbType.String, 30);
				Parametri.AddParameter(command, "polk", DbType.String, 1);
				Parametri.AddParameter(command, "aktivank", DbType.String, 1);
				command.Prepare();

				Parametri.SetParameterValue(command, "korimek", entity.Korimek);
				Parametri.SetParameterValue(command, "imek", entity.Imek);
				Parametri.SetParameterValue(command, "przk", entity.Przk);
				Parametri.SetParameterValue(command, "polk", entity.Polk);
				Parametri.SetParameterValue(command, "aktivank", entity.Aktivank);

				return command.ExecuteNonQuery();
			}
		}

		public int SaveAll(IEnumerable<Korisnik> entities)
		{
			using (IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				IDbTransaction transaction = connection.BeginTransaction();

				int saved = 0;

				foreach(Korisnik korisnik in entities)
				{
					saved += Save(korisnik, connection);
				}

				transaction.Commit();

				return saved;
			}
		}
	}
}
