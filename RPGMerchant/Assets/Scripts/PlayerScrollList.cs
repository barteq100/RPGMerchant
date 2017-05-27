using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScrollList : ShopScrollList
{

	public Text MenuGoldDisplay;

	void Start()
	{
		cont = ContentPanel.GetComponent<RectTransform>();
		setButtonScale();
		Player = new Player();
		Player.AddPlayerToScoreBoard();
		MenuGoldDisplay.text = Player.Gold.ToString();
		RefreshDisplay();
	}

	void Update()
	{
		int numberOfButtons = ItemList.Count;
		if (cont.offsetMax.y < 0)
		{ //It seems that is checking for less than 0, but the syntax is weird
			cont.offsetMax = new Vector2(); //Sets its value back.
			cont.offsetMin = new Vector2(); //Sets its value back.
		}

		if (cont.offsetMax.y > (numberOfButtons * buttonSize) - buttonSize)
		{ // Checks the values
			cont.offsetMax = new Vector2(0, (numberOfButtons * buttonSize) - buttonSize); // Set its value back
			cont.offsetMin = new Vector2(); //Depending on what values you set on your scrollview, you might want to change this, but my one didn't need it.
		}
	}

	public new bool TryTransferItem(Item i)
	{
		if(base.TryTransferItem(i))
			MenuGoldDisplay.text = Player.Gold.ToString();
		return true;


	}
}
