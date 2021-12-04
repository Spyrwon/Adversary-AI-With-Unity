using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOffense : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public aiManagers aimanager;

    //MLAgentLogic agentlogic;


    bool alreadyAttacked = false;

    float timeBetweenAttacks = 2f; //out

    void Start()
    {
        /*
        float mlintime = 1;
        mlintime = mlintime * mlintime;
        timeBetweenAttacks = 4 * Mathf.Sqrt(mlintime);
        */
    }

    // Update is called once per frame
    void Update()
    {
        float posx = player.transform.position.x;
        float posy = player.transform.position.y;
        if (Mathf.Abs(transform.position.x - player.transform.position.x)<3)
        {
            if (Mathf.Abs(transform.position.z - player.transform.position.z)<3)
            {
                if (!alreadyAttacked)
                {
                    aimanager.pdamage();
                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                }


            }
        }
    }
    public void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
