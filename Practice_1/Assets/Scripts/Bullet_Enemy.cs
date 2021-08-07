using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))     //when touch bullet, destroy
        {
            Destroy(gameObject);
        }
        if (collision.tag.Equals("Player"))     //when touch player, explode
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Deck"))       //when touch deck, explode
        {
            Destroy(gameObject);
        }
    }
}
