using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour
{
    public Transform CardBack;
    float x = -3.5f;
    float y = -4.5f;

    void Start ()
    {
        Invoke("SpawnObject",0);
	}
	
    void SpawnObject()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Instantiate(CardBack, new Vector2(i * 3.0F - 3.0F, j * 4.5F - 4.5F), Quaternion.identity);
            }
        }
    }

	void Update () {
	
	}

}
