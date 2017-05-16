using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShot : MonoBehaviour {

    //Call destroy method after 4 seconds
    void OnEnable()
    {
        Invoke("Destroy", 4f);
    }

    //Places the current object back into the pool
    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    //Stops object being called while being disabled
    void OnDisable()
    {
        CancelInvoke();
    }

    //When the turret shot collides, it will be sent back to the pool
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.CompareTag("RangeFinder")))
        {
            Destroy();
        }
    }
}
