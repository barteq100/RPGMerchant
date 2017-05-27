
using Assets.Scripts;
using UnityEngine;

public class Upgrades : MonoBehaviour, IOpenable
{

	public Transform UpgradePanel;

	private bool isClosed = true;
	public bool IsClosed
	{
		get { return isClosed; }
		set
		{
			isClosed = value;
		}
	}


	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<MenuController>().MenuList.Add(this);
		UpgradePanel.gameObject.SetActive(false);
	}

	public void OpenOptions()
	{
		transform.parent.GetComponent<MenuController>().TryClose(this);
		UpgradePanel.gameObject.SetActive(IsClosed);
		IsClosed = !IsClosed;
	}
}
