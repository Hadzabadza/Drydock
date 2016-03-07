using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour
{
    public Transform CardBack;
    public static int rows =3;
    public static int cols =3;
    int[,] level1Board = new int[rows,cols];
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
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                newCard=Instantiate (CardBack, new Vector2(i * 3.0F - 3.0F, j * 4.5F - 4.5F), Quaternion.identity) as Card;
                level1Board[i,j]= (int)Mathf.Round(Random.Range(-0.4F, 7.0F));
                newCard.flip = level1Board[i, j];
            }
        }
    }

	void Update () {

	
	}

}

