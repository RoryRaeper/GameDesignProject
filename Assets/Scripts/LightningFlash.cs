using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningFlash : MonoBehaviour {

    private Light lightning;
    private float timer;
    private float lightDuration;
    private bool audioPlayed;
    // Use this for initialization
    void Start () {

        lightning = GameObject.FindGameObjectWithTag("Lightning").GetComponent<Light>();
        timer = 1;
        lightDuration = 2;
        audioPlayed = false;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        Debug.Log("Time Left until flash: " + timer);
        if(timer <= 0)
        {
            if (!(audioPlayed))
            {
                GetComponent<AudioSource>().Play();
                lightning.intensity = 8;
                audioPlayed = true;
            }
            lightDuration -= Time.deltaTime;
            if(lightDuration <= 0)
            {
                lightning.intensity = 0f;
                timer = 10;
                lightDuration = 2;
                audioPlayed = false;
            }
            else
            {
                lightning.intensity = lightDuration;
            }
        }
	}
}
