using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
	class EpicItem : Item
	{
		public EpicItem(Sprite sprite, int reputationLevel)
		{
			Rarity = 4;
			TextColor = new Color(206f,0f,104f);
			ItemPrice = Random.Range(600, 1000);
			ItemPrice += ItemPrice * ((float)reputationLevel / 10);
			OriginalPrice = ItemPrice;
			ItemName = sprite.name;
			Icon = sprite;
		}
	}
}
