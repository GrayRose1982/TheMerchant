using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
	public static BattleController c;

	[SerializeField]string _battleComment;

	public string battleComment{ get { return _battleComment; } }

	void Start ()
	{
		c = this;
	}

	public void BattleOneOne (BaseCharacter one, BaseCharacter two)
	{
		Battle (one, two);
		Debug.Log (battleComment);
	}

	void Battle (BaseCharacter one, BaseCharacter two)
	{
		int round = 1;
		while (one.health > 0 && two.health > 0) {
			_battleComment += "Round: " + round + "\n";
//			Debug.Log ("Round: " + round);
			if (one.speed > two.speed) {
				DealDamage (one, two);
				if (two.health <= 0)
					break;
				DealDamage (two, one);
			} else {
				DealDamage (two, one);
				if (one.health <= 0)
					break;
				DealDamage (one, two);
			}
			round++;
		}
	}

	void DealDamage (BaseCharacter dealDamage, BaseCharacter takeDamage)
	{
		if (!Accurate (dealDamage, takeDamage))
			return;
		
		int mdamage, pdamage;
		mdamage = dealDamage.matk - takeDamage.mdef;
		pdamage = dealDamage.atk - takeDamage.def;

		mdamage = mdamage < 0 ? 0 : mdamage;
		pdamage = pdamage < 0 ? 0 : pdamage;

		takeDamage.health -= mdamage + pdamage;
		_battleComment += takeDamage.name + " lose " + (mdamage + pdamage) + ", Physic: " + pdamage + ", magic:" + mdamage + "\n"
		+ "hp now:" + takeDamage.name + ":" + takeDamage.health + " : " + dealDamage.name + ":" + dealDamage.health + "\n";
//		Debug.Log (takeDamage.name + " lose " + mdamage + pdamage + ", Physic: " + pdamage + ", magic:" + mdamage);
	}

	bool Accurate (BaseCharacter dealDamage, BaseCharacter takeDamage)
	{
		int acc = dealDamage.acc - takeDamage.eva + 100;
		if (acc >= Random.Range (0, 100))
			return true;
		

		_battleComment += takeDamage.name + " eva " + dealDamage.name + " attack" + "\n";
		//		Debug.Log (one.name + " eva " + two.name + " attack \n");
		return false;
	}
}
