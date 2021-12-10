using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    public GameObject deathEffect;

    public float velocity;
    public bool right;
    public GameObject borderRight;
    public GameObject borderLeft;

    // Start is called before the first frame update
    void Start()
    {
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    private void Movement()
    {
        Vector2 pos = transform.position;
        //Flip();

        if (right)
        {
            pos.x += velocity * Time.deltaTime;
        }
        else
        {
            pos.x -= velocity * Time.deltaTime;
        }

        transform.position = pos;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject.transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "BorderLeft")
        {
            right = true;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if (col.transform.tag == "BorderRight")
        {
            right = false;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }

}
