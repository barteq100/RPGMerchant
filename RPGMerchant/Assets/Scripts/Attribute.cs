using UnityEngine;
using UnityEngine.UI;

public class Attribute : MonoBehaviour
{
	private int _attributeLvl;
	private int _attributeCost = 1000;


	private Text attributeCostText;
	private Text AttributeLevel;

	public int AttributeLvl
	{
		get
		{
			return _attributeLvl;
		}

		set
		{
			_attributeLvl = value;
			_attributeCost = value * 5000;
		}
	}

	public int AttributeCost
	{
		get
		{
			return _attributeCost;
		}
	}

	void Start()
	{
		getComponents();
		setComponents(_attributeLvl,_attributeCost);
	}

	public virtual void Upgrade()
	{
		AttributeLvl++;
		setComponents(_attributeLvl,_attributeCost);
	}

	protected void getComponents()
	{
		attributeCostText = transform.FindChild("AttributeCost").GetComponent<Text>();
		AttributeLevel = transform.FindChild("AttributeLevel").GetComponent<Text>();
	}

	protected void setComponents(int level , int cost)
	{
		attributeCostText.text = cost.ToString();
		AttributeLevel.text = level.ToString();
	}
}
