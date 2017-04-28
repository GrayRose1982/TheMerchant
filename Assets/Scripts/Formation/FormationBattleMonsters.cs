using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormationBattleMonsters : MonoBehaviour
{
	[SerializeField] FormationForMonsters formation;

	public MonsterBattle[] monster;

	void Start ()
	{

	}

	public void SetFormation (FormationForMonsters newFormation)
	{
		formation = newFormation;

		for (int i = 0; i < formation.monsters.Length; i++) {
			if (formation.monsters [i] != null) {
				monster [i].gameObject.SetActive (true);
				monster [i].mons = formation.monsters [i];
			} else if (i < monster.Length) {
				monster [i].gameObject.SetActive (false);
			}
		}
	}
}
