using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private bool isLeft = true;
    public int timeMoved = 0;
    public int speed = 3;

    // Start is called before the first frame update
    void Start()
    {

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
                //workAround();
                Debug.Log("ya");
            }
        }

        /*if (isLeft == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (timeMoved == 4)
            {
                isLeft = true;
                workAround();
            }
        }*/

    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeMoved++;
        }
    }
}
