using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    public LevelManager lm;
    //public int numOfBat;
    // Use this for initialization
    void Start () {
        lm = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lm.currentCP = gameObject;
            //numOfBat = ScoreManager.numOfBats;
            Debug.Log("Checkpoint Reached");
        }

    }
}
