using UnityEngine;
using System.Collections;

public class ParticleHit : MonoBehaviour {
	public ParticleSystem Impact;
	public ParticleSystem part;
	public ParticleCollisionEvent[] collisionEvents;

	public GameObject AudioEmitter;
	GameObject SoundManager;

	void Start() {
		part = GetComponent<ParticleSystem>();
		collisionEvents = new ParticleCollisionEvent[16];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnParticleCollision(GameObject other) {
		PointScript _pointScript = other.GetComponent<PointScript> ();
		PlayerScript _playerScript = transform.parent.GetComponent<PlayerScript> ();
		if (_pointScript != null && _playerScript != null) {
			_playerScript.playerPoints += _pointScript.objectScore;
		} else {
			Debug.Log("Script not found in collision!");
		}
		ParticleSystem tmp = Instantiate (Impact);
		tmp.transform.position = other.transform.position;
		GameObject tmp1 = Instantiate (AudioEmitter);
		tmp1.GetComponent<AudioEmitter> ().bucketBool = true;
		tmp1.transform.position = other.transform.position;
	}

}
