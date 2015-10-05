using UnityEngine;
using System.Collections;

public class UnityChanCoin : MonoBehaviour {

	private Animator anim;
	private AnimatorStateInfo currentState;		// 現在のステート状態を保存する参照
	private AnimatorStateInfo previousState;	// ひとつ前のステート状態を保存する参照

	private static bool animeUnity = false;

	// Use this for initialization
	void Start () {
		// 各参照の初期化
		anim = GetComponent<Animator> ();
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;

	}
	
	// Update is called once per frame
	void Update () {


		// "Next"フラグがtrueの時の処理
//		for( int i = 1; i < 4; i++)
//		{
//			if (anim.GetBool ("Pose"+i)) {
//				// 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
//				currentState = anim.GetCurrentAnimatorStateInfo (0);
//				if (previousState.nameHash != currentState.nameHash) {
//					anim.SetBool ("Pose"+i, false);
//					previousState = currentState;				
//				}
//			}
//		}
//
//		if (anim.GetBool ("Damage")) {
//			// 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
//			currentState = anim.GetCurrentAnimatorStateInfo (0);
//			if (previousState.nameHash != currentState.nameHash) {
//				anim.SetBool ("Damage", false);
//				previousState = currentState;				
//			}
//		}
//		if (anim.GetBool ("GameOver")) {
//			// 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
//			currentState = anim.GetCurrentAnimatorStateInfo (0);
//			if (previousState.nameHash != currentState.nameHash) {
//				anim.SetBool ("GameOver", false);
//				previousState = currentState;				
//			}
//		}

	}

	public void UnityPose(int pose)
	{
		AnimeAllOff();
		anim.SetBool ("Pose"+pose, true);
		Invoke("offDMPose",0.8f);
	}
	void offDMPose()
	{
		anim.SetBool ("Pose1", false);
		anim.SetBool ("Pose2", false);
		anim.SetBool ("Pose3", false);
	}


	public void UnityDamageAnime()
	{
		AnimeAllOff();
		anim.SetBool ("Damage", true);
		Invoke("offDM",0.2f);
	}
	void offDM()
	{
		anim.SetBool ("Damage", false);
	}

	public void UnityGameOver()
	{
		AnimeAllOff();
		anim.SetBool ("GameOver", true);
	}


	void AnimeAllOff()
	{
//		anim.SetBool ("Pose1", false);
//		anim.SetBool ("Pose2", false);
//		anim.SetBool ("Pose3", false);
//		anim.SetBool ("Damage", false);
//		anim.SetBool ("GameOver", false);

	}


}
