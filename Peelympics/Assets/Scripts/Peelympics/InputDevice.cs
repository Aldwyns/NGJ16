using UnityEngine;
using System.Collections;

public class InputDevice : MonoBehaviour {

	int playerNum = 0;
	public GameObject PeeAngle;
	public GameObject gameManager;
	public GameObject soundManager;
	SoundManager script;
	public float power = 0;
	public float powerScale = 1;
	public float powerFalloff = 1;
	public float maxPower = 20;
	public float powerThreshold = 35;
	float powerRandom = 0;

	AudioSource PeeSound;
	bool isPlayingLight = false;
	bool isPlayingHeavy = false;
	int rand;
	public GameObject audioEmitter;
	bool keyDown = false;

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		PeeSound = this.GetComponent<AudioSource> ();
		script = soundManager.GetComponent<SoundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (power > powerThreshold && isPlayingHeavy != true) {

			PeeSound.clip = script.Loops [1];
			PeeSound.Play ();
			isPlayingHeavy = true;
			isPlayingLight = false;
		}
		if (power <= powerThreshold && isPlayingLight != true) {
			PeeSound.clip = script.Loops [3];
			PeeSound.Play ();
			isPlayingLight = true;
			isPlayingHeavy = false;

		}


		
		if (power > 0.05 && !Input.anyKey) {
			power -= powerFalloff * Time.deltaTime;
		}
		if (power > 4) {
			powerRandom = Random.Range (power - 4, power + 4);
		} else {
			powerRandom = Random.Range (power, power+6);
		}


		if (PeeAngle == null && gameManager != null) {
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
		if (PeeAngle != null) {
			if (SystemInfo.deviceType == DeviceType.Handheld){
				PeeAngle.transform.Rotate(new Vector3 (-(Input.gyro.rotationRate.x /2), Input.gyro.rotationRate.y, 0));
			} else {
				Vector3 tmp = new Vector3 (Input.GetAxis ("Vertical"), Input.GetAxis ("Horizontal"), 0);
				PeeAngle.transform.Rotate (tmp);
			}
			PeeAngle.GetComponent<ParticleSystem> ().startSpeed = powerRandom;
		}
		if (gameManager == null) {
			foreach (Transform child in this.transform.parent)
			{
				if (child.name == "GameManager")
				{
					gameManager = child.gameObject;
				}
			}
		}
		if (Input.anyKey) {
			addPower ();
		}

		if (Input.anyKey && keyDown == false) {
			GameObject tmp = Instantiate (audioEmitter);
			tmp.GetComponent<AudioEmitter> ().heavyStartBool = true;
			tmp.transform.position = transform.position;
			keyDown = true;
		}
		if (!Input.anyKey && keyDown == true)
		{
			GameObject tmp1 = Instantiate (audioEmitter);
			tmp1.GetComponent<AudioEmitter>().heavyStopBool = true;
			tmp1.transform.position = transform.position;
			keyDown = false;
		}

				
	}
	public void addPower()
	{
		if (power < maxPower) {
			power += powerScale * Time.deltaTime;
		}
	}

}
