using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepOnLoad : MonoBehaviour
{
	private static	keepOnLoad instance = null;
	public			keepOnLoad Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}