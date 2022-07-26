using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_8.Utils
{
	public class Parametri
	{
		public static void AddParameter(IDbCommand command, string name, DbType type)
		{
			IDbDataParameter parameter = command.CreateParameter();
			parameter.ParameterName = name;
			parameter.DbType = type;
			command.Parameters.Add(parameter);
		}

		public static void AddParameter(IDbCommand command, string name, DbType type, int size)
		{
			IDbDataParameter parameter = command.CreateParameter();
			parameter.ParameterName = name;
			parameter.DbType = type;
			parameter.Size = size;
			command.Parameters.Add(parameter);
		}

		public static void SetParameterValue(IDbCommand command, string name, Object value)
		{
			DbParameter parameter = (DbParameter)command.Parameters[name];
			//TODO: Ovde se moze dodati provera da li postoji parametar sa prosledjenim nazivom
			//Ako ne postoji trebalo bi baciti odgovarajuci izuzetak i obraditi ga na adekvatnom mestu
			parameter.Value = value;
		}
	}
}
