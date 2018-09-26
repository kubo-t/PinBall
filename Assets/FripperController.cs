using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint> ();

		SetAngle (this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

		MouseInput ();
		TouchInput ();
	}

	public void SetAngle(float angle){
		JointSpring jointspr = this.myHingeJoint.spring;
		jointspr.targetPosition = angle;
		this.myHingeJoint.spring = jointspr;
	}

	void MouseInput(){
		if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle (this.flickAngle);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag"){
			SetAngle (this.flickAngle);
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
			SetAngle (this.defaultAngle);
		}
		if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag"){
			SetAngle (this.defaultAngle);
		}
	}

	void TouchInput(){
		if(Input.touchCount > 0){
			for(int i = 0; i < Input.touchCount; i++){

				Touch t = Input.GetTouch (i);

				if(t.phase == TouchPhase.Began && t.position.x > Screen.width/2 && tag == "RightFripperTag"){
					SetAngle (this.flickAngle);
				}
				if(t.phase == TouchPhase.Ended && t.position.x > Screen.width/2 && tag == "RightFripperTag"){
					SetAngle (this.defaultAngle);
				}
				if(t.phase == TouchPhase.Began && t.position.x < Screen.width/2 && tag == "LeftFripperTag"){
					SetAngle (this.flickAngle);
				}
				if(t.phase == TouchPhase.Ended && t.position.x < Screen.width/2 && tag == "LeftFripperTag"){
					SetAngle (this.defaultAngle);
				}


			}
		}

	}
}
