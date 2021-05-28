using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (collision.tag.Equals("Enemy"))      //trigger检测为敌人tag，销毁
        {
            Destroy(gameObject);

        } else
        {
            Destroy(gameObject, 1);     //其他情况在1秒后自动销毁
        }
    }
}
