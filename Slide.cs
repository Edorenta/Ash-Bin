using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slide : MonoBehaviour
{
    private GameObject  arrow;
    float               InitialTouchTime;
    float               FinalTouchTime;
    Vector2             InitialTouchPosition;
    Vector2             FinalTouchPosition;
    public Rigidbody    cigarette;
    float               XaxisForce;
    float               YaxisForce;
    float               ZaxisForce;
    bool                hasbeentouch;
    Vector3             RequireForce;

	public AudioClip    swip_sound;
	private AudioSource audio_source;

    void Start()
    {
        cigarette = this.GetComponent<Rigidbody>();
        Time.timeScale = 1;
        cigarette.useGravity = false;
        hasbeentouch = false;
    }
    public void Throw()
    {
        arrow = GameObject.Find("arrow(Clone)");
        Destroy(arrow);
        XaxisForce = FinalTouchPosition.x - InitialTouchPosition.x;
        YaxisForce = FinalTouchPosition.y - InitialTouchPosition.y;
        ZaxisForce = 3f;
        RequireForce = new Vector3(-XaxisForce/150f, YaxisForce/50f, -ZaxisForce);
        cigarette.useGravity = true;
        cigarette.velocity = RequireForce;
    }

    public void OnMouseDown()
    {
        InitialTouchPosition = Input.mousePosition;
    }

    public void OnMouseUp()
    {
        FinalTouchPosition = Input.mousePosition;
        if (hasbeentouch == false)
            Throw();
        hasbeentouch = true;
        transform.parent.gameObject.GetComponent<spawner>().hasspawn = false;
    }
}