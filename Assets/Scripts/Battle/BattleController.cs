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
	public bool isDoneTurn;

	public List<CharacterHero> hf;
	public List<CharacterMonster> mf;

	public FormationBattleHero uiBattleHero;
	public FormationBattleMonsters uiBattleMonster;

	public string battleComment { get { return _battleComment; } }

	void Start ()
	{
		c = this;

//		StartCoroutine (DemoBattle ());
	}

	public void StartBattle ()
	{
		StartCoroutine (BattleBetweenMonsteresAndHeroes (hf, mf));
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
		while (hf.Count == 0) {
			if (TarvenController.tarven) {
				hf = TarvenController.tarven.heroes;
				uiBattleHero.SetFormation (hf);
			}
			yield return new WaitForSeconds (1f);
		}

		while (mf.Count == 0) {
			if (DungeonController.dungeon) {
				mf = DungeonController.dungeon.dungeonMonsters [0];
				uiBattleMonster.SetFormation (mf);
			}
			yield return new WaitForSeconds (1f);
		}

		StartCoroutine (BattleBetweenMonsteresAndHeroes (hf, mf));
	}

	#region Set team

	public void SetMonsterFormation (List<CharacterMonster> mons)
	{
		mf = mons;
		uiBattleMonster.SetFormation (mf);
	}

	public void SetHeroForamtion (List<CharacterHero> heroes)
	{
		hf = heroes;
		uiBattleHero.SetFormation (hf);
	}

	#endregion

	#region Battle with in formation

	public IEnumerator BattleBetweenMonsteresAndHeroes (
		List<CharacterHero> heroFormation, List<CharacterMonster> monsterFormation)
	{
		#region init list for fight
		List<BaseCharacter> characters = new List<BaseCharacter> ();

		List<BaseCharacter> heroes = new List<BaseCharacter> ();
		List<BaseCharacter> monsters = new List<BaseCharacter> ();
		List<int> monsterDontFight = new List<int> ();

		foreach (CharacterHero h in heroFormation)
			if (h != null && h.avatar != null) {
				Debug.Log ("New hero add to queue:" + h.name);
				h.baseTeam = 0;
				characters.Add (h);
				heroes.Add (h);
				if (heroes.Count >= 5)
					break;
			}

//		foreach (CharacterMonster m in monsterFormation)
//			if (m != null && m.name != null && m.name.CompareTo ("") != 0) {
//				if (monsters.Count <= 5) {
//					Debug.Log ("New mosnter add to queue:" + m.name);
//					m.baseTeam = 1;
//					characters.Add (m);
//					monsters.Add (m);
//				} else {
//					monsterDontFight.Add (m);
//				}
//			}

		for (int i = 0; i < monsterFormation.Count; i++)
			if (monsterFormation [i] != null
			    && monsterFormation [i].name != null && monsterFormation [i].name.CompareTo ("") != 0) {
				if (monsters.Count <= 5) {
					Debug.Log ("New mosnter add to queue:" + monsterFormation [i].name);
					monsterFormation [i].baseTeam = 1;
					monsterFormation [i].posisionInTeam = i;
					characters.Add (monsterFormation [i]);
					monsters.Add (monsterFormation [i]);
				} else {
					monsterDontFight.Add (i);
				}
			}


		List<float> listTime = new List<float> ();

		for (int i = 0; i < characters.Count; i++)
			listTime.Add (characters [i].speedPerMove);
		#endregion

		while (heroes.Count > 0 && (monsters.Count > 0 || monsterDontFight.Count > 0)) {
			Debug.Log ("Hero count:" + heroes.Count + " Monster count:" + monsters.Count + " Total:" + characters.Count);

			int nextPlayer = GetNextCharacterMove (listTime);
			Debug.Log ("Character select: " + nextPlayer + " name: " + characters [nextPlayer].name);
			SubTimeCount (listTime, nextPlayer, characters [nextPlayer].speedPerMove);
			attackCharacter = characters [nextPlayer];

			if (heroes.IndexOf (attackCharacter) == -1)
				defenceCharacter = heroes [GetLowestHeathCharacter (heroes)];
			else
				isDoneTurn = false;
			
			while (defenceCharacter == null)
				yield return new WaitForSeconds (.1f);
			Debug.Log ("Attacker:" + attackCharacter.name + " Get defence:" + defenceCharacter.name);

			DealPhysicDamage (attackCharacter, defenceCharacter);

			if (defenceCharacter.health <= 0)
			if (heroes.Contains (defenceCharacter)) {
//				RemoveCharacterFromList (heroes, characters, defenceCharacter, listTime);
				heroes.Remove (defenceCharacter);
				listTime.RemoveAt (characters.IndexOf (defenceCharacter));
				characters.Remove (defenceCharacter);
			} else {
//				RemoveCharacterFromList (monsters, characters, defenceCharacter, listTime);
				int posision = defenceCharacter.posisionInTeam;
				monsters.Remove (defenceCharacter);
				listTime.RemoveAt (characters.IndexOf (defenceCharacter));
				characters.Remove (defenceCharacter);
				Debug.Log ("Monster in " + posision + " Dead");
				if (monsterDontFight.Count > 0) {
					int defCharacterPosition = characters.IndexOf (defenceCharacter);

					characters.Add (monsterFormation [monsterDontFight [0]]);
					monsters.Add (monsterFormation [monsterDontFight [0]]);
					listTime.Add (monsterFormation [monsterDontFight [0]].speedPerMove);

					uiBattleMonster.SetNewMonster (monsterFormation [monsterDontFight [0]], posision);
					monsterDontFight.RemoveAt (0);
				} else
					uiBattleMonster.SetNewMonster (null, posision);
			}

			//TODO: Wait animation when monster attack
//			if (heroes.Contains (defenceCharacter))
//				while (!isDoneTurn)
//					yield return new WaitForSeconds (1f);

			isDoneTurn = true;
			attackCharacter = null;
			defenceCharacter = null;
		}

		Debug.Log ("War done");
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

		takeDamage.TakeDamage (pdamage);
//		takeDamage.health -= pdamage;

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

		for (int i = 1; i < listSpeed.Count; i++)
			if (listSpeed [i] < listSpeed [smallest])
				smallest = i;
		
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
		float sub = listSpeed [positionReset];
		string debug = "Time count down for turn:\n";
		for (int i = 0; i < listSpeed.Count; i++) {
			listSpeed [i] -= sub;
			debug += "P" + i + ": " + listSpeed [i] + "\n";
		}
		listSpeed [positionReset] = valueGo;
		debug += "P" + positionReset + ": " + listSpeed [positionReset];
		Debug.Log (debug);
	}

	void RemoveCharacterFromList (List<BaseCharacter> formation, List<BaseCharacter> cs, BaseCharacter c, List<float> time)
	{
		time.RemoveAt (cs.IndexOf (c));
		formation.Remove (c);
		cs.Remove (c);
	}


	public void SelectDefenceCharacter (BaseCharacter c)
	{
		defenceCharacter = c;
	}

	#endregion
}