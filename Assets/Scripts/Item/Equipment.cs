using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Equipment : BaseItem
{
	[SerializeField]private EquipmentType _equipmentType;

	[SerializeField]private int _strIncrease;
	[SerializeField]private int _agiIncrease;
	[SerializeField]private int _intIncrease;
	[SerializeField]private int _attackIncrease;
	[SerializeField]private int _magicAttackIncrease;
	[SerializeField]private int _accurateIncrease;
	[SerializeField]private int _evasionIncrease;
	[SerializeField]private int _defenceIncrease;
	[SerializeField]private int _magicDefenceIncrease;
	[SerializeField]private int _speedIncrease;

	public EquipmentType equipmentType { get { return _equipmentType; } }

	public int strIncrease{ get { return _strIncrease; } set { _strIncrease = value; } }

	public int agiIncrease{ get { return _agiIncrease; } set { _agiIncrease = value; } }

	public int intelIncrease{ get { return _intIncrease; } set { _intIncrease = value; } }

	public int atkIncrease{ get { return _attackIncrease; } set { _attackIncrease = value; } }

	public int matkIncrease{ get { return _magicAttackIncrease; } set { _magicAttackIncrease = value; } }

	public int defIncrease{ get { return _accurateIncrease; } set { _accurateIncrease = value; } }

	public int mdefIncrease{ get { return _evasionIncrease; } set { _evasionIncrease = value; } }

	public int accIncrease{ get { return _defenceIncrease; } set { _defenceIncrease = value; } }

	public int evaIncrease{ get { return _magicDefenceIncrease; } set { _magicDefenceIncrease = value; } }

	public virtual int speedIncrease{ get { return _speedIncrease; } set { _speedIncrease = value; } }

	public Equipment ()
	{
	}

	public Equipment (Equipment e)
	{
		index = e.index;
		name = e.name;
		description = e.description;
		level = e.level;
		sprite = e.sprite;

		gold = e.gold;
		goldDiffer = e.goldDiffer;
		type = ItemType.Equipment;
		classify = e.classify;

		_equipmentType = e.equipmentType;

		strIncrease = e.strIncrease;
		agiIncrease = e.agiIncrease;
		intelIncrease = e.intelIncrease;
		atkIncrease = e.atkIncrease;
		matkIncrease = e.matkIncrease;
		defIncrease = e.defIncrease;
		mdefIncrease = e.mdefIncrease;
		accIncrease = e.accIncrease;
		evaIncrease = e.evaIncrease;
		speedIncrease = e.speedIncrease;
	}
}
