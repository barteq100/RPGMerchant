using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
	class MasterItem : Item
	{
		public MasterItem(Sprite sprite, int reputationLevel)
		{
			Rarity = 3;
			TextColor = Color.green;
			ItemPrice = Random.Range(400, 600);
			ItemPrice += ItemPrice * ((float)reputationLevel / 10);
			OriginalPrice = ItemPrice;
			ItemName = sprite.name;
			Icon = sprite;
		}
	}
}
