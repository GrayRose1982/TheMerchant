using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonController : MonoBehaviour
{
	public static DungeonController dungeon;

	public List<List<CharacterMonster>> dungeonMonsters;
	//	public MonsterBattle[] monsterInformation;

	void Start ()
	{
		dungeonMonsters = new List<List<CharacterMonster>> ();
		dungeon = this;
		StartCoroutine (AddSomeMonster ());
	}

	IEnumerator AddSomeMonster ()
	{
		while (!LoadCharacter.data)
			yield return new WaitForSeconds (.5f);

		while (!LoadCharacter.data.isLoadHeroDone)
			yield return new WaitForSeconds (.5f);

		List<CharacterMonster> turnOne = new List<CharacterMonster> ();
		turnOne.Add (new CharacterMonster (LoadCharacter.data.monsters [0]));
		turnOne.Add (new CharacterMonster (LoadCharacter.data.monsters [0]));
		turnOne.Add (new CharacterMonster (LoadCharacter.data.monsters [0]));
		turnOne.Add (new CharacterMonster (LoadCharacter.data.monsters [0]));
		turnOne.Add (new CharacterMonster (LoadCharacter.data.monsters [1]));
		turnOne.Add (new CharacterMonster (LoadCharacter.data.monsters [2]));
		turnOne.Add (new CharacterMonster (LoadCharacter.data.monsters [3]));
		dungeonMonsters.Add (turnOne);


		List<CharacterMonster> turnTwo = new List<CharacterMonster> ();
		turnTwo.Add (new CharacterMonster (LoadCharacter.data.monsters [2]));
		turnTwo.Add (new CharacterMonster (LoadCharacter.data.monsters [2]));
		turnTwo.Add (new CharacterMonster (LoadCharacter.data.monsters [2]));
		turnTwo.Add (new CharacterMonster (LoadCharacter.data.monsters [2]));
		turnTwo.Add (new CharacterMonster (LoadCharacter.data.monsters [2]));
		turnTwo.Add (new CharacterMonster (LoadCharacter.data.monsters [2]));
		turnTwo.Add (new CharacterMonster (LoadCharacter.data.monsters [3]));
		dungeonMonsters.Add (turnTwo);
	}

	public void btn_GoToDungeon (int numberDung)
	{
		BattleController.c.SetMonsterFormation (dungeonMonsters [numberDung]);
		BattleController.c.StartBattle ();
	}
}
