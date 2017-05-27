using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Assets.Scripts
{
	public interface IOpenable
	{

		bool IsClosed { get; set; }

		void OpenOptions();
	}
}
