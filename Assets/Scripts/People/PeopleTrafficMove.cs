using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleTrafficMove : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform[] arrayPointWalk;
    [SerializeField] Transform[] trafficStop;
    public GameObject[] trafficActive;
    int countPoint = 0;
    void Update()
    {
        TrafficMove();
        MovementPeaple();
    }

    private void MovementPeaple()
    {
        //Если счетчик больше чем количетсво точек 
        if (countPoint > arrayPointWalk.Length - 1)
        {
            countPoint = 0;
        }
        //Сравнение позиции человека и точки назначения
        else if (Mathf.Approximately(arrayPointWalk[countPoint].position.x, transform.position.x) &&
            Mathf.Approximately(arrayPointWalk[countPoint].position.z, transform.position.z) &&
            countPoint < arrayPointWalk.Length)
        {
            agent.SetDestination(arrayPointWalk[countPoint].position);
            countPoint++;
        }
        else
        {
            if (agent.isStopped==false)
            {
                agent.SetDestination(arrayPointWalk[countPoint].position);
            }
        }
    }

    private void TrafficMove()
    {
        for (int i = 0; i < trafficStop.Length; i++)
        {
            if (transform.position.x > trafficStop[i].position.x - trafficStop[i].localScale.x / 2 &&
                transform.position.x < trafficStop[i].position.x + trafficStop[i].localScale.x / 2 &&
                transform.position.z > trafficStop[i].position.z - trafficStop[i].localScale.z / 2 &&
                transform.position.z < trafficStop[i].position.z + trafficStop[i].localScale.z / 2 &&
                trafficActive[i].activeSelf)
            {
                agent.isStopped = true;
            }
            else if(!trafficActive[i].activeSelf)
            {
                agent.isStopped = false;
            }
        }
    }
}
