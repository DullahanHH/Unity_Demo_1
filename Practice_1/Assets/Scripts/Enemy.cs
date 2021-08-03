using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 8;     //敌人血量
    public float moveSpeed = 1;
    public int coinDropNum = 1;
    public GameObject explodePrefab;
    public GameObject coinPrefab;

    private AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)       //血量小于0，销毁本体
        {
            deathEffect();

            generateCoin(coinDropNum);
        }
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))     //when touch bullet, take damage
        {
            health--;
            hitSound.Play();
        }
        if (collision.tag.Equals("Player"))     //when touch player, explode
        {
            deathEffect();
        }
        if (collision.CompareTag("Deck"))       //when touch deck, explode
        {
            deathEffect();
        }
    }

    /**
     * 生成 number 枚金币，向随机方向
     * 以随机力度（10~20）发射.
     */
    private void generateCoin(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject coinCopy = Instantiate(coinPrefab, transform.position, transform.rotation);

            Vector2 randomDir = new Vector2(Random.Range(-1.0f, 2.0f), Random.Range(-1.0f, 2.0f)).normalized;

            coinCopy.GetComponent<Rigidbody2D>().AddForce(randomDir * Random.Range(10, 20));
        }
    }

    /**
     * 生成爆炸特效并摧毁本体
     */
    private void deathEffect()
    {
        GameObject explodeCopy = Instantiate(explodePrefab, transform.position, transform.rotation);    //生成爆炸特效（Prefab）
        Destroy(explodeCopy, 0.333f);       //特效结束时间后删除特效
        Destroy(gameObject);
    }
}
