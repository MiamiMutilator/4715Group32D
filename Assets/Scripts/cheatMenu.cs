using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatMenu : MonoBehaviour
{
    public bool invincibileOn;
    public bool otherOn;
    public GameObject invicheat;
    public PlayerInteraction pi;
    // Start is called before the first frame update
    void Start()
    {
        invincibileOn = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.X))
      {
        invincibleCheatOn();
        Debug.Log("Active",gameObject);
      }
    }

    public void invincibleCheatOn()
    {
        invincibileOn = !invincibileOn;
        invicheat.SetActive(invincibileOn);
        if(invincibileOn==true && pi!=null) pi.Invincible();
    }

    public void otherCheatOn()
    {

    }

    
}
