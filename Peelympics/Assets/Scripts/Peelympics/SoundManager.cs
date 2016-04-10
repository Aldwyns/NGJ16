using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioClip[] Ambience = new AudioClip[5];
	public AudioClip[] BucketFill = new AudioClip[1];
	public AudioClip[] BucketHit = new AudioClip[6];
	public AudioClip[] EndOfRound = new AudioClip[1];
	public AudioClip[] InTheLeadCheer = new AudioClip[3];
	public AudioClip[] Loops = new AudioClip[4];
	public AudioClip[] PeeHeavyStart = new AudioClip[4];
	public AudioClip[] PeeHeavyStop = new AudioClip[6];
	public AudioClip[] TheHelicopter = new AudioClip[1];
	public AudioClip[] TitleMusic = new AudioClip[1];
	public AudioClip[] Transition = new AudioClip[3];
	public AudioClip[] WinningScreen = new AudioClip[1];

	public bool isPlaying = false;
	public bool inMenu = true;
	public bool inGame = false;
	public bool inVictory = false;
	AudioSource bgMusic;

	int rand;

	// Use this for initialization
	void Start () {
		bgMusic = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inMenu == true && isPlaying == false) {
			rand = Random.Range(0,TitleMusic.Length);
			bgMusic.Stop();
			bgMusic.clip = TitleMusic[rand];
			bgMusic.Play ();
			isPlaying = true;
		}
		if (inGame == true && isPlaying == false) {
			rand = Random.Range(0,Ambience.Length);
			bgMusic.Stop();
			bgMusic.clip = Ambience[rand];
			bgMusic.Play ();
			isPlaying = true;
		}
		if (inVictory == true && isPlaying == false) {
			rand = Random.Range(0,WinningScreen.Length);
			bgMusic.Stop();
			bgMusic.clip = WinningScreen[rand];
			bgMusic.Play ();
			isPlaying = true;
		}

		if (!bgMusic.isPlaying) {
			isPlaying = false;
		}
	}


}
