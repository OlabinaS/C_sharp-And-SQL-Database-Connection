using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.DAO;
using Z3_PR_8.Model;
using Z3_PR_8.DAO.Impl;

namespace Z3_PR_8.Service
{
	public class ZanrServis
	{
		private static readonly IZanrDAO zanrDAO = new ZanrDAOImpl();

		public List<Zanr> FindAll()
		{
			return zanrDAO.FindAll().ToList();
		}
	}
}
