using System;
using UnityEngine;


namespace Assets.Scripts
{
	[System.Serializable]
	public class Item
	{
		
		public string ItemName;

		public float ItemPrice;

		public Sprite Icon;

		public int Profit = 0;

		public float OriginalPrice;

		public int Rarity = 1;

		public Color TextColor = Color.white;


	}
}