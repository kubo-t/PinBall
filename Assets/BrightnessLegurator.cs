using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessLegurator : MonoBehaviour {

	Material myMaterial;

	public GameObject scoreText;

	private float minEmission = 0.3f;
	private float magEmission = 2.0f;

	private int degree = 0;
	private int speed = 10;

	Color defaultColor = Color.white;

	// Use this for initialization
	void Start () {
		if(tag == "SmallStarTag"){
			this.defaultColor = Color.white;
		}else if(tag == "LargeStarTag"){
			this.defaultColor = Color.yellow;
		}else if(tag == "SmallCloudTag" || tag == "LargeCloudTag"){
			this.defaultColor = Color.red;
		}

		this.myMaterial = GetComponent<Renderer> ().material;
		myMaterial.SetColor ("_EmissionColor", this.defaultColor*minEmission);

		scoreText = GameObject.Find ("Score");
	}
	
	// Update is called once per frame
	void Update () {
		if(this.degree >= 0){
			Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);
		
			myMaterial.SetColor ("_EmissionColor", emissionColor);
			this.degree -= this.speed;
		}
	}

	void OnCollisionEnter(Collision other){
		this.degree = 100;

		if(tag == "LargeCloudTag" || tag == "LargeStarTag"){
			this.scoreText.GetComponent<ScoreController> ().score += 20;
		}else if(tag == "SmallStarTag" || tag == "SmallCloudTag"){
			this.scoreText.GetComponent<ScoreController> ().score += 10;
		}
	}
}
