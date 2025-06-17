using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetComponentTest : MonoBehaviour
{
    public Image ImageSquar;
    private float number;

    private void Awake()
    {
        //ImageSquar = GetComponentInChildren<Image>();
        //ImageSquar = transform.GetChild(2).GetComponent<Image>();
        ImageSquar = GetComponent<Image>();
    }

    private void Start()
    {
        ImageSquar.color = Color.yellow;
    }
}
