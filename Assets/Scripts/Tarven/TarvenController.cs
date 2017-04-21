using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarvenController : MonoBehaviour
{
	public static TarvenController tarven;

	public FormationBattleHero battle;

	public List<CharacterHero> heroes;
	public List<FormationForHeroes> formations;

	void Start ()
	{
		heroes = new List<CharacterHero> ();
		formations = new List<FormationForHeroes> ();

		tarven = this;
		StartCoroutine (AddSomeHero ());
	}

	IEnumerator AddSomeHero ()
	{
		while (!LoadCharacter.data)
			yield return new WaitForSeconds (.5f);

		while (!LoadCharacter.data.isLoadHeroDone)
			yield return new WaitForSeconds (.5f);

		heroes.Add (new CharacterHero (LoadCharacter.data.heroes [0]));
		heroes.Add (new CharacterHero (LoadCharacter.data.heroes [1]));

		SetForamtion ();
	}

	void SetForamtion ()
	{
		FormationForHeroes formation = new FormationForHeroes ();
		formation.AddCharacter (heroes [0], 0, LineInFormtaion.Front);
		formation.AddCharacter (heroes [1], 1, LineInFormtaion.Front);

		formations.Add (formation);

		battle.SetFormation (formation);
	}
}
