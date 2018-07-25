using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCarLR : MonoBehaviour
{
	[SerializeField]
	public GameObject[] CarArrayLR;
	// Use this for initialization
	float timer;
	void Start () {
		timer = Random.Range(5.0f, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0)
		{
			GameObject tmp = Instantiate(CarArrayLR[(int)Random.Range(0, CarArrayLR.Length)]);
			tmp.transform.position = this.transform.position;
			Destroy (tmp, 10f);
			timer = Random.Range(5.0f, 10.0f);
		}

	}
}
