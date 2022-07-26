using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_8.UIHandler;

namespace Z3_PR_8
{
	public class Program
	{
		private static readonly MainUIHandler mainUIHandler = new MainUIHandler();

		static void Main(string[] args)
		{
			mainUIHandler.HandleMainMenu();
		}
	}
}
