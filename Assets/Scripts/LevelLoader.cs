using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public string nextLevel;
    public bool playerWaiting;
    private float timeToProceed;
	// Use this for initialization
	void Start () {
        playerWaiting = false;
        timeToProceed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerWaiting)
        {
            timeToProceed -= Time.deltaTime;
        }
        else
        {
            timeToProceed = 2f;
        }

        if(timeToProceed <= 0)
        {
            SceneManager.LoadScene(nextLevel);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            playerWaiting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            playerWaiting = false;
        }
    }

}


