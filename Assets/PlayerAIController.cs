using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAIController : MonoBehaviour
{
    public Camera cam;
    public GameObject goal;
    public NavMeshAgent agent;

    private int flag = 1;
    // Update is called once per frame
    void start()
    {
        Debug.Log("inside start");
        StartCoroutine(ExampleCoroutine());
        
    }
    void Update()
    {/*
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        */
        
        //agent.SetDestination(goal.transform.position);
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.

        yield return new WaitForSeconds(2);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
