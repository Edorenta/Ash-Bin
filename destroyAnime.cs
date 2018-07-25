using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAnime : MonoBehaviour
{
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, transform.GetChild(0).GetComponent<ParticleSystem>().main.duration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
