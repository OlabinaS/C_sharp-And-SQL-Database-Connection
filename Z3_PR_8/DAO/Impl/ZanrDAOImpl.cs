using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.Model;
using Z3_PR_8.DAO;
using System.Data;
using Z3_PR_8.ConnectionPool;
using Z3_PR_8.Connection;

namespace Z3_PR_8.DAO.Impl
{
	public class ZanrDAOImpl : IZanrDAO
	{
		public int Count()
		{
			throw new NotImplementedException();
		}

		public int Delete(Zanr entity)
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

		public IEnumerable<Zanr> FindAll()
		{
			string upit = "select * from zanr";

			List<Zanr> zanrLista = new List<Zanr>();

			using(IDbConnection connection = Connection_Pool.GetConnection())
			{
				connection.Open();
				using(IDbCommand command = connection.CreateCommand())
				{
					command.CommandText = upit;
					command.Prepare();

					using(IDataReader reader = command.ExecuteReader())
					{
						while(reader.Read())
						{
							Zanr zanr = new Zanr(reader.GetInt32(0), reader.GetString(1));
							zanrLista.Add(zanr);
						}
					}
				}
			}
			return zanrLista;
		}

		public IEnumerable<Zanr> FindAllById(IEnumerable<int> ids)
		{
			throw new NotImplementedException();
		}

		public Zanr FindById(int id)
		{
			throw new NotImplementedException();
		}

		public int Save(Zanr entity)
		{
			throw new NotImplementedException();
		}

		public int SaveAll(IEnumerable<Zanr> entities)
		{
			throw new NotImplementedException();
		}
	}
}
