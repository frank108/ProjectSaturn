using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour

{
    public int somecrap;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
        print("Health Picked Up");
            
                Destroy(this.gameObject);
            }    
        }
    }
