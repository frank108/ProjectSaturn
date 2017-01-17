using UnityEngine;
using System.Collections;

public class Walker_Move : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;

    void Start()
    {
        StartCoroutine(ExecuteAfterTime(3));
        rb = GetComponent<Rigidbody>();
        ////rb.velocity = transform.forward * speed;
        //var vel = new Vector3(1, 0, 0);
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

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        print("Change");

        rb.velocity = rb.velocity * -1;
        StartCoroutine(ExecuteAfterTime(3));
    }
}