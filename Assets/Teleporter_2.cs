using UnityEngine;
using System.Collections;

public class Teleporter_2 : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        other.transform.position = new Vector3(21, 8, 0);
        print("Tele2");
    }
}

