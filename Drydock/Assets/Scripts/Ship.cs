using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    public Transform ship;
    public int credits = 3;
    public int shields = 0;
    public int cannons = 0;
    public int engine = 0;
    public int cargoBays = 0;
    public int healt = 10;
    public int tempShield = 0;
    public int shieldHealt = 0;
    public int cannonsHealt = 0;
    public int engineHealt = 0;
    public int cargoBaysHealt = 0;

    void Start ()
    {
        Invoke("SpawnObject", 0);
	}
	
    void SpawnObject()
    {
        Instantiate(ship, new Vector2(0,+9f), Quaternion.identity);
    }

	void Update ()
    {
	    
	}
}
