using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_arrow : MonoBehaviour
{
    public GameObject   arrow;
	private GameObject	ash_tray;
	// Use this for initialization
	void Start ()
	{
		ash_tray = GameObject.Find("ash_tray");
		Instantiate(arrow, new Vector3(ash_tray.transform.position.x, ash_tray.transform.position.y + 3.5f, ash_tray.transform.position.z),
		Quaternion.Euler(0, 0, -90));
	}
	// Update is called once per frame
    private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "butt")
		{
			ash_tray.transform.position = new Vector3(Random.Range(-3, 11), ash_tray.transform.position.y, ash_tray.transform.position.z);
			Instantiate(arrow, new Vector3(ash_tray.transform.position.x, ash_tray.transform.position.y + 3.5f, ash_tray.transform.position.z),
			Quaternion.Euler(0, 0, -90));
		}
	}
}
