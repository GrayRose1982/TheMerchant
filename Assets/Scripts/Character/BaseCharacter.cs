using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseCharacter : BaseStar
{
	[SerializeField] protected int _health;

	protected float _speedPerMove;

	public int health{ get { return _health; } set { _health = value; } }

	public float speedPerMove{ get { return _speedPerMove; } }

	public override int speed {
		get { return _speed; }
		set {
			_speed = value; 
			_speedPerMove = 1000f / value;
		}
	}

	public LineInFormtaion line;
	public int baseTeam = 0;
	public int posisionInTeam;

	public BaseCharacter ()
	{
	}

	public BaseCharacter (BaseCharacter b)
	{
		name = b.name;
		str = b.str;
		agi = b.agi;
		intel = b.intel;
		atk = b.atk;
		matk = b.matk;
		def = b.def;
		mdef = b.mdef;
		acc = b.acc;
		eva = b.eva;
		speed = b.speed;
		line = b.line;
		baseTeam = b.baseTeam;
		posisionInTeam = b.posisionInTeam;
	}
}
