using System;
using System.Collections.Generic;

namespace AppQuest_Schrittzaehler.Model
{
	public class Run
	{
		public IList<Route> RouteList { get; set; } = new List<Route>();

		internal void IndexOf(object item)
		{
			throw new NotImplementedException();
		}
	}
}
