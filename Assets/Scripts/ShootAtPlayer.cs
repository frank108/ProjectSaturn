using UnityEngine;
using System.Collections;

public class ShootAtPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject missle;
    public float speed;

    void Start()
    {
        StartCoroutine(ShootTimer());
    }

    void Update()
    {

    }

    public IEnumerator ShootTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);

            var vel = new Vector3(player.transform.position.x - this.transform.position.x,
                player.transform.position.y - this.transform.position.y,
                0f);

            var missle = Instantiate(this.missle, transform.position, transform.rotation) as GameObject;
            missle.GetComponent<Rigidbody>().velocity = vel * speed;

            missle.GetComponent<DestroyByWall>().creator = this.gameObject;


        }
    }
}
