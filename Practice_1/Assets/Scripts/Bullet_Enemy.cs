using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : Bullet
{
    public int health = 2;     //敌人血量

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)       //血量小于0，销毁本体
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))     //when touch bullet, destroy
        {
            health--;
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
