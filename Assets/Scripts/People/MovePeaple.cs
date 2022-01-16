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
        //���� ������� ������ ��� ���������� ����� 
        if (countPoint > arrayPointWalk.Length - 1)
        {
            countPoint = 0;
        }
        //��������� ������� �������� � ����� ����������
        else if (Mathf.Approximately(arrayPointWalk[countPoint].position.x, transform.position.x) &&
            Mathf.Approximately(arrayPointWalk[countPoint].position.z, transform.position.z) &&
            countPoint < arrayPointWalk.Length)
        {
            agent.SetDestination(arrayPointWalk[countPoint].position);
            countPoint++;
        }
        //���� ������� �������� �� ����� ������� �����
        else
        {
            if (countPoint<arrayPointWalk.Length)
            {
                agent.SetDestination(arrayPointWalk[countPoint].position);
            }
        }
    }
}
