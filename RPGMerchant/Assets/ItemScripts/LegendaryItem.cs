using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
	class LegendaryItem : Item
	{
		public LegendaryItem(Sprite sprite, int reputationLevel)
		{
			this.Rarity = 5;
			TextColor = new Color(216f/255,159f/255,4f/255,255f);
			ItemPrice = Random.Range(1000, 5000);
			ItemPrice += ItemPrice * ((float)reputationLevel / 10);
			OriginalPrice = ItemPrice;
			ItemName = sprite.name;
			Icon = sprite;
		}
	}
}
