using UnityEngine;
using System.Collections;

public class PointScript : MonoBehaviour {

	public float objectScore = 1;
	public float speed = 1;
	public int _maxX = 5;
	public int _minX = -5;
	public float curPos = 0;
	public bool down = true;
	public bool up = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (curPos < _minX && down == true) {
			down = false;
			up = true;
		}
		if (curPos > _maxX && up == true) {
			up = false;
			down = true;

		}
		if (down == true) {
			curPos -= Time.deltaTime * speed;
		}
		if (up == true) {
			curPos += Time.deltaTime * speed;
		}

		transform.localPosition = new Vector3 (curPos, 0, 0);

	}
}
