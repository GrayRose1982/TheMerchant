using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseCharacter : BaseStar
{
	[SerializeField] protected int _health;

	public int health{ get { return _health; } set { _health = value; } }
}
