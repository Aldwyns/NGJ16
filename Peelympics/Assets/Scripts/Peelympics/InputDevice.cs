using UnityEngine;
using System.Collections;

public class InputDevice : MonoBehaviour {

	int playerNum = 0;
	public GameObject PeeAngle;
	public GameObject gameManager;


	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (PeeAngle == null) {
			foreach (Transform child in gameManager.transform) {
				if (child.name == "Player" + playerNum) {
					foreach (Transform child1 in child)
					{
						if (child1.name == "PeeEmitter")
						{
							PeeAngle = child1.gameObject;
						}
					}
				}
			}
		}

			PeeAngle.transform.Rotate(Input.gyro.rotationRate);

			Vector3 tmp = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"),0);
			PeeAngle.transform.Rotate(tmp);
	
	}
}
