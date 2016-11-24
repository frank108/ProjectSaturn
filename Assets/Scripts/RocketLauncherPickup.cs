using UnityEngine;
using System.Collections;

public class RocketLauncherPickup : MonoBehaviour

{
    public int somecrap;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
        print("Rocket's Obtained");
            {
                Destroy(this.gameObject);
                GameController.Handler.HasRocketLauncher = true;
            }
        }
    }
}
