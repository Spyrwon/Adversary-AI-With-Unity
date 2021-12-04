using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiManagers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject player;

    public float damage = 50f; //out
    //MLAgentLogic agentlogic;

    public GameManagerScript Gms;

    public float health=100f; //oput
    public float eDamage = 20;

    public float e1health;
    bool e1dead = false;
    public float e2health;
    bool e2dead = false;
    public float e3health;
    bool e3dead = false;
    public float phealth=20;

    public int deathCount;

    void Start()
    {
        /*
        float mlinhealth = 1;
        mlinhealth = mlinhealth * mlinhealth;
        health = 50 + (Mathf.Sqrt(mlinhealth) * 50);

        float mlindamage = 1;
        mlindamage = mlindamage * mlindamage;
        eDamage = 300 * Mathf.Sqrt(mlindamage);

        //float pDamage = 50;

        deathCount = 0;
        e1health = health;
        e2health = health;
        e3health = health;
        //phealth = 20;
        */
}

    // Update is called once per frame
    void Update()
    {
        Debug.Log("health: " + phealth);
        if (e1health <= 0 && !e1dead)
        {
            enemy1.SetActive(false);
            e1dead = true;
            deathCount++;
        }
        if (e2health <= 0 && !e2dead)
        {
            enemy2.SetActive(false);
            e2dead = true;
            deathCount++;
        }
        if (e3health <= 0 && !e3dead)
        {
            enemy3.SetActive(false);
            e3dead = true;
            deathCount++;
        }
        if (phealth <= 0)
        {
            Debug.Log("Death");
            Gms.CreateLog("Death", 0f);
            //player.SetActive(false);
            //agentlogic.endEpisodeOnDeath();
        }
    }

    public void e1damage()
    {
        e1health -= damage;
    }
    public void e2damage()
    {
        e2health -= damage;
    }
    public void e3damage()
    {
        e3health -= damage;
    }
    public void pdamage()
    {
        phealth -= eDamage;
        //Debug.Log("Damage Taken" + phealth);
    }
}
