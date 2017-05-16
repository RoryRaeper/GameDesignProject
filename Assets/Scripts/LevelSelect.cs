using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public void TutorialSelect()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void TutorialDarkSelect()
    {
        SceneManager.LoadScene("TutorialDark");
    }

    public void LevelOneSelect()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LevelTwoSelect()
    {
        //SceneManager.LoadScene("LevelOne");
    }

    public void LevelThreeSelect()
    {
        //SceneManager.LoadScene("LevelOne");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}