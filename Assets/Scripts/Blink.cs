using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float distance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * distance);
    }
}
