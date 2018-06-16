using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    float InitialTouchTime;
    float FinalTouchTime;
    Vector2 InitialTouchPosition;
    Vector2 FinalTouchPosition;

    float XaxisForce;
    float YaxisForce;
    float ZaxisForce;
    bool hasbeentouch;

    Vector3 RequireForce;
    public Rigidbody cigarette;

    void Start()
    {
        Time.timeScale = 1;
        cigarette.useGravity = false;
        hasbeentouch = false;
    }
    public void OnTouchDown() // gets call when mouse is pressed
    {
        InitialTouchPosition = Input.mousePosition;
    }
    public void OnTouchUp() // gets up when the mouse is released
    {
        FinalTouchPosition = Input.mousePosition;
        if (hasbeentouch == false)
            Throw();
        hasbeentouch = true;
        new WaitForSecondsRealtime(5);
        Instantiate(cigarette);
    }
    public void Throw()
    {
        XaxisForce = FinalTouchPosition.x - InitialTouchPosition.x;
        YaxisForce = FinalTouchPosition.y - InitialTouchPosition.y;
        ZaxisForce = 3f;
        RequireForce = new Vector3(-XaxisForce/100f, YaxisForce/25f, -ZaxisForce);
        cigarette.useGravity = true;
        cigarette.velocity = RequireForce;
        
    }
}