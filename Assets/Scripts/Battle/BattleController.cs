using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
	public static BattleController c;

	[SerializeField]
	string _battleComment;

	private BaseCharacter defenceCharacter;
	private BaseCharacter attackCharacter;

	private FormationForHeroes hf;
	private FormationForMonsters mf;

	public string battleComment { get { return _battleComment; } }

	void Start ()
	{
		c = this;

		StartCoroutine (DemoBattle ());
	}

	/// <summary>
	/// Battle the specified two character, just for test, maybe dont use again
	/// </summary>
	public void BattleOneOne (BaseCharacter one, BaseCharacter two)
	{
		Battle (one, two);
		Debug.Log (battleComment);
	}

	IEnumerator DemoBattle ()
	{
		while (hf == null) {
			if (TarvenController.tarven)
				hf = TarvenController.tarven.formations [0];
			yield return new WaitForSeconds (1f);
		}

		while (mf == null) {
			if (DungeonController.dungeon)
				mf = DungeonController.dungeon.formations [0];
			yield return new WaitForSeconds (1f);
		}

		StartCoroutine (BattleBetweenMonsteresAndHeroes (hf, mf));
	}

	#region Battle with in formation

	/// <summary>
	/// Battles between formation heroes and monster
	/// </summary>
	public IEnumerator BattleBetweenTwoFormation (FormationForHeroes heroFormation, FormationForMonsters monsterFormation)
	{
		List<BaseCharacter> characters = new List<BaseCharacter> ();

		List<BaseCharacter> heroes = new List<BaseCharacter> ();
		List<BaseCharacter> monsters = new List<BaseCharacter> ();

		foreach (CharacterHero h in heroFormation.heroes)
			if (h.name.CompareTo ("") != 0 && h != null) {
				h.baseTeam = 0;
				characters.Add (h);
				heroes.Add (h);
			}

		foreach (CharacterMonster m in monsterFormation.monsters)
			if (m.name.CompareTo ("") != 0 && m != null) {
				m.baseTeam = 1;
				characters.Add (m);
				monsters.Add (m);
			}


		List<float> listTime = new List<float> ();

		for (int i = 0; i < characters.Count; i++)
			listTime.Add (characters [i].speedPerMove);


		while (heroes.Count != 0 && monsters.Count != 0) {
			Debug.Log ("Hero count:" + heroes.Count + " Monster count:" + monsters.Count);

			int nextPlayer = GetNextCharacterMove (listTime);

			SubTimeCount (listTime, nextPlayer, characters [nextPlayer].speedPerMove);
			//BaseCharacter characterAttack = characters[nextPlayer];
//			BaseCharacter characterDefence;
			while (defenceCharacter == null)
				yield return new WaitForSeconds (.1f);

			attackCharacter = characters [nextPlayer];

			if (heroes.IndexOf (attackCharacter) != -1)
				defenceCharacter = monsters [GetLowestHeathCharacter (monsters)];
			else
				defenceCharacter = heroes [GetLowestHeathCharacter (heroes)];

			yield return defenceCharacter;
			Debug.Log ("Get defence:" + defenceCharacter.name);

			DealPhysicDamage (attackCharacter, defenceCharacter);

			if (defenceCharacter.health <= 0)
			if (heroes.Contains (defenceCharacter))
				heroes.Remove (defenceCharacter);
			else
				monsters.Remove (defenceCharacter);
			defenceCharacter = null;
			attackCharacter = null;
		}
	}

	public IEnumerator BattleBetweenMonsteresAndHeroes (FormationForHeroes heroFormation, FormationForMonsters monsterFormation)
	{
		#region init list for fight
		List<BaseCharacter> characters = new List<BaseCharacter> ();

		List<BaseCharacter> heroes = new List<BaseCharacter> ();
		List<BaseCharacter> monsters = new List<BaseCharacter> ();

		foreach (CharacterHero h in heroFormation.heroes)
			if (h != null)
			if (h.avatar != null) {
				Debug.Log ("New hero add to queue:" + h.name);
				h.baseTeam = 0;
				characters.Add (h);
				heroes.Add (h);
			}

		foreach (CharacterMonster m in monsterFormation.monsters)
			if (m != null && m.name.CompareTo ("") != 0) {
				Debug.Log ("New mosnter add to queue:" + m.name);
				m.baseTeam = 1;
				characters.Add (m);
				monsters.Add (m);
			}


		List<float> listTime = new List<float> ();

		for (int i = 0; i < characters.Count; i++)
			listTime.Add (characters [i].speedPerMove);
		#endregion

		while (heroes.Count != 0 && monsters.Count != 0) {
			Debug.Log ("Hero count:" + heroes.Count + " Monster count:" + monsters.Count + " Total:" + characters.Count);

			int nextPlayer = GetNextCharacterMove (listTime);
			Debug.Log ("Character select: " + nextPlayer);
			SubTimeCount (listTime, nextPlayer, characters [nextPlayer].speedPerMove);
//			BaseCharacter characterAttack = characters [nextPlayer];
//			BaseCharacter characterDefence;
			attackCharacter = characters [nextPlayer];
			if (heroes.IndexOf (attackCharacter) != -1)
				;
			else
				defenceCharacter = heroes [GetLowestHeathCharacter (heroes)];

			while (defenceCharacter == null)
				yield return new WaitForSeconds (.1f);
			Debug.Log ("Attacker:" + attackCharacter.name + " Get defence:" + defenceCharacter.name);

			DealPhysicDamage (attackCharacter, defenceCharacter);

			if (defenceCharacter.health <= 0)
			if (heroes.Contains (defenceCharacter))
				heroes.Remove (defenceCharacter);
			else
				monsters.Remove (defenceCharacter);
			attackCharacter = null;
			defenceCharacter = null;
		}
	}

	#endregion

	#region Deal physic and magic damage

	/// <summary>
	/// Battle the specified two character, just for test, maybe dont use again
	/// </summary>
	void Battle (BaseCharacter one, BaseCharacter two)
	{
		int round = 1;
		while (one.health > 0 && two.health > 0) {
			_battleComment += "Round: " + round + "\n";
			Debug.Log ("Round: " + round);
			if (one.speed > two.speed) {
				DealPhysicDamage (one, two);
				if (two.health <= 0)
					break;
				DealPhysicDamage (two, one);
			} else {
				DealPhysicDamage (two, one);
				if (one.health <= 0)
					break;
				DealPhysicDamage (one, two);
			}
			round++;
		}
	}

	/// <summary>
	/// Deals the physic damage from deal dame character to take damage character.
	/// </summary>
	void DealPhysicDamage (BaseCharacter dealDamage, BaseCharacter takeDamage)
	{
		if (!Accurate (dealDamage, takeDamage))
			return;

		int pdamage;
		pdamage = dealDamage.atk - takeDamage.def;

		pdamage = pdamage < 0 ? 0 : pdamage;

		takeDamage.health -= pdamage;
		Debug.Log (takeDamage.name + " lose " + pdamage + ", Physic: " + pdamage + "\n"
		+ "hp now:" + takeDamage.name + ":" + takeDamage.health + " : " + dealDamage.name + ":" + dealDamage.health);
		_battleComment += takeDamage.name + " lose " + pdamage + ", Physic: " + pdamage + "\n"
		+ "hp now:" + takeDamage.name + ":" + takeDamage.health + " : " + dealDamage.name + ":" + dealDamage.health + "\n";
	}

	/// <summary>
	/// Deals the magic damage from deal dame character to take damage character.
	/// </summary>
	void DealMagicDamage (BaseCharacter dealDamage, BaseCharacter takeDamage)
	{
		int mdamage;
		mdamage = dealDamage.matk - takeDamage.mdef;

		mdamage = mdamage < 0 ? 0 : mdamage;

		takeDamage.health -= mdamage;

		_battleComment += takeDamage.name + " lose " + mdamage + ", Magic: " + mdamage + "\n"
		+ "hp now:" + takeDamage.name + ":" + takeDamage.health + " : " + dealDamage.name + ":" + dealDamage.health + "\n";
	}


	/// <summary>
	/// Calculate the accurate to deal damage of deal damage character.
	/// </summary>
	bool Accurate (BaseCharacter dealDamage, BaseCharacter takeDamage)
	{
		int acc = dealDamage.acc - takeDamage.eva + 100;
		if (acc >= Random.Range (0, 100))
			return true;

		Debug.Log (takeDamage.name + " eva " + dealDamage.name + " attack");
		_battleComment += takeDamage.name + " eva " + dealDamage.name + " attack" + "\n";
		return false;
	}

	#endregion

	#region other ultility

	/// <summary>
	/// Gets index of the next character move.
	/// </summary>
	int GetNextCharacterMove (List<float> listSpeed)
	{
		int smallest = 0;

		for (int i = 1; i < listSpeed.Count; i++) {
			if (listSpeed [i] < listSpeed [smallest])
				smallest = i;
		}

		return smallest;
	}

	/// <summary>
	/// Gets the index lowest heath character.
	/// </summary>
	int GetLowestHeathCharacter (List<BaseCharacter> characters)
	{
		int indexLowest = 0, i = 0;
		for (i = 0; i < characters.Count; i++)
			if (characters [i].line == LineInFormtaion.Front)
				indexLowest = i;


		for (i = i; i < characters.Count; i++)
			if (characters [i].line == LineInFormtaion.Front && characters [i].health < characters [indexLowest].health)
				indexLowest = i;

		return indexLowest;
	}

	void SubTimeCount (List<float> listSpeed, int positionReset, float valueGo)
	{
		for (int i = 0; i < listSpeed.Count; i++) {
			listSpeed [i] -= listSpeed [positionReset];
		}
		listSpeed [positionReset] = valueGo;
	}

	public void SelectDefenceCharacter (BaseCharacter c)
	{
		defenceCharacter = c;
	}

	#endregion
}