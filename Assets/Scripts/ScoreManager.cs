using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int numOfBats;
    public static float timeLeft;
    public float timer;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        numOfBats = 1;
        timeLeft = 10f;
    }

    void Update()
    {
        if (numOfBats >= 1)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                numOfBats = 0;
                timeLeft = 0f;
            }
        }
        string displayedTime = timeLeft.ToString("0.00");
        text.text = "" + displayedTime;
    }

    public static void AddBattery()
    {
        numOfBats++;
        timeLeft += 10;
    }

    public static void Reset()
    {
        numOfBats = 0;
    }

    public void SetBatteries(int batteryNumber)
    {
        numOfBats = batteryNumber;
        timeLeft += (batteryNumber * 10);
    }

    public int NumberOfBatteries()
    {
        return numOfBats;
    }

    public float TimeLeft()
    {
        return timeLeft;
    }
}
