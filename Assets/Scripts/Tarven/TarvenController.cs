using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarvenController : MonoBehaviour
{
	public static TarvenController tarven;


	public List<CharacterHero> heroes;

	void Start ()
	{
		heroes = new List<CharacterHero> ();

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
//		BattleController.c.SetHeroForamtion (heroes);
	}
}
