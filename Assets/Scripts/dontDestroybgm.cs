using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroybgm : MonoBehaviour
{
    string sceneName;

    private void Start()
    {
        sceneName = "Level1";
    }
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            Destroy(this.gameObject);
        }
    }
}
