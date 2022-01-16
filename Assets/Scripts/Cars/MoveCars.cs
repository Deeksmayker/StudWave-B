using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCars : MonoBehaviour
{
    private float progress;
    public float speed;
    float saveSpeed;
    int cointStart = 0;
    int countFinal = 1;
    public bool rotate;
    public int distanceX;
    public int distanceZ;
    public Transform[] point;
    public Transform[] trafficStop;
    public GameObject[] trafficActive;
    public Transform distanceCar;
    public GameObject distanceCarActive;

    private void Start()
    {
        saveSpeed = speed;
    }
    private void Update()
    {
        if (transform.position != point[point.Length-1].position && gameObject.activeSelf)
        {
            TrafficCar();
        }

        if (transform.position == point[point.Length-1].position)
        {
            gameObject.SetActive(false);
            transform.position = point[0].position;
            cointStart = 0;
            countFinal = 1;
            progress = 0;
            if (rotate == true)
            {
                transform.Rotate(Vector3.up,(-90f));
            }
        }
    }

    private void TrafficCar()
    {
        bool carMovement = true;
        for (int i = 0; i < trafficStop.Length; i++)
        {
            if (ComparisonCarPandTrafficLightP(i))
            {
                carMovement = false;
            }
        }

        carMovement = KeepingDistance(carMovement);

        if (carMovement == true)
        {
            CarMovement();
        }
    }
    private bool ComparisonCarPandTrafficLightP(int i)
    {
        return transform.position.x > trafficStop[i].position.x - trafficStop[i].localScale.x / 2 &&
                        transform.position.x < trafficStop[i].position.x + trafficStop[i].localScale.x / 2 &&
                        transform.position.z > trafficStop[i].position.z - trafficStop[i].localScale.z / 2 &&
                        transform.position.z < trafficStop[i].position.z + trafficStop[i].localScale.z / 2 &&
                        trafficActive[i].activeSelf;
    }

    private bool KeepingDistance(bool carMovement)
    {
        if (ComparisonCarPositions())
        {
            carMovement = false;
        }

        return carMovement;
    }

    private bool ComparisonCarPositions()
    {
        return transform.position.x > distanceCar.position.x - distanceCar.localScale.x * distanceX &&
                transform.position.x < distanceCar.position.x + distanceCar.localScale.x * distanceX &&
                transform.position.z > distanceCar.position.z - distanceCar.localScale.z * distanceZ     &&
                transform.position.z < distanceCar.position.z + distanceCar.localScale.z * distanceZ && distanceCarActive.activeSelf;
    }

    private void CarMovement()
    {
        if (transform.position == point[countFinal].position)
        {
            cointStart++;
            countFinal++;
            progress = 0;
        }
        if (transform.position == point[1].position)
        {
            transform.Rotate(Vector3.up, 22.5f);
            speed = 0.03f;
        }
        if (point.Length>=4)
        {
            if (transform.position == point[2].position)
            {
                transform.Rotate(Vector3.up, 10f);
            }
            if (transform.position == point[3].position)
            {
                transform.Rotate(Vector3.up, 12.5f);
                speed = saveSpeed;
            }
        }
        transform.position = Vector3.Lerp(point[cointStart].position, point[countFinal].position, progress);
        progress += speed;
    }
}
