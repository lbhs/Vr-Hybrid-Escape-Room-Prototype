using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //determines what character controller to spawn
    public static bool isVR = false;
    //Different Controllers for different platforms
    public GameObject VRController;
    public GameObject FlatScreenController;
    //Event systems are how unity transfers mouse or vr input into things like buttons
    public GameObject FlatEventSystem;
    public GameObject VREventSystem;
    //universal reference to the player;
    public static GameObject player;


    void Start() 
    {
        //Spawns the right controller
        if (isVR == true)
        {
            GameObject Player = Instantiate(VRController, Vector3.up, Quaternion.identity);
            player = Player;
        }
        else
        {
            GameObject Player = Instantiate(FlatScreenController, Vector3.up, Quaternion.identity);
            player = Player;
        }
    }
}
