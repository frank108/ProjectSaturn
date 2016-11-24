using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {  
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Ammo Got");
            {
                Destroy(this.gameObject);
                GameController.Handler.HasRocketLauncher = true;
                GameController.Handler.MissleCount += 3;
            }
        }
    }
}

