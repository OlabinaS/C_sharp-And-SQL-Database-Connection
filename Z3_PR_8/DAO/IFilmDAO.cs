using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.Model;

namespace Z3_PR_8.DAO
{
	public interface IFilmDAO : ICRUDDao<Film, int>
	{
		IEnumerable<Film> FindAllId(int id);

		string ZanrName(int id);
	}
}
