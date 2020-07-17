using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButtonInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10) //10 is UIButton
        {
            other.gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
