using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTimerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlatformManager.CountingDown = false;
        }
    }
}
