using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
	class FineItem : Item
	{
		public FineItem(Sprite sprite, int reputationLevel)
		{
			Rarity = 2;
			TextColor = Color.cyan;
			ItemPrice = Random.Range(200, 400);
			ItemPrice += ItemPrice * ((float)reputationLevel / 10);
			OriginalPrice = ItemPrice;
			ItemName = sprite.name;
			Icon = sprite;
		}
	}
}
