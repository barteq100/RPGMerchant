using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
	class CommonItem : Item
	{
		public CommonItem(Sprite sprite,int reputationLevel)
		{
			Rarity = 1;
			TextColor = Color.black;
			ItemPrice = Random.Range(10, 200);
			ItemPrice += ItemPrice * ((float)reputationLevel / 10);
			OriginalPrice = ItemPrice;
			ItemName = sprite.name;
			Icon = sprite;
		}
	}
}
