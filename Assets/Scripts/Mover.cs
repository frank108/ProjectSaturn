using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ////rb.velocity = transform.forward * speed;
        //var vel = new Vector3(1, 0, 0);
        print(rb.velocity.magnitude);
        if (rb.velocity.magnitude == 0)
        {
            print("set" + speed);
            var vel = new Vector3(1, 0, 0);
            rb.velocity = vel * speed;
            print("set" + rb.velocity);
        }
        else
        {
            rb.velocity = rb.velocity * speed;
        }
    }
}