using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SysMenu.Services
{
	static class Extension
	{
		public static string ToDescription(this Enum value)
		{
			DescriptionAttribute[] da =
				(DescriptionAttribute[])
				(value.GetType().GetField(value.ToString())
				.GetCustomAttributes(typeof(DescriptionAttribute), false));
			return da.Length > 0 ? da[0].Description : value.ToString();
		}

	}
}
