using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int health = 10;
    public bool isInvincible = false;
    public int invincibilityTime = 5;

    //blink stuff
    public float distance = 10f;
    public GameObject trail;
    public bool canBlink = false;


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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isInvincible == true)
        {
            Destroy(collision.gameObject);
            Debug.Log("Defeated");

        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Took Damage!");
            health--;
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
}
