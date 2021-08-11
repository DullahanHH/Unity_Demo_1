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
    public bool isSkillFlashPurchase = false;
    public int skillColdDown = 10;

    private AudioSource shootSound;
    private AudioSource coinPickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0, 0.15f);       //ÿ��һ��ʱ����ÿ���function

        shootSound = GetComponent<AudioSource>();

        GameObject coinSound = GameObject.Find("Player/Sound_PickUpCoin");
        coinPickUpSound = coinSound.GetComponent<AudioSource>();

        InvokeRepeating("ColdDownCounting", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        SkillFlash();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))      //������tag�������ײ����1��Ѫ
        {
            takeDamage();
        }

        if (collision.tag.Equals("Enemy Bullet"))
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

        copyBullet.transform.parent = bulletHolder;     //�����Ƶ��ӵ�����holder������hierarchy����
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

    public void SkillFlash()
    {
        float xPos = -gameObject.transform.position.x;
        float yPos = gameObject.transform.position.y;

        if (Input.GetKeyDown(KeyCode.Space) && isSkillFlashPurchase && skillColdDown == 0)
        {
            gameObject.transform.position = new Vector3(xPos, yPos, 0);
            skillColdDown = 10;
            InvokeRepeating("ColdDownCounting", 0, 1);
        }
    }

    public string getColdDownCounting()
    {
        return string.Format("{0:D2}", skillColdDown);
    }

    private void ColdDownCounting()
    {
        if (skillColdDown != 0)
        {
            skillColdDown--;
        } else
        {
            CancelInvoke("ColdDownCounting");
        }
    }
}
