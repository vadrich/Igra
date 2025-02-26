using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditionals : MonoBehaviour
{
    public Transform squarTrance;
    public bool isMoveUp;
    public float speedMove = 3;

    private float maxHeight = 22;
    private float minHeight = -22;
    private void Update()
    {
        if(isMoveUp == true)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
       
    }
    private void MoveUp()
    {
        if (squarTrance.position.y < maxHeight)
        {
            squarTrance.position += Vector3.up * speedMove * Time.deltaTime;
        }
        else
        {
            isMoveUp = false;
        }
        
    }
    private void MoveDown()
    {
        if(squarTrance.position.y > minHeight)
        {
            squarTrance.position += Vector3.down * speedMove * Time.deltaTime;
        }
        else
        {
            isMoveUp = true;
        }
        
    }
}
