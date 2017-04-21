using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormationBattleHero : MonoBehaviour
{
	[SerializeField] FormationForHeroes formation;

	public HeroBattle[] heroes;

	void Start ()
	{
		
	}

	public void SetFormation (FormationForHeroes newFormation)
	{
		formation = newFormation;

		for (int i = 0; i < formation.heroes.Length; i++) {
			if (formation.heroes [i] != null) {
				heroes [i].gameObject.SetActive (true);
				heroes [i].hero = formation.heroes [i];
			} else if (i < heroes.Length) {
				heroes [i].gameObject.SetActive (false);
			}
		}
	}

}
