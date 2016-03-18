using UnityEngine;
using System.Collections;

public class CardsEvent : MonoBehaviour {

    //when the cards are flipped set show as true and set the messagebox variable according to the card, for shipwreck call the shipwreck function
    private Rect windowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 400, 300);
    static public bool show = false;
    string shipWreckText;
    static public int MessageBoxIndex = 0;
    static public int SolarFlareTurns = 0;

    void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnGUI()
    {
        if (show)
        {
            if(MessageBoxIndex==1)
            {
                windowRect = GUI.Window(0, windowRect, TreasureMessageBox, "TREASURE");
            }
            else if(MessageBoxIndex==2)
            {
                windowRect = GUI.Window(0, windowRect, SolarFlareMessageBox, "SOLAR FLARE");
            }
            else if (MessageBoxIndex == 3)
            {
                windowRect = GUI.Window(0, windowRect, ExitMessageBox, "EXIT");
            }
            else if (MessageBoxIndex == 4)
            {
                windowRect = GUI.Window(0, windowRect, BanditsMessageBox, "BANDITS");
            }
            else if (MessageBoxIndex == 5)
            {
                windowRect = GUI.Window(0, windowRect, AsteroidsMessageBox, "ASTEROIDS");
            }
            else if (MessageBoxIndex == 6)
            {
                windowRect = GUI.Window(0, windowRect, TraderMessageBox, "TRADER");
            }
            else if (MessageBoxIndex == 7)
            {
                windowRect = GUI.Window(0, windowRect, ShipWreckMessageBox, "SHIP WRECK");
            }
            else if (MessageBoxIndex == 8)
            {
                windowRect = GUI.Window(0, windowRect, NebulaMessageBox, "NEBULA");
            }
        }
    }

    public void TreasureMessageBox(int windowID)
    {
        float y = 40;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "You found 2 credits");
        if (GUI.Button(new Rect(5, y + 120, windowRect.width - 10, 20), "Close"))
        {
            show = false;
            MessageBoxIndex = 0;
            TreasureFilp();
        }
    }

    void TreasureFilp()
    {
        if (CreditBalance.credits + (Ship.cargoBays * 2) <= CreditBalance.credits + 2)
        {
            CreditBalance.credits += 2;
        }
        else if (CreditBalance.credits + (Ship.cargoBays * 2) <= CreditBalance.credits + 1)
        {
            CreditBalance.credits += 1;
        }
    }

    public void SolarFlareMessageBox(int windowsID)
    {
        float y = 40;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "All Ship parts are disabled for 2 turns");
        if (GUI.Button(new Rect(5, y + 120, windowRect.width - 10, 20), "Close"))
        {
            show = false;
            MessageBoxIndex = 0;
            SolarFlareUpdate(2);
        }
    }

    void SolarFlareUpdate(int adding)
    {
        //removing turns
        if (SolarFlareTurns > 0 && adding < 0)
        {
            SolarFlareTurns += adding;
        }
        //adding turns
        else if (adding > 0)
        {
            SolarFlareTurns += adding;
        }
    }

    public void ExitMessageBox(int windowsID)
    {
        float y = 40;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "Congratulations! Level Complete");
        if (GUI.Button(new Rect(5, y + 120, windowRect.width - 10, 20), "Get to DryDock"))
        {
            show = false;
            MessageBoxIndex = 0;
            ExitFlip();
        }
    }

    void ExitFlip()
    {
        Application.LoadLevel("Store");
    }

    public void BanditsMessageBox(int windowsID)
    {
        float y = 40;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "Kill those bandits!");
        if (GUI.Button(new Rect(5, y + 120, windowRect.width - 10, 20), "Fight"))
        {
            show = false;
            MessageBoxIndex = 0;
            BanditsFlip();
        }
    }

    void BanditsFlip()
    {
        Application.LoadLevel("Bandits");
    }

    public void AsteroidsMessageBox(int windowsID)
    {
        float y = 40;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "Don't get smashed!");
        if (GUI.Button(new Rect(5, y + 120, windowRect.width - 10, 20), "Begin!"))
        {
            show = false;
            MessageBoxIndex = 0;
            AsteroidsFlip();
        }
    }

    void AsteroidsFlip()
    {
        Application.LoadLevel("Asteroids");
    }

    public void TraderMessageBox(int windowsID)
    {
        float y = 40;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "You found a trader, buy ship's parts");
        if (GUI.Button(new Rect(5, y + 120, windowRect.width - 10, 20), "Buy"))
        {
            show = false;
            MessageBoxIndex = 0;
            TraderFlip();
        }
        if (GUI.Button(new Rect(5, y + 160, windowRect.width - 10, 20), "Close"))
        {
            show = false;
        }
    }

    void TraderFlip()
    {
        Application.LoadLevel("Store");
    }

    void ShipWreckMessageBox(int windowsID)
    {
        float y = 40;
        GUI.Label(new Rect(5, y, windowRect.width, 20), shipWreckText);
        if (GUI.Button(new Rect(5, y + 120, windowRect.width - 10, 20), "Close"))
        {
            show = false;
            MessageBoxIndex = 0;
        }
    }

    public void shipWreckFlip()
    {
        int chance = (int)Mathf.Round(Random.Range(-0.4f, 5.0f));
        if (chance == 0)
        {
            int randomPart = (int)Mathf.Round(Random.Range(-0.4f, 3.0f));
            if (randomPart == 0)
            {
                Ship.shields += 1;
                shipWreckText = "You found 1 shield!";
            }
            else if (randomPart == 1)
            {
                Ship.cargoBays += 1;
                shipWreckText = "You found 1 cargobay!";
            }
            else if (randomPart == 2)
            {
                Ship.cannons += 1;
                shipWreckText = "You found 1 cannon!";
            }
            else if (randomPart == 3)
            {
                Ship.engine += 1;
                shipWreckText = "You found 1 engine!";
            }
        }
        else
        {
            shipWreckText = "You didn't find anything :(";
        }
        show = true;
    }

    public void NebulaMessageBox(int windowsID)
    {
        float y = 40;
        GUI.Label(new Rect(5, y, windowRect.width, 20), "You got in a Nebula, there can be anything inside!");
        if (GUI.Button(new Rect(5, y + 120, windowRect.width - 10, 20), "Explore"))
        {
            show = false;
            MessageBoxIndex = 0;
            NebulaFlip();
        }
    }

    void NebulaFlip()
    {
        int random = (int)Mathf.Round(Random.Range(-0.4f, 4.0f));
        if (random == 0)
        {
            show = true;
            MessageBoxIndex = 1;
        }
        else if (random == 1)
        {
            show = true;
            MessageBoxIndex = 2;
        }
        else if (random == 2)
        {
            show = true;
            MessageBoxIndex = 6;
        }
        else if (random == 3)
        {
            show = true;
            MessageBoxIndex = 4;
        }
        else if (random == 4)
        {
            show = true;
            MessageBoxIndex = 5;
        }
    }



}
