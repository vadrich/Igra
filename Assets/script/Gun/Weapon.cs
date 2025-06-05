using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject prefabBullet;
    public Transform startTR;
    public ParticleSystem firePart;
    public void Update()
    {
        Shooting();
    }
    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(prefabBullet,startTR.position,startTR.rotation);
            newBullet.transform.right = startTR.right;
            firePart.Play();
        }
    }
}
