﻿using System.Collections;
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

	public int str{ get { return _str; } set { _str = value; } }

	public int agi{ get { return _agi; } set { _agi = value; } }

	public int intel{ get { return _int; } set { _int = value; } }

	public int atk{ get { return _attack + _str; } set { _attack = value; } }

	public int matk{ get { return _magicAttack + _int; } set { _magicAttack = value; } }

	public int def{ get { return _defence + _str; } set { _defence = value; } }

	public int mdef{ get { return _magicDefence + _int; } set { _magicDefence = value; } }

	public int acc{ get { return _accurate + _agi; } set { _accurate = value; } }

	public int eva{ get { return _evasion + _agi; } set { _evasion = value; } }

	public virtual int speed{ get { return _speed; } set { _speed = value; } }

}
