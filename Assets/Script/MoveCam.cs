using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    float rotX=0,rotY=0;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        rotX += MouseX * 3;
        rotY -= MouseY* 3;

        rotY = Mathf.Clamp(rotY, -90,90);

        transform.eulerAngles = new Vector3(rotY,rotX,0);
        
        player.eulerAngles = new Vector3(0,rotX,0);
    }
}
