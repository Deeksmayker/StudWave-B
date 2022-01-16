using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcealmentStudent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject student;
    [SerializeField] Transform uniPoint;
    [SerializeField] Transform homePoint;
    bool activeStudent=true;
    // Update is called once per frame
    void Update()
    {
        DisappearingFromScene();
    }

    private void DisappearingFromScene()
    {
        //Сравнение позиции студента и универа
        if (Mathf.Approximately(uniPoint.position.x, transform.position.x) &&
            Mathf.Approximately(uniPoint.position.z, transform.position.z) && activeStudent == true)
        {
            activeStudent = false;
            student.SetActive(false);
        }
        //Сравнение позиции студента и дома
        if (Mathf.Approximately(homePoint.position.x, transform.position.x) &&
            Mathf.Approximately(homePoint.position.z, transform.position.z) && activeStudent == false)
        {
            activeStudent = true;
            student.SetActive(false);
        }
    }
}
