using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletNormal;
    public GameObject bulletSplit;

    public Transform firePoint;
    public Transform bulletHolder;

    public int health = 3;
    public int coinTotal = 0;
    public string weaponType = "Normal";

    private AudioSource shootSound;
    private AudioSource coinPickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0, 0.15f);       //每隔一段时间调用开火function

        shootSound = GetComponent<AudioSource>();

        GameObject coinSound = GameObject.Find("Player/Sound_PickUpCoin");
        coinPickUpSound = coinSound.GetComponent<AudioSource>();
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
    public void takeDamage()
    {
        health--;
    }

    private void Fire()
    {
        switch (weaponType)
        {
            case ("Normal"):
                CannonNormal();
                break;
            case ("Split"):
                CannonSplit();
                break;
        }

        shootSound.Play();
    }

    public void CannonNormal()
    {
        GameObject copyBullet = Instantiate(bulletNormal, firePoint.position, firePoint.rotation);

        copyBullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * 1000);

        copyBullet.transform.parent = bulletHolder;     //将复制的子弹放入holder，保持hierarchy整洁
    }

    public void CannonSplit()
    {
        GameObject copyBullet_0 = Instantiate(bulletSplit, firePoint.position, firePoint.rotation);
        GameObject copyBullet_1 = Instantiate(bulletSplit, firePoint.position, Quaternion.AngleAxis(15, Vector3.forward));
        GameObject copyBullet_2 = Instantiate(bulletSplit, firePoint.position, Quaternion.AngleAxis(-15, Vector3.forward));

        copyBullet_0.GetComponent<Rigidbody2D>().AddForce(firePoint.up * 1000);
        copyBullet_1.GetComponent<Rigidbody2D>().AddForce(copyBullet_1.transform.up * 1000);
        copyBullet_2.GetComponent<Rigidbody2D>().AddForce(copyBullet_2.transform.up * 1000);

        copyBullet_0.transform.parent = bulletHolder;
        copyBullet_1.transform.parent = bulletHolder;
        copyBullet_2.transform.parent = bulletHolder;
    }

}
