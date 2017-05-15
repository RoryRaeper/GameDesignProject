using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject movingPlatform;
    public float speed;
    private Transform currentPoint;
    public Transform[] turningPoints;
    public int nextPoint;

    void Start()
    {
        speed = 5f;
        currentPoint = turningPoints[nextPoint];
    }

    void Update()
    {
        movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position, currentPoint.position, (Time.deltaTime * speed));

        if (movingPlatform.transform.position == currentPoint.position)
        {
            nextPoint++;
            if (nextPoint >= turningPoints.Length)
            {
                nextPoint = 0;
            }
            currentPoint = turningPoints[nextPoint];
        }
    }


}
