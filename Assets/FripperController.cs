using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;
	private float flickAngle = -20;

	private string firstPushed = "null";

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

	private int rightFingerId;
	private int leftFingerId;

	void TouchInput(){
		
	//	if (Input.touchCount > 0) {

			

		for (int i = 0; i < Input.touchCount; i++) {

		Touch t = Input.touches[i];

		switch(t.phase){

			case TouchPhase.Began:

				if (t.position.x > Screen.width * 0.5 && tag == "RightFripperTag") {
					rightFingerId = t.fingerId;
					SetAngle (this.flickAngle);
				} else if (t.position.x < Screen.width * 0.5 && tag == "LeftFripperTag") {
					leftFingerId = t.fingerId;
					SetAngle (this.flickAngle);
				}

				break;

			case TouchPhase.Ended:
				if (t.fingerId == rightFingerId && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				} else if (t.fingerId == leftFingerId && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}

				break;
		}
				

			


			}

	}
}
