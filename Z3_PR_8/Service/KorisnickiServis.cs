using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.DAO;
using Z3_PR_8.DAO.Impl;
using Z3_PR_8.Model;
using Z3_PR_8.UIHandler;

namespace Z3_PR_8.Service
{
	public class KorisnickiServis
	{
		private static readonly IKorisnikDAO korisnikDAO = new KorisnikDAOImpl();

		public List<Korisnik> FindAll()
		{
			return korisnikDAO.FindAll().ToList();
		}

		public Korisnik FindById(string id)
		{
			return korisnikDAO.FindById(id);
		}

		public int Save(Korisnik korisnik)
		{
			return korisnikDAO.Save(korisnik);
		}

		public int SaveAll(List<Korisnik> korisnickaLista)
		{
			return korisnikDAO.SaveAll(korisnickaLista);
		}

		public int DeleteById(string id)
		{
			return korisnikDAO.DeleteById(id);
		}

		public int DeleteAll()
		{
			return korisnikDAO.DeleteAll();
		}

		public int Count()
		{
			return korisnikDAO.Count();
		}

	}
}
