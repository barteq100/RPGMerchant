using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class ScoreBoard : MonoBehaviour , IOpenable
	{
		public Transform ScoreBoardWindow;
		public Transform ScoreboardContent;
		public GameObject PlayerScore;
		public List<Player> PlayerList;
		private bool isClosed = true;
		private static ScoreBoard _scoreBoardObject;
		public bool IsClosed
		{
			get { return isClosed; }
			set
			{
				isClosed = value;
			}
		}

		void Awake()
		{
			
			_scoreBoardObject = this;
			PlayerList = new List<Player>();
		}
		void Start()
		{
			transform.parent.GetComponent<MenuController>().MenuList.Add(this);
			ScoreBoardWindow.gameObject.SetActive(false);	
	
		}

		public void OpenOptions()
		{
			transform.parent.GetComponent<MenuController>().TryClose(this);
			ScoreBoardWindow.gameObject.SetActive(IsClosed);
			if (ScoreBoardWindow.gameObject.activeSelf)
			{
				RefreshDisplay();
			}
			IsClosed = !IsClosed;
		}

		public void AddToList(Player player)
		{
			PlayerList.Add(player);
			PlayerList.Sort();
		}

		public static ScoreBoard GetScoreBoard()
		{
			return _scoreBoardObject;
		}
		private void AddScores()
		{
			int i = 0;
			foreach(var p in PlayerList)
			{
				GameObject score = Instantiate(PlayerScore);
				score.transform.FindChild("PlayerName").GetComponent<Text>().text = p.PlayerName;
				score.transform.FindChild("Score").GetComponent<Text>().text = p.HigestGold.ToString();
				score.transform.SetParent(ScoreboardContent);
				score.transform.localScale = Vector3.one;
				i++;
				if (i == 10) return;
			}
		}

		private void RemoveScores()
		{
			while (ScoreboardContent.childCount > 0)
			{
				GameObject toRemove = ScoreboardContent.GetChild(0).gameObject;
				toRemove.transform.SetParent(transform);
				Destroy(toRemove);
			}
		}

		public void RefreshDisplay()
		{
			RemoveScores();
			PlayerList.Sort();
			PlayerList.Reverse();
			AddScores();
		}
	}
}
