using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour {

    // Use this for initialization
	void Start () {
    }
	

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.AddBattery();
            Destroy(gameObject);
        }

    }
}
