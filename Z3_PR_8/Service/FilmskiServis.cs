using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.Model;
using Z3_PR_8.DAO;
using Z3_PR_8.DAO.Impl;

namespace Z3_PR_8.Service
{
	public class FilmskiServis
	{
		private static readonly IFilmDAO filmDAO = new FilmDAOImpl();

		public List<Film> FindAll()
		{
			return filmDAO.FindAll().ToList();
		}

		public List<Film> FindAllId(int id)
		{
			return filmDAO.FindAllId(id).ToList();
		}

		public string ZanrName(int id)
		{
			return filmDAO.ZanrName(id);
		}
	}
}
