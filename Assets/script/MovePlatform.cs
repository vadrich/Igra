using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform transPlatform;
    private float rightPoint = 40;
    private float leftPoint = -40;
    public float speedMove = 15;
    public bool isMoveLeft = false;

    private void Update()
    {
        if (isMoveLeft == false)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }
    private void MoveLeft()
    {
        if (transPlatform.position.x > leftPoint)
        {
            transPlatform.position += Vector3.left * speedMove * Time.deltaTime;
        }
        else
        {
            isMoveLeft = false;
        }
    }
    private void MoveRight()
    {
        if (transPlatform.position.x < rightPoint)
        {
            transPlatform.position += Vector3.right * speedMove * Time.deltaTime;
        }
        else
        {
            isMoveLeft = true;
        }
    }
}
