using UnityEngine;
using UnityEngine.UI;

public class HeroInTarvenUI : MonoBehaviour
{
	public CharacterHero hero;

	public Text txtName;
	public Text txtProgress;
	public Image imgBarFill;
	public Image imgJob;

	public Sprite sprMainWorking;
	public bool working = false;

	private float _baseTimeWorking = 5f;

	private float timeWorking = 0f;

	public float baseTimeWorking {
		set {
			_baseTimeWorking = value;
			timeWorking = value;
			working = true;
		}
	}

	public string nameTaking{ set { txtName.text = value; } }

	void Update ()
	{
	}
}
