using UnityEngine;
using System.Collections;

public class AudioEmitter : MonoBehaviour {
	
	public AudioClip[] BucketHit = new AudioClip[6];
	public AudioClip[] PeeHeavyStart = new AudioClip[4];
	public AudioClip[] PeeHeavyStop = new AudioClip[6];
	AudioSource SoundEffect;
	public bool bucketBool = false;
	public bool heavyStartBool = false;
	public bool heavyStopBool = false;

	void Awake () {
		SoundEffect = this.GetComponent<AudioSource> ();

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bucketBool == true) {
			int rand = Random.Range (0, BucketHit.Length);
			SoundEffect.clip = BucketHit [rand];
			SoundEffect.Play ();
			bucketBool = false;
		}
		if (heavyStartBool == true) {
			int rand = Random.Range (0, PeeHeavyStart.Length);
			SoundEffect.clip = PeeHeavyStart [rand];
			SoundEffect.Play ();
			heavyStartBool = false;
		}
		if (heavyStopBool == true) {
			int rand = Random.Range (0, PeeHeavyStop.Length);
			SoundEffect.clip = PeeHeavyStop [rand];
			SoundEffect.Play ();
			heavyStopBool = false;
		}
		if (SoundEffect.isPlaying == false) {
			Destroy(this.gameObject);
		}
	}
}