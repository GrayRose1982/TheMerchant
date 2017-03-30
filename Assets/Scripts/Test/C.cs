using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
	public BaseCharacter c;
	public CharacterHero hero;
	public CharacterMonster monster;
	public Equipment e;

	public FormationForHeroes fh;

	void Start ()
	{
		BattleController.c.BattleOneOne (hero, monster);
	}
}
