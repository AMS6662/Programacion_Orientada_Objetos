using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    int sharpness;
    string material;
    int durability;

    void slay()
    {
        sharpness = -1;
    }

    void repair()
    {
        sharpness = 100;
        durability = 100;
    }

    void durabilityCheck()
    {
        if (durability <= 0)
        {
            Debug.Log("The sword is broken and cannot be used.");
        }
        else
        {
            Debug.Log("The sword is in good condition.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
