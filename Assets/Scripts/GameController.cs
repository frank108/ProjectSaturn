using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public bool HasRocketLauncher = false;

    public static GameController Handler;

    public TextMesh playerhealth;

    public TextMesh playerammo;

    public int MissleCount = 3;

    void Start()
    {
        Handler = this;
    }
}
