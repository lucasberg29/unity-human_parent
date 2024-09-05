using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    private bool isDoingSomething = false;
    private bool isInDestiny = false;
    private bool isPatroling = false;

    private Animator humanAnimator;
    private Transform currentDestiny;

    public Transform imGoodDialog;

    List<Transform> wayPointsStack = new();

    public float humanSpeed;
    public Transform[] wayPoints;

    // Start is called before the first frame update
    void Start()
    {
        FillWayPoints();

        Debug.Log(currentDestiny);
        humanAnimator = GetComponent<Animator>();  
        DoSomething();
    }

    void FillWayPoints()
    {
        foreach (var transform in wayPoints)
        {
            wayPointsStack.Add(transform);
        }

        currentDestiny = wayPointsStack.First();
    }

    private void DoSomething()
    {
        isMovingRight = false;
        isMovingLeft = false;   
        isDoingSomething = true;
        isInDestiny = false;
        humanAnimator.SetBool("IsMoving", true);
        MoveToWaypoint(currentDestiny);
    }

    private void MoveToWaypoint(Transform destiny)
    {
        float xDistance = destiny.position.x - transform.position.x;
        Debug.Log(xDistance);

        //if (Mathf.Abs(xDistance) < 0.5f)
        //{
        //    isDoingSomething = false;
        //    isInDestiny = true;
        //    wayPointsStack.Remove(currentDestiny);
        //    currentDestiny = wayPointsStack.First();
        //    isMovingLeft = false;
        //    isMovingRight = false;
        //}
        if (xDistance > 0)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
            imGoodDialog.localScale = new Vector3(Mathf.Abs(imGoodDialog.localScale.x), imGoodDialog.localScale.y, 1);
            humanAnimator.SetBool("IsMoving", true);
            isMovingLeft = false ;
            isMovingRight = true;
            Debug.Log("Is moving right");
        }
        else if (xDistance < 0)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1.0f, transform.localScale.y, 1);
            imGoodDialog.localScale = new Vector3(Mathf.Abs(imGoodDialog.localScale.x) * -1.0f, imGoodDialog.localScale.y, 1);
            humanAnimator.SetBool("IsMoving", true);
            isMovingLeft = true;
            isMovingRight = false;
            Debug.Log("Is moving left");
        }
    }

    void Update()
    {
        if (!isDoingSomething)
        {
            //currentDestiny = wayPointsStack.Pop();
            DoSomething();
        }
        //DoSomething();
        //MoveToWaypoint(currentDestiny);

        if (isInDestiny)
        {
            humanAnimator.SetBool("IsMoving", false);
            isMovingLeft = false;
            isMovingRight = false;
            Debug.Log("Is in destiny");
        }

        float xDistance = currentDestiny.position.x - transform.position.x;

        if (Mathf.Abs(xDistance) < 0.5f)
        {
            isDoingSomething = false;
            isInDestiny = true;
            wayPointsStack.Remove(currentDestiny);

            if (wayPointsStack.Count == 0 )
            {
                FillWayPoints();
            }
            else
            {
                currentDestiny = wayPointsStack.First();
            }

            isMovingLeft = false;
            isMovingRight = false;
            //DoSomething();
        }
    }

    private void FixedUpdate()
    {
        if (isMovingLeft)
        {
            gameObject.transform.position += Vector3.left * humanSpeed;
        }
        else if (isMovingRight)
        {
            gameObject.transform.position += Vector3.right * humanSpeed;
        }
    }
}
