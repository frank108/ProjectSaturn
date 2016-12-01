using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public GameObject Destination;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.position = Destination.transform.position;
        }
    }
}
