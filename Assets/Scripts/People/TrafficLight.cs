using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] stopTrafficsPeople;
    public GameObject[] stopTrafficsCarX;
    public GameObject[] stopTrafficsCarZ;
    public float timeWalkPeople;
    public float timeTrafficCarX;
    public float timeTrafficCarZ;
    bool entranceTraffic=true;
    // Update is called once per frame
    void Update()
    {
        if (entranceTraffic==true)
        {
            StartCoroutine(Traffic());
        }
    }
    IEnumerator Traffic()
    {
        entranceTraffic = false;
        for (int i = 0; i < stopTrafficsPeople.Length; i++)
        {
            stopTrafficsPeople[i].SetActive(true);
        }
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < stopTrafficsCarX.Length; i++)
        {
            stopTrafficsCarX[i].SetActive(false);
        }

        yield return new WaitForSeconds(timeTrafficCarX);

        for (int i = 0; i < stopTrafficsCarX.Length; i++)
        {
            stopTrafficsCarX[i].SetActive(true);
        }

        yield return new WaitForSeconds(5f);

        for (int i = 0; i < stopTrafficsCarZ.Length; i++)
        {
            stopTrafficsCarZ[i].SetActive(false);
        }

        yield return new WaitForSeconds(timeTrafficCarZ);

        for (int i = 0; i < stopTrafficsCarZ.Length; i++)
        {
            stopTrafficsCarZ[i].SetActive(true);
        }

        yield return new WaitForSeconds(5f);

        for (int i = 0; i < stopTrafficsPeople.Length; i++)
        {
            stopTrafficsPeople[i].SetActive(false);
        }
        yield return new WaitForSeconds(timeWalkPeople);
        entranceTraffic = true;
    }
}
