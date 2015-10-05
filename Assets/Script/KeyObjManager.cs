using UnityEngine;
using System.Collections;

public class KeyObjManager : MonoBehaviour {

	//枠のオブジェクト
	//タッチ判定に使います
	[SerializeField] GameObject wakuObj;

	//オリジナル　オブジェクト
	[SerializeField] KeyObj[] KeyObjOriginal;
	//作成されたオブジェクト
	KeyObj[] KeyObjDatas;

	float timer = 0;
	float maxTimer = 1;

	static KeyObjManager instance;


	// Use this for initialization
	void Start () {
		instance = this;
		KeyObjDatas = new KeyObj[40];
	}
	
	// Update is called once per frame
	void Update () {
	
		if( GameOver.GameOverFlag )
		{
			return;
		}

		timer += Time.deltaTime;
		//一定時間の経過
		if( timer >=  maxTimer )
		{
			maxTimer = Random.Range(1.15f,2.02f);
			timer = 0;

			//3種類ランダムで作成
			KeyObj obj = (KeyObj)Instantiate(KeyObjOriginal[Random.Range(0,KeyObjOriginal.Length)]);
			obj.transform.parent = transform;

			clearnObj();

			//後々の検索用に登録！
			for( int i = 0; i < KeyObjDatas.Length; i++)
			{
				if( KeyObjDatas[i] == null)
				{
					KeyObjDatas[i] = obj;
					break;
				}
			}
		}


	}

	public static KeyObjManager GetInstance()
	{
		return instance;
	}

	//ボタンを押したときの判定
	//近くにオブジェクトがあるか
	public void NearKeyOK(string key)
	{
		//最小距離
		float distanceMin = 90f;
		//最小距離のオブジェクト
		int nearIndex = -1;
		bool touchOk = false;
		bool Grate = false;

		for( int i = 0; i < KeyObjDatas.Length; i++)
		{
			if( KeyObjDatas[i] == null || 
			   KeyObjDatas[i].gameObject.activeSelf == false )
			{
				continue;
			}

			//2点間のポイント
			Vector2 point = wakuObj.transform.position;

			point.y = 0;
			Vector2 point2 =  KeyObjDatas[i].transform.position;
			point2.y = 0;
			//きょりをもとめる
			float distanceData = Vector2.Distance( point , point2);
			//近いなら更新
			if(distanceData <= distanceMin)
			{
				nearIndex = i;
				distanceMin = distanceData;

				touchOk = true;

				if( distanceMin <= 10.01f )
				{
					Grate = true ;
				}
			}
		}

		//近くでした
		if( touchOk)
		{
			//キーもあってます
			if( KeyObjDatas[nearIndex].gameObject.tag == key )
			{
				//消滅させます
				Destroy(KeyObjDatas[nearIndex].gameObject);

				if( Grate )
				{
					//高得点
					ActionManager.GetInstance().OKActiocn( 2 , key );
				}else
				{
					//普通
					ActionManager.GetInstance().OKActiocn( 1 , key );
				}
			}
		}else
		{
			//MISS
			ActionManager.GetInstance().OKActiocn( 0 , key );
		}

		//何もない
		return ;
	}

	//存在しないものは削除
	void clearnObj()
	{
		for( int i = 0; i < KeyObjDatas.Length; i++)
		{
			if( KeyObjDatas[i] == null || 
			   KeyObjDatas[i].gameObject.activeSelf == false )
			{
				KeyObjDatas[i] = null;
				continue;
			}
		}
	}


}
