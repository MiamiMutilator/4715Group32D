using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private bool isLeft = true;
    public int timeMoved = 0;
    public int speed = 3;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft == true)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (timeMoved == 4)
            {
                isLeft = false;
                timeMoved = 0;
                FlipSprite();
            }
        }

        else if (isLeft == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (timeMoved == 4)
            {
                isLeft = true;
                timeMoved = 0;
                FlipSprite();
            }
        }

    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeMoved++;
        }
    }

    private void FlipSprite()
    {
        if (isLeft == false)
        {
            spriteRenderer.flipX = true;
        }
        if (isLeft == true)
        {
            spriteRenderer.flipX = false;
        }
    }
}