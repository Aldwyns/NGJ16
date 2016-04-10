using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	Animator animator;
	public GameObject inputManager;
	InputDevice inputDevice; 

	// Use this for initialization
	void Start () {
		animator = this.transform.GetComponent<Animator> ();
		if (inputManager == null && inputDevice == null) {
			inputManager = transform.parent.transform.parent.FindChild("InputManager").gameObject;
			inputDevice = inputManager.GetComponent<InputDevice> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SystemInfo.deviceType == DeviceType.Handheld) {
			if (Input.gyro.rotationRate.x > 0) {
				animator.SetBool("leanBool", true);
				animator.SetFloat ("angle", Input.gyro.rotationRate.x);
			} else if (Input.gyro.rotationRate.x <= 0){
				animator.SetBool("leanBool", false);
			}
		} else {
			if (Input.GetAxis("Horizontal") > 0) {
				animator.SetBool("leanBool", true);
				animator.SetFloat("angle", Input.GetAxis("Horizontal"));
			} else if (Input.GetAxis("Horizontal") <= 0) {
				animator.SetBool("leanBool", false);
			}
		}

		if (inputDevice != null) {
			if (inputDevice.power >= inputDevice.maxPower) {
				animator.SetBool ("winningBool", true);
			} 
			double threshold = (inputDevice.maxPower * 0.75);
			if (inputDevice.power < threshold) {
				animator.SetBool ("winningBool", false);
			}
		}


	}
}
