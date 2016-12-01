using UnityEngine;
using System.Collections;

public class DestroyByWall : MonoBehaviour

{
    public GameObject explosion;
    public GameObject creator;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == creator) return;

        print("OnTriggerEnter " + other.tag);
        if (other.tag == "Wall")
        {
            print("Hit Wall");
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
        else if (other.tag == "Enemy")
        {
            print("Hit");
            var enemyScript = other.gameObject.GetComponent<EnemyHealth>();
            enemyScript.hits = enemyScript.hits - 1;
            if (enemyScript.hits <= 0)
            {
                Destroy(other.gameObject);
            }

            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }

        else if (other.tag == "Player")
        {
            var saturnScript = other.gameObject.GetComponent<SaturnHealth>();
            saturnScript.hits = saturnScript.hits - 1;
            GameController.Handler.playerhealth.text = saturnScript.hits.ToString();
            if (saturnScript.hits <= 0)
            {
                other.transform.position = new Vector3(0, 0, 0);
                saturnScript.hits = saturnScript.startinghits;
            }

            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
        else if (other.tag == "Shield")
        {
            Destroy(this.gameObject);
        }
    }
}

