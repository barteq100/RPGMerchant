using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
	public Button ShopButton;
	public Transform otherShop;
	private DOTween tweener;
	private bool isClosed = true;
	private Vector3 start;
	private Vector3 _otherstart;
	private float distanceToMove;
	
	// Use this for initialization
	void Start ()
	{
		setStartPosition();
		ShopButton.onClick.AddListener(OpenShop);
	}

	public void OpenShop()
	{
		if (isClosed)
		{
			transform.DOLocalMove(new Vector3(start.x + distanceToMove, start.y), 1f);
			otherShop.transform.DOLocalMove(new Vector3(_otherstart.x - distanceToMove, _otherstart.y), 1f);
			isClosed = false;
			ShopButton.onClick.RemoveAllListeners();
			ShopButton.onClick.AddListener(CloseShop);
		}
	}

	public void CloseShop()
	{
		if (!isClosed)
		{
			transform.DOLocalMove(start, 1f);
			otherShop.transform.DOLocalMove(_otherstart, 1f);
			isClosed = true;
			ShopButton.onClick.RemoveAllListeners();
			ShopButton.onClick.AddListener(OpenShop);
		}
	}

	private void setStartPosition()
	{
		CanvasScaler cs = transform.parent.GetComponent<CanvasScaler>();
		distanceToMove = cs.referenceResolution.x / 3;
		transform.localPosition -= new Vector3(distanceToMove,0);
		otherShop.localPosition += new Vector3(distanceToMove, 0);
		start = transform.localPosition;
		_otherstart = otherShop.transform.localPosition;
	}
}
