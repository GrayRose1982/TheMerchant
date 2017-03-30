using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseStar:BaseInformation
{
	[SerializeField]protected int _str;
	[SerializeField]protected int _agi;
	[SerializeField]protected int _int;
	[SerializeField]protected int _attack;
	[SerializeField]protected int _magicAttack;
	[SerializeField]protected int _accurate;
	[SerializeField]protected int _evasion;
	[SerializeField]protected int _defence;
	[SerializeField]protected int _magicDefence;
	[SerializeField]protected int _speed;

	public int str{ get { return _str; } }

	public int agi{ get { return _agi; } }

	public int intel{ get { return _int; } }

	public int atk{ get { return _attack; } }

	public int matk{ get { return _magicAttack; } }

	public int def{ get { return _defence; } }

	public int mdef{ get { return _magicDefence; } }

	public int acc{ get { return _accurate; } }

	public int eva{ get { return _evasion; } }

	public int speed{ get { return _speed; } }
}
