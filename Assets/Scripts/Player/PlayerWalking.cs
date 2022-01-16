using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerWalking : MonoBehaviour
{
    public LayerMask ClickableLayer;

    private NavMeshAgent agent;

    [SerializeField] private new Camera camera;

    [SerializeField] GameObject confirmPanel;
    private Text confirmPanelText;

    private Vector3 targetPoint = Vector3.zero;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //Обычная скорость.
        agent.speed = 75;

        confirmPanelText = confirmPanel.GetComponentInChildren<Text>();
    }

    void Update()
    {
        MovingLogic();
    }

    public void MovingLogic()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 1000, ClickableLayer))
            {
                confirmPanelText.text = "Пойти " + hitInfo.transform.GetComponent<Text>().text + " ?";
                confirmPanel.SetActive(true);
                targetPoint = hitInfo.point;
            }
        }
    }

    public void ButtonInteraction(bool isButtonYes)
    {
        if (isButtonYes)
            agent.SetDestination(targetPoint);
        confirmPanel.SetActive(false);
    }
}
