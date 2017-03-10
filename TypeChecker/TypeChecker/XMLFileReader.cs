using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Android.Runtime;

namespace TypeChecker
{
	public class XMLFileReader
	{
		List<Type> types;

		public List<Type> Types { get { return types; } }

		public XMLFileReader (Stream xmlStream)
		{
			types = new List<Type> ();

			using (XmlReader typeReader = XmlReader.Create (xmlStream)) {
				Type data = null;
				while (typeReader.Read ()) {
					if (typeReader.IsStartElement ()) {
						switch (typeReader.Name) {
						case "item":
							data = new Type ();
							break;
						case "typename":
							if (typeReader.Read () && data != null) {
								data.TypeName = typeReader.Value.Trim ();
							}
							break;
						case "advantage":
							if (typeReader.Read () && data != null) {
								data.Advantages.Add(typeReader.Value.Trim());
							}
							break;
						case "disadvantage":
							if (typeReader.Read () && data != null) {
								data.Disadvantage.Add(typeReader.Value.Trim ());
							}
							break;
						case "nulleffect":
							if (typeReader.Read () && data != null) {
								data.NullEffect.Add(typeReader.Value.Trim ());
							}
							break;
						}
					} else if (typeReader.Name == "item") {
						types.Add (data);
						data = null;
					}

				}
			}

		}
	}
}

