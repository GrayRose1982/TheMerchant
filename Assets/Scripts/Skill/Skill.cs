using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill : BaseInformation
{
	public SkillType skillType;

	public SkillEffect skillEffect;
	public int numberEffect = 10;

	public int maxLevel;
    public string conditionToLearn;

	private int _expToNextLevel;
	private int _currentExp;

	public int expToNextLevel { get { return _expToNextLevel; } }

	public int currentExp { get { return _currentExp; } }

	public void UseSkill ()
	{
		if (level >= maxLevel)
			return;

		_currentExp++;

		if (_currentExp >= _expToNextLevel) {
			if (level >= maxLevel) {
				_expToNextLevel = 0;
				_currentExp = 0;
			} else {
				level++;
				_expToNextLevel *= 2;
				_currentExp = 0;
			}
		}
	}
}
