using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class cheatMenu : MonoBehaviour
{
    public Toggle invincibleToggle;
    public Toggle otherToggle;

    public bool invincibleActive = false;
    public bool otherActive = false;

    GameObject player;

    private void Start()
    {
        invincibleToggle.onValueChanged.AddListener(OnInvincibleToggle);
        otherToggle.onValueChanged.AddListener(OnOtherToggle);

        invincibleToggle.isOn = invincibleActive;
        otherToggle.isOn = otherActive;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnInvincibleToggle(bool isActive)
    {
        invincibleActive = isActive;

        if (invincibleActive)
        {
            ActivateInvincible();
        }
        else
        {
            DeactivateInvincible();
        }
    }

    private void OnOtherToggle(bool isActive)
    {
        otherActive = isActive;

        if (otherActive)
        {
            ActivateOther();
        }
        else
        {
            DeactivateOther();
        }
    }

    private void ActivateInvincible()
    {
        Debug.Log("Invincible Cheat Activated!");
        player.GetComponent<PlayerInteraction>().shield.SetActive(true);
        player.GetComponent<PlayerInteraction>().shieldActive = true;
        player.GetComponent<PlayerInteraction>().invincibleCheatSprite.SetActive(true);
    }

    private void DeactivateInvincible()
    {
        Debug.Log("Invincible Cheat Deactivated.");
        player.GetComponent<PlayerInteraction>().shield.SetActive(false);
        player.GetComponent<PlayerInteraction>().shieldActive = false;
        player.GetComponent<PlayerInteraction>().invincibleCheatSprite.SetActive(false);
    }

    private void ActivateOther()
    {
        Debug.Log("Other Cheat Activated!");
    }

    private void DeactivateOther()
    {
        Debug.Log("Other Cheat Deactivated.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invincibleActive == true && collision.gameObject.tag == "Invincible")
        {
            Destroy(collision.gameObject);
        }
    }
}
