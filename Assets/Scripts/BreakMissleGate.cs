using UnityEngine;
using System.Collections;

public class BreakMissleGate : MonoBehaviour
{
    void OnTriggerEnter(Collider possible_missle)
    {
        if (possible_missle.tag == "Missle")
        {
            Destroy(this.gameObject);
            Destroy(possible_missle.gameObject);
        }
    
    }
}