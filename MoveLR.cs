using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLR : MonoBehaviour
{
	float speed;
	// Use this for initialization
	void Start () {
		speed = Random.Range(2f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tmp = this.transform.position;
		tmp.x -= speed * Time.deltaTime;
		this.transform.position = tmp;
	}
}
