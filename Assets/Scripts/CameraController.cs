using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [SerializeField] Transform[] povs;
    [SerializeField] float speed;

    private int index = 1;
    private Vector3 target;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha1)) index = 0;
        else if(Input.GetKeyDown(KeyCode.Alpha2)) index = 1;
        else if(Input.GetKeyDown(KeyCode.Alpha3)) index = 2;
        else if(Input.GetKeyDown(KeyCode.Alpha4)) index = 3;
        else if(Input.GetKeyDown(KeyCode.Alpha5)) index = 4;

        target = povs[index].position;
    }

    private void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
        transform.forward = Vector3.Lerp(transform.forward, povs[index].forward, Time.deltaTime * speed);

    }
}
