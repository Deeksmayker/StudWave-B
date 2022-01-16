using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityRegulatorCar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] carActive;
    bool inputRegulator = true;
    void Update()
    {
        if (carActive[carActive.Length-1].activeSelf==false && inputRegulator==true)
        {
            StartCoroutine(CarActivator());
        }
    }
    IEnumerator CarActivator()
    {
        inputRegulator = false;
        for (int i = 0; i < carActive.Length; i++)
        {
            Debug.Log("1");
            yield return new WaitForSeconds(3f);
            carActive[i].SetActive(true);
        }
        inputRegulator = true;
    }
}
