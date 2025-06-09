using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    int lives;
    string power;
    int speed;
    
    void attack()
    {         // Code for attack logic
        Debug.Log("Spider attacks with " + power + " at speed " + speed);
    }

    void hide()
    {         // Code for hiding logic
        Debug.Log("Spider hides, remaining lives: " + lives);
    }

    void speedUp()
    {         // Code for increasing speed logic
        speed += 5;
        Debug.Log("Spider speed increased to " + speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
