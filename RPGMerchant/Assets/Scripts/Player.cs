using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Player : IComparer<Player>, IComparable<Player>, IEquatable<Player>
{
	private float _gold = 5000f;
	private float _higestGold = 5000f;
	private string _playerName = "Player";

	public float Gold
	{
		get { return _gold; }
		set
		{
			_gold = value;
			if (value > _higestGold)
				_higestGold = value;
		}
	}

	public float HigestGold
	{
		get { return _higestGold; }

		set { _higestGold = value; }
	}

	public string PlayerName
	{
		get { return _playerName; }
		set { _playerName = value; }
	}

	public Player() { }
	public void AddPlayerToScoreBoard()
	{
		ScoreBoard scoreBoard = ScoreBoard.GetScoreBoard();
		scoreBoard.AddToList(this);
	}
	public Player(float gold, float higestGold, string playerName)
	{
		Gold = gold;
		HigestGold = higestGold;
		PlayerName = playerName;
	}

	public int CompareTo(Player other)
	{
		if (other == null) return 1;
		return _higestGold.CompareTo(other.HigestGold);
	}

	public int Compare(Player x, Player y)
	{
		return Comparer<float>.Default.Compare(x.HigestGold, y.HigestGold);
	}

	public bool Equals(Player other)
	{
		return _playerName.Equals(other.PlayerName) && _higestGold.Equals(other.HigestGold);
	}
}
