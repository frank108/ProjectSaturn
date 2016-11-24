using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other) {
        other.transform.position = new Vector3(0, 0, 0);
        print("Derp");
    }
}
