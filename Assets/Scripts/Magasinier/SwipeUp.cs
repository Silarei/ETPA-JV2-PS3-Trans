using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeUp : MonoBehaviour
{

    public Transform CheckList;
    public Transform checkListPosition;
    public Transform checkListIdlePosition;
    public bool isCheckListUp;


    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Vector2 checkListOriginPosition;
    public float currentTime;
    private float lastTimeMoved;
    private float waitTime;

    void Start()
    {
        checkListOriginPosition = CheckList.transform.position;
        currentTime = 0f;
        lastTimeMoved = 0f;
        waitTime = 1f;
    }

    void Update()
    {
        
        Debug.Log(currentTime);
        if (CheckList.transform.position != checkListPosition.transform.position && isCheckListUp)
        {
            CheckListUp();
        }

        else if (!isCheckListUp)
        {
            CheckListDown();
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.y > startTouchPosition.y)
            {

                isCheckListUp = true;

            }

            else if (endTouchPosition.y < startTouchPosition.y)
            {

                isCheckListUp = false;
            }
        }

    }

    private void CheckListUp()
    {
        currentTime = 0;
        lastTimeMoved = 0;
        CheckList.transform.position = Vector2.Lerp(CheckList.transform.position, checkListPosition.transform.position,0.2f);
    }

    private void CheckListDown()
    {
        currentTime += Time.deltaTime;
        if (currentTime - lastTimeMoved > waitTime *3.4)
        {
            lastTimeMoved = currentTime;
        }

        else if (currentTime - lastTimeMoved > waitTime *3)
        {
            CheckList.transform.position = Vector2.Lerp(CheckList.transform.position, checkListIdlePosition.position, 0.1f);
        }
        else
        {
            CheckList.transform.position = Vector2.Lerp(CheckList.transform.position, checkListOriginPosition, 0.05f);
        }
        
    }

}
