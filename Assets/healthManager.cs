using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    // Start is called before the first frame update
    float health = 100f;

    // Update is called once per frame

    void takeDamage()
    {
        health -= 10;
    }
}
