using UnityEngine;
using System.Collections;

public class Saturn_Shield : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Missle")
        {
            Destroy (this.gameObject);
        }
    }
}