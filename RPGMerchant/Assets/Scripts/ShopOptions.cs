using System;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ShopOptions : MonoBehaviour, IOpenable
{
	public static Switch SellingSwitch;
	public static Slider ProfitSlider;
	public static InputField ProfitInputField;
	

	public Transform OptionPanel;
	public ShopScrollList PlayerShopScrollList;

	
	private bool isClosed = true;
	public bool IsClosed {
		get { return isClosed; }
		set
		{
			isClosed = value;
		}
	}
	private int Profit = 0;


	// Use this for initialization
	void Start ()
	{
		transform.parent.GetComponent<MenuController>().MenuList.Add(this);
		OptionPanel.gameObject.SetActive(false);
		SellingSwitch = OptionPanel.FindChild("SellOption").GetComponent<Switch>();
		ProfitSlider = OptionPanel.FindChild("ProfitSlider").GetComponent<Slider>();
		ProfitInputField = OptionPanel.FindChild("ProfitInputField").GetComponent<InputField>();
		
	}

	void Update()
	{
		UpdatePrices();
	}
	public void OpenOptions()
	{
		transform.parent.GetComponent<MenuController>().TryClose(this);
		OptionPanel.gameObject.SetActive(IsClosed);
			IsClosed = !IsClosed;
	}

	public void SetInputField()
	{
		Profit = (int)ProfitSlider.value;
		ProfitInputField.text = ProfitSlider.value.ToString();
		UpdatePrices();
	}

	public void SetProfitSlider()
	{
		Profit = Int32.Parse(ProfitInputField.text);
		if (Profit > 200 || Profit < 0)
		{
			Profit = 0;
			ProfitInputField.text = "";
		}
		ProfitSlider.value = Profit;
		UpdatePrices();

	}

	private void UpdatePrices()
	{
		bool wasUpdated = false;
		foreach (Item i in PlayerShopScrollList.ItemList)
		{
			if (i.Profit != Profit)
			{
				wasUpdated = true;
				i.ItemPrice = i.OriginalPrice + (i.OriginalPrice * (Profit / 100f));
				i.Profit = Profit;
			}
		}
		if(wasUpdated)
		PlayerShopScrollList.RefreshDisplay();
	}


}
