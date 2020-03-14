using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cwiczenia2.Models
{
	public class Studies
	{
		[XmlElement(ElementName = "name")]
		private String _name;
		[XmlElement(ElementName = "mode")]
		private String _mode;

		public String Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public String Mode
		{
			get { return _mode; }
			set { _mode = value; }
		}

		public Studies(String name, String mode)
		{
			Name = name;
			Mode = mode;
		}
		override public bool Equals(Object s)
		{
			if (s is Studies)
			{
				Studies tmp = s as Studies;
				return Name == tmp.Name && Mode == tmp.Mode;
			}

			return false;
		}
		public static bool operator ==(Studies s1, Studies s2) { return s1.Equals(s2); }

		public static bool operator !=(Studies s1, Studies s2) { return !s1.Equals(s2); }
	}
}
