using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHP : MonoBehaviour
{
    public float currentHP = 100;
    private Image HPimage;
    private void Awake()
    {
        HPimage=GetComponentInChildren<Image>();
    }
    private void OnDestroy()
    {
        
    }
    public void TakeDamage(float damage)
    {
        if (currentHP > 0)
        {
            currentHP -= damage;
            HPimage.fillAmount = currentHP / 100;
        }
        else
        {

            gameObject.SetActive(false);

        }
    }
}
