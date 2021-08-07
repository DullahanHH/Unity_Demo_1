using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : Enemy
{
    public bool isShootable = false;

    public GameObject bullet;       //�ӵ�����

    public Transform firePoint;     //����λ��

    private GameObject holder;      //�ӵ�����λ��

    // Start is called before the first frame update
    void Start()
    {
        holder = GameObject.Find("Map_BulletHolder");

        hitSound = GetComponent<AudioSource>();

        Invoke("movingDown", 0);
        if (isShootable)
        {
            float randomTime = Random.Range(1, 4);
            Invoke("stopMoving", randomTime);
            InvokeRepeating("Fire", randomTime, 5);
        }
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

    private void stopMoving()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void Fire()
    {
        GameObject copyBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);

        copyBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * 10);

        copyBullet.transform.parent = holder.transform;     //�����Ƶ��ӵ�����holder������hierarchy����
    }
}
