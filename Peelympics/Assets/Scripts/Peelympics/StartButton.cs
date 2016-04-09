using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public GameObject Application;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void clickStart()
	{
		Instantiate (Application);
		transform.parent.gameObject.SetActive (false);
	}
}
