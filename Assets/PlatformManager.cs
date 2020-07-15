using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //determines what character controller to spawn
    public static bool isVR = false;
    public GameObject VRController;
    public GameObject FlatScreenController;
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
