using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 8;     //����Ѫ��
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
        if (health <= 0)       //Ѫ��С��0�����ٱ���
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
     * ���� number ö��ң����������
     * ��������ȣ�10~20������.
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
     * ���ɱ�ը��Ч���ݻٱ���
     */
    private void deathEffect()
    {
        GameObject explodeCopy = Instantiate(explodePrefab, transform.position, transform.rotation);    //���ɱ�ը��Ч��Prefab��
        Destroy(explodeCopy, 0.333f);       //��Ч����ʱ���ɾ����Ч
        Destroy(gameObject);
    }
}
