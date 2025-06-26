using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTypeTest : MonoBefaviourTest
{
    private Transform tr;
    public override void StartFunction()
    {
        tr = GetComponent<Transform>();
        Debug.Log("Игра началась");
        
    }
    public override void UpdateFunction()
    {
        Debug.Log("Обновление игры");
        Move();
    }
    public void Rootate()
    {
        tr.Rotate(Vector3.forward,45);
    }
    public void Move()
    {
        Rootate();
    }
}
