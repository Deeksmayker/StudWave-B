using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePeaple : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform[] arrayPointWalk;
    int countPoint=0;
    void Update()
    {
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
        //Если позиция человека не равна позиции точки
        else
        {
            if (countPoint<arrayPointWalk.Length)
            {
                agent.SetDestination(arrayPointWalk[countPoint].position);
            }
        }
    }
}
