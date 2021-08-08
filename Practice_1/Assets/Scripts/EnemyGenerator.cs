using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float frequency = 5f;
    [Range(0, 100)]
    public float normalEnemyChance = 90;        //普通敌人出生概率
    public GameObject enemy;
    public GameObject[] enemy_special;
    public Transform enemyHolder;

    private float randomX, enemyType;
    private int randomSpecial;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generator", frequency, frequency);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Generator()
    {
        enemyType = Random.Range(1, 100);      //普通或特殊敌人概率取值
        randomX = Random.Range(-8, 8);      //X轴出生位置
        randomSpecial = Random.Range(0, enemy_special.Length);      //随机到的特殊敌人

        if (enemyType < normalEnemyChance)
        {
            GameObject enemyCopy = Instantiate(enemy, new Vector2(randomX, transform.position.y), enemy.transform.rotation);
            enemyCopy.transform.parent = enemyHolder;
        } else
        {
            GameObject enemyCopy = Instantiate(enemy_special[randomSpecial], new Vector2(randomX, transform.position.y), enemy_special[randomSpecial].transform.rotation);
            enemyCopy.transform.parent = enemyHolder;
        }
        

        
    }
}
