using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float PlayerSpacing = 1;
	public int PlayerNum = 1;
	public GameObject PlayerInstance;

	// Use this for initialization
	void Start () {
		float _x = 0;
		if (PlayerNum % 2 != 0) {
			_x -= (PlayerNum / 2) * PlayerSpacing;
			for (int a = 0; a < PlayerNum; a++) {
				GameObject tmp = Instantiate (PlayerInstance);
				tmp.transform.parent = this.gameObject.transform;
				tmp.name = "Player " + a;
				tmp.transform.position = this.transform.position;
				tmp.transform.position = new Vector3(tmp.transform.position.x + _x, tmp.transform.position.y, tmp.transform.position.z);
				_x += PlayerSpacing;
			}
		} else {
			_x -= PlayerSpacing/2;
			_x -= (PlayerNum / 2) * PlayerSpacing;
			for (int a = 0; a < PlayerNum; a++) {
				GameObject tmp = Instantiate (PlayerInstance);
				tmp.transform.parent = this.gameObject.transform;
				tmp.name = "Player " + a;
				tmp.transform.position = this.transform.position;
				tmp.transform.position = new Vector3(tmp.transform.position.x + _x, tmp.transform.position.y, tmp.transform.position.z);
				_x += PlayerSpacing;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
