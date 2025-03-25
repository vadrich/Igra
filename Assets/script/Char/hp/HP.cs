using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public float currentHP = 100;
    private Image HPimage;
    void Awake()
    {
        HPimage = GetComponentInChildren<Image>();
    }
    private void OnEnable()
    {
        currentHP = 100;
        HPimage.fillAmount = currentHP / 100;
        Time.timeScale = 1;
    }
    private void OnDisable()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        if (currentHP > 0)
        {
            currentHP -= damage;
            HPimage.fillAmount = currentHP/100;
        }
        else
        {
            Debug.Log("Game Over");
            gameObject.SetActive(false);
            
        }
    }
}
