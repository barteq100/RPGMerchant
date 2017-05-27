
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ShopScrollList : MonoBehaviour
{
	//TODO wyznaczyć klase dla gracza któr będzie tworzyłą playera, stad usunac go, w niej dorobić menu gold display
	public Transform ContentPanel;
	public ShopScrollList OtherShop;
	public Text MyGoldDisplay;
	public SimpleObjectPool ButtonObjectPool;
	public List<Item> ItemList;
	public Player Player;
	public Attribute Negotation;
	protected RectTransform cont;
	protected float buttonScale = 1f;
	protected Vector3 localScaleVector3;
	protected const float defaultHeightResoultion = 960f;
	protected float buttonSize;

	// Use this for initialization
	void Start()
	{
		if(Player == null)
		Player = new Player();
		cont = ContentPanel.GetComponent<RectTransform>();
		setButtonScale();
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

	public bool TryTransferItem(Item item)
	{
		if (!ShopOptions.SellingSwitch.isOn) return false;
		if (OtherShop.Player.Gold >= item.ItemPrice)
		{
			Player.Gold += item.ItemPrice;
			OtherShop.Player.Gold -= (item.ItemPrice - ((float)Negotation.AttributeLvl/10 * item.ItemPrice));
			AddItem(item, OtherShop);
			RemoveItem(item, this);
			item.ItemPrice = item.OriginalPrice;
			RefreshDisplay();
			OtherShop.RefreshDisplay();
			return true;
		}
		return false;
	}


	public void RefreshDisplay()
	{
		MyGoldDisplay.text = Player.Gold.ToString();
		RemoveButtons();
		AddButtons();

	}


	protected void AddButtons()
	{
		for (int i = 0; i < ItemList.Count; i++)
		{
			Item newItem = ItemList[i];
			GameObject newButton = ButtonObjectPool.GetObject();
			newButton.transform.FindChild("ItemNameText").GetComponent<Text>().color = newItem.TextColor;
			newButton.transform.FindChild("ItemPriceText").GetComponent<Text>().color = newItem.TextColor;
			newButton.transform.SetParent(ContentPanel);

			newButton.transform.localScale = localScaleVector3;

			SampleButton sampleButton = newButton.GetComponent<SampleButton>();
			SetButtonSize(sampleButton.button);
			sampleButton.Setup(newItem, this);
		}
	}

	protected void RemoveButtons()
	{
		while (ContentPanel.childCount > 0)
		{
			GameObject toRemove = transform.GetChild(0).gameObject;
			ButtonObjectPool.ReturnObject(toRemove);
		}
	}

	protected void AddItem(Item item, ShopScrollList shopList)
	{
		shopList.ItemList.Add(item);
	}

	protected void RemoveItem(Item item, ShopScrollList shopList)
	{
		for (int i = shopList.ItemList.Count - 1; i >= 0; i--)
		{
			if (shopList.ItemList[i] == item)
				shopList.ItemList.RemoveAt(i);
		}
	}

	protected void setButtonScale()
	{

		CanvasScaler cs = GetComponent<Transform>().parent.parent.parent.parent.GetComponent<CanvasScaler>();
		//Resolution currentResolution = Screen.currentResolution;
		float height = cs.referenceResolution.y;
		buttonScale = height / defaultHeightResoultion;
		localScaleVector3 = new Vector3(buttonScale, buttonScale);
		if (buttonScale > 1f)
		{
			int spacingAmount = (int) (buttonScale / 0.125f) * 5;
			GetComponent<VerticalLayoutGroup>().spacing = spacingAmount;
		}

	}

	protected void SetButtonSize(Button button)
	{
		buttonSize = button.GetComponent<RectTransform>().rect.height;

	}
}
