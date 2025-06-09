using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    string material;
    string contents;
    int durability;
    // Start is called before the first frame update
    void open()
    {         // Code for opening the chest
        Debug.Log("Chest opened, contents: " + contents);
    }

    void destroy()
    {         // Code for destroying the chest
        Debug.Log("Chest destroyed, material: " + material);
    }

    void move()
    {         // Code for moving the chest
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
