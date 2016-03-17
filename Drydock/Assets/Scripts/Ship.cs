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
    bool moving = false;
    bool moveDown = false;
    bool moveUp = false;
    bool moveRight = false;
    bool moveLeft = false;
    float temp;

    void Start ()
    {
        shipPos.y = 0;
        shipPos.y = 0;
        temp = 0;
	}

	void Update ()
    {
        if(!moving)
        {
            if (firstMove)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    moveDown = true;
                    moving = true;
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
                        moveLeft = true;
                        moving = true;
                        x -= 1;
                        //Card.FlipAnim();
                    }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (x + 1 <= Level1.cols - 1)
                    {
                        moveRight = true;
                        moving = true;
                        x += 1;
                        //Card.FlipAnim();
                    }
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (y - 1 >= 0)
                    {
                        moveUp = true;
                        moving = true;
                        y -= 1;
                        //Card.FlipAnim();
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (y + 1 <= Level1.rows - 1)
                    {
                        moveDown = true;
                        moving = true;
                        y += 1;
                        
                    }
               }
           }
       }
       else
       {
            if(moveDown)
            {
                gameObject.GetComponent<Transform>().Translate(new Vector2(0.0f, -0.01f));
                temp -= 0.01f;
                Debug.Log(temp);
                if (temp < -4.5f)
                {
                    Debug.Log("ciao");
                    moveDown = false;
                    moving = false;
                    temp = 0;
                    
                }
            }
            else if(moveUp)
            {
                gameObject.GetComponent<Transform>().Translate(new Vector2(0.0f, 0.01f));
                temp += 0.01f;
                if (temp > 4.5f)
                {
                    moveUp = false;
                    moving = false;
                    temp = 0;
                }
            }
            else if(moveRight)
            {
                gameObject.GetComponent<Transform>().Translate(new Vector2(0.05f, 0.0f));
                temp += 0.05f;
                if (temp > 3.0f)
                {
                    moveRight = false;
                    moving = false;
                    temp = 0;
                }
            }
            else if(moveLeft)
            {
                gameObject.GetComponent<Transform>().Translate(new Vector2(-0.01f, 0.0f));
                temp -= 0.01f;
                if (temp < -3.0f)
                {
                    moveLeft = false;
                    moving = false;
                    temp = 0;
                }
            }
        }
        gameObject.GetComponent<Transform>().Translate(new Vector2(shipPos.x, shipPos.y));
    }
}

