using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offense : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject player;

    public aiManagers aimanager;

    bool alreadyAttacked1;
    bool alreadyAttacked2;
    bool alreadyAttacked3;

    float attackRange = 2f;

    float timeBetweenAttacks=0.5f;

    // Update is called once per frame
    void Update()
    {
        float posx = enemy1.transform.position.x;
        float posy = enemy1.transform.position.y;

        if (Mathf.Abs(enemy1.transform.position.x - player.transform.position.x )<2.5)
        {
            if(Mathf.Abs(enemy1.transform.position.z - player.transform.position.z ) < 2.5)
            {
                if (!alreadyAttacked1)
                {
                    aimanager.e1damage();
                    alreadyAttacked1 = true;
                    Invoke(nameof(ResetAttack1), timeBetweenAttacks);
                }


            }
        }

         posx = enemy2.transform.position.x;
         posy = enemy2.transform.position.y;

        if (Mathf.Abs(enemy2.transform.position.x - player.transform.position.x ) < 2.5)
        {
            if (Mathf.Abs(enemy2.transform.position.z - player.transform.position.z ) < 2.5)
            {
                if (!alreadyAttacked2)
                {
                    aimanager.e2damage();
                    alreadyAttacked2 = true;
                    Invoke(nameof(ResetAttack2), timeBetweenAttacks);
                }
            }
        }

         posx = enemy3.transform.position.x;
         posy = enemy3.transform.position.y;

        if (Mathf.Abs(enemy3.transform.position.x - player.transform.position.x ) < 2.5)
        {
            if (Mathf.Abs(enemy3.transform.position.z - player.transform.position.z ) < 2.5)
            {
                if (!alreadyAttacked3)
                {
                    aimanager.e3damage();
                    alreadyAttacked3 = true;
                    Invoke(nameof(ResetAttack3), timeBetweenAttacks);
                }
            }
        }
    }

    public void ResetAttack1()
    {
        alreadyAttacked1 = false;
    }

    public void ResetAttack2()
    {
        alreadyAttacked2 = false;
    }
    public void ResetAttack3()
    {
        alreadyAttacked3 = false;
    }
}
