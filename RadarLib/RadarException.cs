using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarLib
{
	[Serializable]
	public class RadarException : Exception
	{
		public RadarException() { }
		public RadarException(string message) : base(message) { }
		public RadarException(string message, Exception inner) : base(message, inner) { }
		protected RadarException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
