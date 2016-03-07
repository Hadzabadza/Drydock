using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    Vector2 shipPos;
    public int x = 1;
    public int y = -1;
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
    bool firstMove = true;

    void Start ()
    {
        shipPos.y = 0;
        shipPos.y = 0;
	}

	void Update ()
    {
        if (firstMove)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Transform>().Translate(new Vector2(0.0f, -4.5f));
                y += 1;
                firstMove = !firstMove;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (x - 1 >= 0)
                {
                    gameObject.GetComponent<Transform>().Translate(new Vector2(-3.0f, 0.0f));
                    x -= 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (x + 1 <= Level1.cols-1)
                {
                    gameObject.GetComponent<Transform>().Translate(new Vector2(+3.0f, 0.0f));
                    x += 1;
                }                    
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (y - 1 >= 0)
                {
                    gameObject.GetComponent<Transform>().Translate(new Vector2(0.0f, 4.5f));
                    y -= 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (y + 1 <= Level1.rows-1)
                {
                    gameObject.GetComponent<Transform>().Translate(new Vector2(0.0f, -4.5f));
                    y += 1;
                }
            }
            gameObject.GetComponent<Transform>().Translate(new Vector2(shipPos.x, shipPos.y));
        }
    }
}
