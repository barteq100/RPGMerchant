using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class MenuController: MonoBehaviour
	{
		public List<IOpenable> MenuList;

		void Awake()
		{
			MenuList = new List<IOpenable>();
		}
		public void TryClose(IOpenable sender)
		{
			foreach (var i in MenuList)
			{
				if (!i.IsClosed && !sender.Equals(i))
							i.OpenOptions();			
			}
		}

	}
}
