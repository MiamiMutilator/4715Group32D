using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    //Ralfo Manzur
    //very simple script comprised of functions that can be used by the editor/application to load scenes, can be called/used in a variety of ways
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void LoadOption()
    {
        SceneManager.LoadScene("Option");
    }
    
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

void Start ()
{
    Time.timeScale = 1f;
}
}
