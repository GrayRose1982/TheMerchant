using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
	public BaseCharacter c;
	public CharacterHero hero;
	public CharacterMonster monster;
	public Equipment e;


	void Start ()
	{
		//		BattleController.c.BattleOneOne (hero, monster);
		StartCoroutine (SetUpTeam ());
	}

	IEnumerator SetUpTeam ()
	{
		while (!LoadCharacter.data.isLoadMonsterDone)
			yield return new WaitForSeconds (.5f);
		int i;
		for (i = 0; i < 3; i++) {
//			fh.AddCharacter (LoadCharacter.data.GetCharacter (i), i, ((i < 2) ? LineInFormtaion.Front : LineInFormtaion.Back));
		}

		for (i = 2; i < 5; i++) {
//			fm.AddCharacter (LoadCharacter.data.GetCharacter (i), i, ((i < 2 + 4) ? LineInFormtaion.Front : LineInFormtaion.Back));
		}

//        StartCoroutine(BattleController.c.BattleBetweenTwoFormation(fh, fm));
	}
}
