using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{

    public float velocity;
    public bool up;
    public GameObject borderUp;

    // Start is called before the first frame update
    void Start()
    {
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        Vector2 pos = transform.position;

        if (up)
        {
            pos.y += velocity * Time.deltaTime;
        }
        else
        {
            pos.y -= velocity * Time.deltaTime;
        }

        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "BorderUp")
        {
            up = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            up = true;
        }
    }

}
