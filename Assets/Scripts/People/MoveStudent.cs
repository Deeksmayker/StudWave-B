using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public static class MovementStudents
{
    public static string GotoUni
    {
        get => "GotoUni";
    }
    public static string GotoHome
    {
        get => "GotoHome";
    }
    public static string Stopping
    {
        get => "Stopping";
    }
}
public class MoveStudent : MonoBehaviour
{
    [SerializeField] NavMeshAgent[] arrayAgent;
    [SerializeField] Transform uniPoint;
    [SerializeField] Transform homePoint;
    public GameObject[] students; 
    bool flagStopping=true;
    bool classTime;
    int countStudent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComparedPositionUni();
        ComparedPositionHome();
        ComparedPosLastStudentAndDest();
    }

    private void ComparedPosLastStudentAndDest()
    {
        //Сравнение позиции последнего студента и точки назначения
        if ((Mathf.Approximately(homePoint.position.x, students[students.Length - 1].transform.position.x) &&
            Mathf.Approximately(homePoint.position.z, students[students.Length - 1].transform.position.z) ||
            Mathf.Approximately(uniPoint.position.x, students[students.Length - 1].transform.position.x) &&
            Mathf.Approximately(uniPoint.position.z, students[students.Length - 1].transform.position.z)) && classTime == true)
        {
            classTime = false;
            Invoke(MovementStudents.Stopping, 10);
        }
    }

    private void ComparedPositionHome()
    {
        //сравнение позиции каждого студента с позицией дома
        if (Mathf.Approximately(homePoint.position.x, students[countStudent].transform.position.x) &&
            Mathf.Approximately(homePoint.position.z, students[countStudent].transform.position.z) && 
            flagStopping == true)
        {
            flagStopping = false;
            Invoke(MovementStudents.GotoUni, 3);
        }
    }

    private void ComparedPositionUni()
    {
        //сравнение позиции каждого студента с позицией дома
        if (Mathf.Approximately(uniPoint.position.x, students[countStudent].transform.position.x) &&
            Mathf.Approximately(uniPoint.position.z, students[countStudent].transform.position.z) &&
            flagStopping == true)
        {
            flagStopping = false;
            Invoke(MovementStudents.GotoHome, 3);
        }
    }

    void GotoHome()
    {
        students[countStudent].SetActive(true);
        arrayAgent[countStudent].SetDestination(homePoint.position);
        if (countStudent >= students.Length - 1)
        {
            countStudent = 0;
            classTime = true;
        }
        else
        {
            flagStopping = true;
            countStudent++;
        }
    }
    void GotoUni()
    {
        students[countStudent].SetActive(true);
        arrayAgent[countStudent].SetDestination(uniPoint.position);
        if (countStudent >= students.Length-1)
        {
            classTime = true;
            countStudent = 0;
        }
        else
        {
            flagStopping = true;
            countStudent++;
        }
    }
    void Stopping()
    {
        flagStopping = true;
    }
}
