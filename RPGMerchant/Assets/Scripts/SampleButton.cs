using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{

	public Button button;
	public Text ItemName;
	public Text PriceText;
	public Image ItemImage;

	private Item item;
	private ShopScrollList scrollList;

	// Use this for initialization
	void Start()
	{
		button.onClick.AddListener(HandleClick);
	}


	public void Setup(Item currentItem, ShopScrollList currentScrollList)
	{
		item = currentItem;
		ItemName.text = item.ItemName;
		ItemImage.sprite = item.Icon;
		PriceText.text = item.ItemPrice.ToString();
		scrollList = currentScrollList;
	}

	private void HandleClick()
	{
		scrollList.TryTransferItem(item);
	}


}
