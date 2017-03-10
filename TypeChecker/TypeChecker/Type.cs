using System;
using System.Collections.Generic;
using Android.OS;
using Android.Util;

namespace TypeChecker
{
	public class Type
	{
		private List<string> advantages = new List<string>();
		private List<string> disadvantage = new List<string>();
		private List<string> nullEffect = new List<string>();
		public string TypeName { get; set; }

		public List<string> Advantages 
		{ 
			get { return advantages; }
			set { advantages = value; }
		}

		public List<string> Disadvantage
		{ 
			get { return disadvantage; }
			set { disadvantage = value; }
		}

		public List<string> NullEffect
		{ 
			get { return nullEffect; }
			set { nullEffect = value; }
		}

		public Type ()
		{
		}

	}
}


