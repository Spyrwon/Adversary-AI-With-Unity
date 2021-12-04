using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.IO;

public class GameManagerScript : MonoBehaviour
{
    public GameObject goal;
    public GameObject player;
    public NavMeshAgent agent;
    float score=0;

    MLAgentLogic agentlogic;

    private Transform post1;
    private Transform post2;
    private Transform post3;

    private Vector3 pos1 = new Vector3(24.0f, 1.4f, 24.0f);
    private Vector3 pos2 = new Vector3(-24.0f, 1.4f, 24.0f);
    private Vector3 pos3 = new Vector3(24.0f, 1.4f, -24.0f);
    private Vector3 pos4 = new Vector3(-24.0f, 1.4f, -24.0f);

    public void CreateLog(string state, float score)
    {
        //path
        Debug.Log("Log Created");
        string path = Application.dataPath + "/Log.txt";
        string content = "State: " + state + "\nScore: " + score;
        File.WriteAllText(path, content);
        
    }
   


    // Start is called before the first frame update
    void Start()
    {
        agent.enabled = false;
        float seed = Random.Range(0.0f, 18.0f);
        //seed = 13;
        //Debug.Log("Seed: " + seed);
        if (seed <= 6)
        {
            goal.transform.position = pos1;
            /*if (seed < 3)
            {
                player.transform.position = pos2;
            }
            else
            {*/
                player.transform.position = pos4;
            //}
        }
        else if (seed <= 12)
        {
            goal.transform.position = pos2;
            /*if (seed < 9)
            {
                player.transform.position = pos1;
            }
            else
            {*/
                player.transform.position = pos3;
            //}
        }
        else if (seed <= 18)
        {
            goal.transform.position = pos3;
            /*if (seed < 15)
            {
                player.transform.position = pos1;
            }
            else
            {*/
                player.transform.position = pos2;
            //}
        }
        agent.enabled = true;
        agent.SetDestination(goal.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float playerposx = player.transform.position.x;
        float goalposx = goal.transform.position.x;
        float justrand=0;
       
        if (Mathf.Abs(player.transform.position.x - goal.transform.position.x) < 2f)
        {
            
            if (Mathf.Abs(player.transform.position.z - goal.transform.position.z) < 2f)
            {
                //agentlogic.endEpisodeOnGoal();
                justrand++;
                //float tempdef = playerposy - goalposy;
                Debug.Log("Posi Player : " + player.transform.position.x);
                Debug.Log("Posi Goal : " + goal.transform.position.x);
                //Debug.Log("Posi Delta: "+ tempdef);
                Debug.Log("Goal Reached");
                CreateLog("GoalReached", score);
            }
        }
    }
}
