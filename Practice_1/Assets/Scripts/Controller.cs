using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 5;

    private Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        dir = new Vector2(h, v).normalized;
        target.GetComponent<Rigidbody2D>().velocity = dir * moveSpeed;
        //target.transform.Translate(dir * Time.deltaTime * moveSpeed);        //Another way of movement
    }
}
