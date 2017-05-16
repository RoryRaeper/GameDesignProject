using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager lm;

	void Start () {
        lm = FindObjectOfType<LevelManager>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lm.Respawn();
        }
       
    }

    public void Kill()
    {
        lm.Respawn();
    }
}
