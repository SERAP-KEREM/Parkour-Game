using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CameraManager : MonoBehaviour
{
    public Transform target;

    public float cameraSpeed;
    private Thread T1;
    // Start is called before the first frame update
    void Start()
    {
        ThreadMethod();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position,new Vector3(target.position.x, target.position.y, target.position.z-5), cameraSpeed);
    }
    void ThreadMethod ()
    {
        Thread.Sleep(3000);

    }
}
