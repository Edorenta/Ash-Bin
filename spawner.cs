using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject   cigarette;
    private GameObject  last_spawn;
    public bool         hasspawn = true;
    public int          score = 0;
    public int          high_score = 0;
    private int         countChild = 0;
    public int          fail = 0;
	float               timer;
    float               speed;
    public Text         score_text;
    public Text         high_score_text;
	// Use this for initialization
	void Start () {
        if (transform.childCount <= 0) Instantiate(cigarette, transform);
        hasspawn = true;
        high_score = PlayerPrefs.GetInt("high_score", 0);
        score_text.text = score.ToString();
        high_score_text.text = high_score.ToString();
		timer = 2.0f;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("has spawn: " + hasspawn);
        high_score = PlayerPrefs.GetInt("high_score", 0);
        //Debug.Log("high scre: " + high_score);
        if(score > high_score)
        {
            PlayerPrefs.SetInt("high_score", score);
            high_score_text.text = score.ToString();
        }
        score_text.text = score.ToString();
    	timer -= Time.deltaTime;
        if (transform.childCount > 0)
        {
            last_spawn = transform.GetChild(transform.childCount - 1).gameObject;
            speed = last_spawn.GetComponent<Rigidbody>().velocity.magnitude;
            if (speed <= 0.15f)
            {
                if (transform.childCount > countChild)
                {
                    fail += 1;
                    //score = 0;
                    countChild += 1;
                }
                if (timer < 0 && !hasspawn) {
                    Instantiate(cigarette, transform);
                    hasspawn = true;
                    timer = 2.0f;
                }
                //Debug.Log("score : " + score);
                //Debug.Log("fail : " + fail);
            }
        }
        else if (timer < 0 && !hasspawn) {
            Instantiate(cigarette, transform);
            hasspawn = true;
            timer = 2.0f;
        }
    }
}
