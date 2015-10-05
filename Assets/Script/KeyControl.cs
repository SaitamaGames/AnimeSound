using UnityEngine;
using System.Collections;

public class KeyControl : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if( Input.GetKeyDown(KeyCode.Z))
		{
			KeyObjManager.GetInstance().NearKeyOK( "Z" );
		}else
		if( Input.GetKeyDown(KeyCode.X))
		{
			KeyObjManager.GetInstance().NearKeyOK( "X" );
		}else
		if( Input.GetKeyDown(KeyCode.C))
		{
			KeyObjManager.GetInstance().NearKeyOK( "C" );
		}
	}
}
