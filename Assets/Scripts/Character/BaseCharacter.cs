using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class BaseCharacter : BaseStar
{
	[SerializeField] protected int _health = 100;
	[SerializeField] protected int _maxHealth = 100;
	public Sprite avatar;

	public int manaShield;

	public Action takeDamageAction;
	public Action animationAttack;
	public Action animationTurnAttack;

	protected float _speedPerMove;

	public int health{ get { return _health; } set { _health = value; } }

	public int maxHealth{ get { return _maxHealth; } set { _maxHealth = value; } }

	public float speedPerMove{ get { return _speedPerMove; } }

	public override int speed {
		get { return _speed; }
		set {
			_speed = value; 
			_speedPerMove = 1000f / value;
		}
	}

	public List<Skill> skills;

	public List<Skill> skillUses;

	public LineInFormtaion line;
	public int rangerAttack = 0;
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

	public void TakeDamage (int number)
	{
		_health -= number;

		if (takeDamageAction != null)
			takeDamageAction.Invoke ();
	}
}
