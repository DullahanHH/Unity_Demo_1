using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
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
        if (collision.CompareTag("Enemy"))
        {
            FindObjectOfType<Player>().takeDamage();
        }

        if (collision.tag.Equals("Enemy Bullet"))
        {
            FindObjectOfType<Player>().takeDamage();
        }
    }
}
