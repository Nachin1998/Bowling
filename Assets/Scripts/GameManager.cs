using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public List<Pine> pines = new List<Pine>();
    public float forceToAdd;
    Rigidbody rb;
    float power;

    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            power += forceToAdd;
        }
         
        if(Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(transform.forward * power);
            power = 0;
        }

        if (pines[0].IsPineDown())
        {
            ball.transform.position = new Vector3(0, 1, -19);
        }        
    }
}
