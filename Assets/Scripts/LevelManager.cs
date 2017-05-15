using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject currentCP;
    private PlayerController player;
    private ScoreManager scoreM;
    //private CheckpointManager CPM;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        //CPM = FindObjectOfType<CheckpointManager>();
        scoreM = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Respawn()
    {
        Debug.Log("Respawning Player");
        if(currentCP == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            scoreM.SetBatteries(1);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            player.transform.position = currentCP.transform.position;
        }       
    }
}
