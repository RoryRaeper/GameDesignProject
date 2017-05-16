using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    public LevelManager lm;
    // Use this for initialization
    void Start () {
        lm = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lm.currentCP = gameObject;
            Debug.Log("Checkpoint Reached");
        }

    }
}
