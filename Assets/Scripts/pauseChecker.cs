using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseChecker : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        if (Time.timeScale == 1f)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
