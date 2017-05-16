using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float shootInterval;
    public float shotSpeed = 5f;
    public float bulletTimer;

    public Transform target;
    public Transform shootPoint;

    void Update()
    { 
        //Flips the turret if the player is on the far side.
        if(target.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }


    /*
     * Method for the Turret AI
     * Calls the Object Pool to reduce memory load
    */
    public void Shoot()
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            /*GameObject turretShotClone;
            turretShotClone = Instantiate(turretShot, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
            turretShotClone.GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;*/
            /*for(int i = 0; i < turretShots.Length; i++)
            {
                if(!turretShots[i].activeInHierarchy)
                {
                    turretShots[i].transform.position = shootPoint.transform.position;
                    turretShots[i].transform.rotation = shootPoint.transform.rotation;
                    turretShots[i].SetActive(true);
                    turretShots[i].GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;
                    break;
                }
            }*/

            GameObject obj = ObjectPooler.currentObject.GetPooledObject();

            if (obj != null)
            {
                obj.transform.position = shootPoint.transform.position;
                obj.transform.rotation = shootPoint.transform.rotation;
                obj.SetActive(true);
                GetComponent<AudioSource>().Play();
                obj.GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;
            }
            else
            {
                Debug.Log("No Objects in Pool");
                return;
            }

            bulletTimer = 0; //Sets the timer to 0 again, waiting for the next shot
        }
    }

}
