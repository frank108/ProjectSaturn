using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public enum WeaponSelection
{
    Bullet,
    Missle,
    Sword,
    Bomb,
}

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool jump = false;				// Condition for whether the player should jump.

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject bullet;
    public GameObject missle;
    public GameObject sword;
    public GameObject bomb;

    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    private AudioSource audioSource;

    private WeaponSelection weaponSelection = WeaponSelection.Bullet;

    private bool grounded = false;			// Whether or not the player is grounded.

    void OnStart()
    {
        Physics.gravity = new Vector3(0.0f, -30f, 0.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSelection = WeaponSelection.Bullet;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameController.Handler.HasRocketLauncher) 
        {
            weaponSelection = WeaponSelection.Missle;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponSelection = WeaponSelection.Sword;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponSelection = WeaponSelection.Bomb;
        }


        var rb = GetComponent<Rigidbody>();
        if (rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            var vel = new Vector3(1, 0, 0);
            if (GetComponent<SpriteRenderer>().flipX)
            {
                vel = vel * -1;
            }

            if (weaponSelection == WeaponSelection.Bullet)
            {
                var bullet = Instantiate(this.bullet, transform.position, transform.rotation) as GameObject;
                bullet.GetComponent<Rigidbody>().velocity = vel * speed;
                bullet.GetComponent<DestroyByWall>().creator = this.gameObject;
            }
            else if(weaponSelection == WeaponSelection.Missle && GameController.Handler.MissleCount > 0)
            {
                var missle = Instantiate(this.missle, transform.position, transform.rotation) as GameObject;
                missle.GetComponent<Rigidbody>().velocity = vel * speed;
                missle.GetComponent<DestroyByWall>().creator = this.gameObject;
                GameController.Handler.MissleCount--;
                GameController.Handler.playerammo.text = GameController.Handler.MissleCount.ToString();
            }
            else if(weaponSelection == WeaponSelection.Sword)
            {
                var sword = Instantiate(this.sword, transform.position, transform.rotation) as GameObject;
                sword.GetComponent<Rigidbody>().velocity = vel * speed;
                sword.GetComponent<DestroyByWall>().creator = this.gameObject;
            }
            else if(weaponSelection == WeaponSelection.Bomb)
            {
                var missle = Instantiate(this.bomb, transform.position, transform.rotation) as GameObject;
                bomb.GetComponent<Rigidbody>().velocity = vel * speed;
                bomb.GetComponent<DestroyByWall>().creator = this.gameObject;
            }
        }
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    void FixedUpdate()

    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.1f, this.transform.position.z);

        if (jump)
        {

            // Add a vertical force to the player.
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 50, 0) * 100);

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //var y = collision.gameObject.transform.position.y;
        //var h = collision.gameObject.GetComponent<BoxCollider>().size.y;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, this.transform.position.z);
    }
}