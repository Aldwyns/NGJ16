﻿using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ParticleSystem tmp = this.GetComponent<ParticleSystem> ();
		if (tmp != null) {
			if (tmp.isStopped == true) {
				Destroy (this.gameObject);
			}
		}
	}
}
