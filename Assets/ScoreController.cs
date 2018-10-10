using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//this.GetComponent<Text> ().text = "Score:" + score; //updateで呼び出さない //足したときに反映する 引数
	}

	public void ChangeScore(){
		this.GetComponent<Text> ().text = "Score:" + score;
	}


}
