using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float frequency = 5f;
    public GameObject enemy;
    public Transform enemyHolder;

    private float randomX;

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
        randomX = Random.Range(-8, 8);
        GameObject enemyCopy = Instantiate(enemy, new Vector2(randomX, transform.position.y), enemy.transform.rotation);

        enemyCopy.transform.parent = enemyHolder;
    }
}
