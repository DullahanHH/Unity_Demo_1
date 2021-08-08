using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float frequency = 5f;
    [Range(0, 100)]
    public float normalEnemyChance = 90;        //��ͨ���˳�������
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
        enemyType = Random.Range(1, 100);      //��ͨ��������˸���ȡֵ
        randomX = Random.Range(-8, 8);      //X�����λ��
        randomSpecial = Random.Range(0, enemy_special.Length);      //��������������

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
