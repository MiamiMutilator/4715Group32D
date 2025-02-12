using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatMenu : MonoBehaviour
{
    public bool invincibileOn;
    public bool otherOn;

    // Start is called before the first frame update
    void Start()
    {
        invincibileOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void invincibleCheatOn()
    {
        invincibileOn = true;
    }

    public void otherCheatOn()
    {

    }
}
