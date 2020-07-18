using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeGrabed : MonoBehaviour
{
    private Vector3 offset;
    private GameObject objectHeld;
    private void Update()
    {
        if (objectHeld != null)
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && objectHeld.tag == "LHand")
            {
                print("LDown");
                offset = objectHeld.transform.position - transform.position;
            }
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && objectHeld.tag == "LHand")
            {

                print("L");
                transform.position = objectHeld.transform.position + offset;
            }
            //if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) && other.tag == "")
            //{

            //}

            //right
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) && objectHeld.tag == "RHand")
            {
                print("RDown");
                offset = objectHeld.transform.position - transform.position;
            }
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && objectHeld.tag == "RHand")
            {
                print("R");
                transform.position = objectHeld.transform.position + offset;
            }
            //if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && other.tag == "")
            //{

            //}
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        objectHeld = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        objectHeld = null;
    }
}
