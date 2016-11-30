using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        other.transform.position = new Vector3(-63, 10, 0);
        print("Tele");
    }
}
