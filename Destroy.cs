using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour
{
	[SerializeField]
	public AudioClip[]      klaxon;
    public GameObject       explosion1;
    public GameObject       explosion2;
    //private int             score;
	public AudioClip		sound_goal1;
	public AudioClip		sound_goal2;
	public AudioClip		sound_goal3;
	private AudioSource		audio_source;
    public Collider         collider;
    public Renderer         rend;
	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource>();
        audio_source = GetComponent<AudioSource>();
		//audio_source.clip = sound_goal1;
		audio_source.playOnAwake = false;
	}
	// Update is called once per frame
	void Update () {
	}
    private void play_collision()
    {
        //Debug.Log("Play");
        //score = transform.parent.GetComponent<spawner>().score;
        //if ((score > 2) && (score % 5 != 0))
            audio_source.PlayOneShot(sound_goal2);
        //else if (score > 2)
        //    audio_source.PlayOneShot(sound_goal3);
        //else
        //    audio_source.PlayOneShot(sound_goal1);
    }
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("collider: " + other.gameObject.tag);
        if (transform.parent.gameObject.GetComponent<spawner>().hasspawn == false)
        {
            if (other.gameObject.tag == "tray")
            {
                transform.parent.GetComponent<spawner>().score += 1;
                Instantiate(explosion1, transform.position, transform.rotation);
                play_collision();
                collider = GetComponent<Collider>();
                rend = GetComponent<MeshRenderer>(); // gets sprite renderer
                collider.enabled = false;
                rend.enabled = false; // sets to false if hit.
                Destroy(this.gameObject, 1.2f);
            }
            else if (other.gameObject.tag == "car")
            {
                transform.parent.GetComponent<spawner>().score = 0;
                Instantiate(explosion2, transform.position, transform.rotation);
                audio_source.PlayOneShot(klaxon[(int)Random.Range(0, klaxon.Length)]);
                rend = GetComponent<MeshRenderer>(); // gets sprite renderer
                rend.enabled = false; // sets to false if hit.
                Destroy(this.gameObject, 1.2f);
            }
            else if (other.gameObject.tag == "map")
                transform.parent.GetComponent<spawner>().score = 0;
        }
    }
}
