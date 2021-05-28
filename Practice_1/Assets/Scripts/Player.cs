using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public Transform bulletHolder;

    public int health = 3;
    public int coinTotal = 0;

    private AudioSource shootSound;
    private AudioSource coinPickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0, 0.15f);       //每隔一段时间调用开火function

        shootSound = GetComponent<AudioSource>();

        GameObject firePoint = GameObject.Find("Player/Sound_PickUpCoin");
        coinPickUpSound = firePoint.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))      //当敌人tag与机体碰撞，掉1点血
        {
            takeDamage();
        }

        if (collision.CompareTag("Coin"))
        {
            coinTotal += Random.Range(1, 10);
            coinPickUpSound.Play();
        }
    }

    private void Fire()
    {
        GameObject copyBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        copyBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * 1000);

        copyBullet.transform.parent = bulletHolder;     //将复制的子弹放入holder，保持hierarchy整洁

        shootSound.Play();
    }

    public void takeDamage()
    {
        health--;
    }

}
