using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Assets.Scripts
{
	public class ItemCreator : MonoBehaviour
	{
		public Attribute ReputationAttribute;
		public List<Sprite> SpriteList;
		
		public Item GetItem()
		{
			int reputationLevel = ReputationAttribute.AttributeLvl;
			var sprite = Random.Range(1, SpriteList.Count);
			var random = Random.value - (reputationLevel/20f);
			if (random < 0f) random = 0f;
			if (random < 0.1) return new LegendaryItem(SpriteList[sprite], reputationLevel);
			else if (random < 0.3) return new EpicItem(SpriteList[sprite], reputationLevel);
			else if (random < 0.5) return new MasterItem(SpriteList[sprite], reputationLevel);
			else if (random < 0.7) return new FineItem(SpriteList[sprite], reputationLevel);
			else return new CommonItem(SpriteList[sprite], reputationLevel);		
		}

	}
}
