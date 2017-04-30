using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormationBattleHero : MonoBehaviour
{
	public HeroBattle[] heroUI;

	public void SetFormation (List<CharacterHero> newFormation)
	{
		for (int i = 0; i < newFormation.Count; i++) {
			if (i >= heroUI.Length)
				break;

			if (newFormation [i] != null) {
				heroUI [i].gameObject.SetActive (true);
				heroUI [i].hero = newFormation [i];
			} else if (i < heroUI.Length) {
				heroUI [i].gameObject.SetActive (false);
			}
		}
	}

}
