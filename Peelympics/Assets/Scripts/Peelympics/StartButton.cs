using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {


	public GameObject Application;
	public GameObject GameManager;
	public GameObject SoundManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void clickStart()
	{
		GameObject tmp = Instantiate (GameManager);
		tmp.transform.parent = Application.transform;
		tmp.transform.position = Application.transform.position;
		tmp.name = "GameManager";

		SoundManager.GetComponent<SoundManager> ().inMenu = false;
		SoundManager.GetComponent<SoundManager> ().isPlaying = false;
		SoundManager.GetComponent<SoundManager> ().inGame = true;

		transform.parent.gameObject.SetActive (false);


	}
}
