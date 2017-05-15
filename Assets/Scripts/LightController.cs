using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    private float lightDuration;
    private ScoreManager SCM;
    private Light lightAura;
	// Use this for initialization
	void Start () {
		SCM = FindObjectOfType<ScoreManager>();
        lightAura = GameObject.FindGameObjectWithTag("LightBulb").GetComponent<Light>();
    }
	
	void Update()
    {
        lightDuration = SCM.TimeLeft();

        if(lightDuration > 8) 
        {
            lightAura.intensity = 8;
            lightAura.range = 6;
        }
        else
        {
            lightAura.intensity = lightDuration;
            lightAura.range = 5;
        }
    }
}
