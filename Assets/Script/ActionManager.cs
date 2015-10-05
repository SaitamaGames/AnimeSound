using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {
	static ActionManager instance;
	bool end = false;

	UnityChanCoin unityChan;

	// Use this for initialization
	void Start () {
		instance = this;
		unityChan = GetComponent<UnityChanCoin>();
	}

	
	// Update is called once per frame
	void Update () {
	
		if( GameOver.GameOverFlag)
		{
			if(end)
			{
				return;
			}
			end = true;
			unityChan.UnityGameOver();
		}
	}

	
	public static ActionManager GetInstance()
	{
		return instance;
	}

	public void OKActiocn(int Point , string action)
	{

		if(Point == 0 )
		{
			//MISS
			Score.GetInstance().LifeDown();
			unityChan.UnityDamageAnime();
			return;
		}else
		if(Point == 1 )
		{
			//OK
			Score.ScorePoint += 10;
		}else
		if(Point == 2 )
		{
			//GRATE
			Score.ScorePoint += 20;
		}

		switch(action)
		{
			case "Z":
			{
				unityChan.UnityPose(1);
				break;
			}
			case "X":
			{
				unityChan.UnityPose(2);
				break;
			}
			case "C":
			{
				unityChan.UnityPose(3);
				break;
			}
		}



	}

}




