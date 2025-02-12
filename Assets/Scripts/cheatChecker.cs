using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheatChecker : MonoBehaviour
{
    public GameObject invincibleSprite;
    public GameObject otherSprite;

    public bool invincibleCheatIsOn;

    // Start is called before the first frame update
    void Start()
    {
        invincibleCheatIsOn = GameObject.Find("cheats").GetComponent<cheatMenu>().invincibileOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCheatIsOn == true)
        {
            invincibleSprite.SetActive(true);
        }
        else
        {
            invincibleSprite.SetActive(false);
        }
    }
}
