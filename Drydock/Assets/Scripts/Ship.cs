using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    Vector2 shipPos;
    public int x = 1;
    public int y = -1;
    static public int shields = 0;
    static public int cannons = 0;
    static public int engine = 0;
    static public int cargoBays = 0;
    public int healt = 10;
    public int tempShield = 0;
    public int shieldHealt = 0;
    public int cannonsHealt = 0;
    public int engineHealt = 0;
    public int cargoBaysHealt = 0;

    void Start ()
    {

	}

	void Update ()
    {
       
    }
}

