using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public int health = 10;
    public bool isInvincible = false;
    public bool isImmune = false;
    public int invincibilityTime = 5;
    public int immunityTime = 3;


    //blink stuff
    public float distance = 10f;
    public GameObject trail;
    public bool canBlink = false;

    public Image sprite1;
    public Image sprite2;
    public Image sprite3;

    public GameObject shield;


    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false; // blink
    }

    // Update is called once per frame
    void Update()
    {
        //blink stuff
        if (Input.GetKeyDown(KeyCode.E) && canBlink == true)
        {
            Debug.Log("Key Pressed");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, distance);

            if (hit.collider == null)
            {
                transform.position += transform.localScale.x * Vector3.right * distance;

            }
            else
            {
                transform.position = hit.point;
            }
            StartCoroutine(LoseTime());

        }

        if (health == 3)
        {
            sprite1.enabled = true; 
            sprite2.enabled = true;
            sprite3.enabled = true;
        }
        if (health == 2)
        {
            sprite1.enabled = true;
            sprite2.enabled = true;
            sprite3.enabled = false;
        }
        if (health == 1)
        {
            sprite1.enabled = true;
            sprite2.enabled = false;
            sprite3.enabled = false;
        }
        if (health == 0)
        {
            sprite1.enabled = false;
            sprite2.enabled = false;
            sprite3.enabled = false;
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isInvincible == true)
        {
            Destroy(collision.gameObject);
            Debug.Log("Defeated");

        }
        else if (collision.gameObject.tag == "Enemy" && isImmune == true)
        {
            Debug.Log("Can't take damage!");
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Took Damage!");
            health--;
            isImmune = true;
            StartCoroutine(LoseImmunityTime());
            canBlink = false;
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Debug.Log("Defeated");
        }
        if (collision.gameObject.tag == "goal")
        {
            Destroy(collision.gameObject);
            Debug.Log("Finished");
        }
        if (collision.gameObject.tag == "Invincible")
        {
            isInvincible = true;
            Destroy(collision.gameObject);
            Debug.Log("Is Invincible!");
            shield.SetActive(true);
            StartCoroutine(LoseInvincibilityTime());
        }
        if (collision.gameObject.tag == "Blink")
        {
            canBlink = true;
            Destroy(collision.gameObject);
            Debug.Log("Can Blink!");
        }
    }

    //blink stuff
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * distance);
    }
    IEnumerator LoseInvincibilityTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(invincibilityTime);
            isInvincible = false;
            shield.SetActive(false);
            yield break;
        }
    }

    //blink stuff
    IEnumerator LoseTime()
    {
        while (true)
        {
            trail.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            trail.SetActive(false);
            yield break;
        }
    }

    IEnumerator LoseImmunityTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(immunityTime);
            isImmune = false;
            yield break;
        }
    }
}
