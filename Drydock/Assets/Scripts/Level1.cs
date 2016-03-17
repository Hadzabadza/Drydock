using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour
{
    public Transform CardBack;
    int level = 1;
    public static int rows =3;
    public static int cols =3;
    float x = -3.5f;
    float y = -4.5f;
    int card = 0;
    public Card newCard;

    void Start ()
    {
        Invoke("SpawnObject",0);
	}
	
    void SpawnObject()
    {
        if(level!=1)
        {
            rows++;
            cols++;
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                newCard=Instantiate (CardBack, new Vector2(i * 3.0F - 3.0F, j * 4.5F - 4.5F), Quaternion.identity) as Card;
            }
        }
    }

	void Update ()
    {
	}

}

