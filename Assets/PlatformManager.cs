using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //determines what character controller to spawn
    public static bool isVR = false;
    public GameObject VRController;
    public GameObject FlatScreenController;


    void Start() 
    {
        //Spawns the right controller
        if (isVR == true)
        {
            Instantiate(VRController, Vector3.up, Quaternion.identity);
        }
        else
        {
            Instantiate(FlatScreenController, Vector3.up, Quaternion.identity);
        }
    }
}
