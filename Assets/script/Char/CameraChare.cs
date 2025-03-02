using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChare : MonoBehaviour
{
    private Transform trCam;
    public Transform trChar;
    // Start is called before the first frame update
    void Start()
    {
        trCam = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        trCam.position = trChar.position;
        float x = trCam.position.x;
        float y = trCam.position.y;
        float z = -10;
        trCam.position = new Vector3(x, y, z);
    }
}
