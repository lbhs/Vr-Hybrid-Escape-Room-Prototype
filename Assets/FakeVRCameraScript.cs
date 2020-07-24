using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeVRCameraScript : MonoBehaviour
{
    public Transform WebGLCamera;
    public Transform StandAloneCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        transform.position = StandAloneCamera.position;
        transform.eulerAngles = new Vector3(0, StandAloneCamera.eulerAngles.y, 0);
#elif UNITY_WEBGL
        transform.position = WebGLCamera.position;
        transform.eulerAngles = new Vector3(0, WebGLCamera.eulerAngles.y, 0);
#else
        transform.position = StandAloneCamera.position;
        transform.eulerAngles = new Vector3(0, StandAloneCamera.eulerAngles.y, 0);
#endif
    }
}
