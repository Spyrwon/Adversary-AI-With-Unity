using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MLAgentLogic : Agent
{
    public aiManagers aimanager;
    public float timebwattacks;
    public float agentHealth;
    public float agentDamage;
    public NavMeshAgent agent;
    public GameObject goal;
    public GameObject player;
    //public float agentDamage;

    private Vector3 pos1 = new Vector3(24.0f, 1.4f, 24.0f);
    private Vector3 pos2 = new Vector3(-24.0f, 1.4f, 24.0f);
    private Vector3 pos3 = new Vector3(-24.0f, 1.4f, -24.0f);


    public override void OnEpisodeBegin()
    {
        agent.enabled = false;
        float seed = Random.Range(0.0f, 18.0f);
        //seed = 13;
        //Debug.Log("Seed: " + seed);
        if (seed <= 6)
        {
            goal.transform.position = pos1;
            if (seed < 3)
            {
                player.transform.position = pos2;
            }
            else
            {
                player.transform.position = pos3;
            }
        }
        else if (seed <= 12)
        {
            goal.transform.position = pos2;
            if (seed < 9)
            {
                player.transform.position = pos1;
            }
            else
            {
                player.transform.position = pos3;
            }
        }
        else if (seed <= 18)
        {
            goal.transform.position = pos3;
            if (seed < 15)
            {
                player.transform.position = pos1;
            }
            else
            {
                player.transform.position = pos2;
            }
        }
        agent.enabled = true;
        agent.SetDestination(goal.transform.position);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(aimanager.phealth);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        agentDamage = actions.ContinuousActions[0];
        agentHealth = actions.ContinuousActions[1];
        timebwattacks = actions.ContinuousActions[2];

    }

    public void endEpisodeOnGoal()
    {
        float score = 0;
        float phealthmlin = aimanager.phealth - 10;
        if (phealthmlin < 0)
        {
            phealthmlin *= -1;
        }
        phealthmlin = phealthmlin / 100;
        phealthmlin = phealthmlin * phealthmlin;
        score = 3 * phealthmlin;
        float deathcount = aimanager.deathCount;
        float temp = (3 - deathcount) - 1;
        if (temp < 0)
        {
            temp *= -1;
        }
        score += 3 - 2 * temp;
        SetReward(score);
        EndEpisode();
    }

    public void endEpisodeOnDeath()
    {
        float score = -2;
        float temp = aimanager.deathCount;
        score -= 4 - (temp);
        SetReward(score);
        EndEpisode();
    }
}

/*
 * public float timeBWattacks = actions.ContinousActions[0];
        public float agentDamage = actions.ContinousActions[1];
        public float agentHealth = actions.ContinousActions[2];
 */