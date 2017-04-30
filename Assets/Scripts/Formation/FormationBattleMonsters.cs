using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormationBattleMonsters : MonoBehaviour
{
	public MonsterBattle[] monsterUI;

	public void SetFormation (List<CharacterMonster> newFormation)
	{
		for (int i = 0; i < newFormation.Count; i++) {
			if (i >= monsterUI.Length)
				break;

			if (newFormation [i] != null) {
				monsterUI [i].gameObject.SetActive (true);
				monsterUI [i].mons = newFormation [i];
			} else if (i < monsterUI.Length) {
				monsterUI [i].gameObject.SetActive (false);
			}
		}
	}

	public void SetNewMonster (CharacterMonster mons, int position)
	{
		monsterUI [position].gameObject.SetActive (true);
		if (mons != null)
			mons.posisionInTeam = position;
		monsterUI [position].mons = mons;
	}
}
