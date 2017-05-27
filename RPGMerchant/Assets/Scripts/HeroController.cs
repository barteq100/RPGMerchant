using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HeroController : MonoBehaviour
{

	public ShopScrollList HeroShopScrollList;
	public PlayerScrollList PlayerShopScrollList;
	public ItemCreator itemCreator;
	public Dropdown GameSpeeDropdown;
	public WalkToShop hero;
	private List<Item> heroItemList;
	private List<Item> playerItemList;
	private float timePassed = 0f;
	private float threshold = 10f; 

	private List<Item> ItemsToSellList;

	// Use this for initialization
	void Start()
	{
		heroItemList = HeroShopScrollList.ItemList;
		playerItemList = PlayerShopScrollList.ItemList;
		PopulateItemList();
	}

	// Update is called once per frame
	void Update()
	{

		if (timePassed >= threshold)
		{
			SellItems();
			BuyItems();
			PopulateItemList();
			timePassed = 0f;
		}
		timePassed += Time.deltaTime;
	}

	public void setGameSpeed()
	{
		Time.timeScale = GameSpeeDropdown.value + 1;
	}
	private void PopulateItemList()
	{
		List<Item> itemList = new List<Item>();
		var length = Random.Range(10, 20);
		for (var i = 0; i < length; i++)
		{
			itemList.Add(itemCreator.GetItem());
		}
		HeroShopScrollList.ItemList = itemList;
		HeroShopScrollList.RefreshDisplay();
		heroItemList = HeroShopScrollList.ItemList;
		hero.WalkToPlayer();
	}

	private void SellItems()
	{
	   ItemsToSellList = SelectItemsToSell();
		if (ItemsToSellList.Count <= 0) return;
		foreach (var item in ItemsToSellList)
		{
			if (item != null)
				HeroShopScrollList.TryTransferItem(item);
		}
	}

	private void BuyItems()
	{
		var itemsToBuyList = SelectItemsToBuy();
		if (itemsToBuyList.Count <= 0) return;
		foreach (var item in itemsToBuyList)
		{
			if(item != null)
				PlayerShopScrollList.TryTransferItem(item);
		}
		hero.ResetPosition();
	}
	private List<Item> SelectItemsToSell()
	{
		var itemsToSellList = new List<Item>();
		if (heroItemList.Count <= 0) return itemsToSellList;

		/* OLD CODE with IEnumarable<Item>
				foreach (Item i in heroItemList)
			{
				var chance = CalculateChance(i);
				var decision = Random.value;
				if (decision >= chance)
					yield return i;
			}
			*/
		for (var i = heroItemList.Count - 1; i >= 0; i--)
		{
			var chance = CalculateChance(heroItemList[i]);
			var poorness = CalculatePoorness();
			var decision = Random.value + poorness;
			if (!(decision >= chance)) continue;
			itemsToSellList.Add(heroItemList[i]);
			heroItemList.Remove(heroItemList[i]);
		}
		return itemsToSellList;
	}

	private List<Item> SelectItemsToBuy()
	{
		var itemsToBuyList = new List<Item>();
		if (playerItemList.Count <= 0 ) return itemsToBuyList;

		for (var i = playerItemList.Count - 1; i >= 0; i--)
		{
			if (ItemsToSellList.Contains(playerItemList[i])) continue;
			var chance = CalculateChance(playerItemList[i]);
			var decision = Random.value;
			if (!(decision < chance)) continue;	
			itemsToBuyList.Add(playerItemList[i]);
			playerItemList.Remove(playerItemList[i]);
		}
		return itemsToBuyList;

	}

private float CalculateChance(Item i)
	{
		var rarity = i.Rarity;
		var priceFactor = i.ItemPrice;
		var random = Random.value;

		return rarity * (priceFactor / 1000f) * random;


	}

	private float CalculatePoorness()
	{
		var gold = HeroShopScrollList.Player.Gold;
		var poornessFactor = 900f;
		var poorness = (1000f - gold) / poornessFactor;
		return poorness < 0 ? 0f : poorness;
	}

}
