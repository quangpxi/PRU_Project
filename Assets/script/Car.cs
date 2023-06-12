using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public float force = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carMoving();
    }

    void carMoving()
    {
        if (Input.GetKey("w"))
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force * Time.deltaTime));

        if (Input.GetKey("a"))
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force * Time.deltaTime, 0));

        if (Input.GetKey("d"))
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(force * Time.deltaTime, 0));

        if (Input.GetKey("s"))
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -force * Time.deltaTime));
    }
}
