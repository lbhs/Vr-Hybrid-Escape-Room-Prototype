using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabber : MonoBehaviour
{
    private GameObject objectHeld;
    private Vector3 offset;
    private Quaternion qOffset;
    public bool isLeft;
    public GameObject fakeChild;
    private void LateUpdate()
    {
        //left
        if (objectHeld != null && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && isLeft)
        {
            fakeChild.transform.position = objectHeld.transform.position;
            fakeChild.transform.rotation = objectHeld.transform.rotation;
            objectHeld.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (objectHeld != null && OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger) && isLeft)
        {
            objectHeld.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (objectHeld != null&&OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)&& isLeft)
        {
            objectHeld.GetComponent<Rigidbody>().MovePosition(fakeChild.transform.position);
            objectHeld.GetComponent<Rigidbody>().MoveRotation(fakeChild.transform.rotation);
        }
        //right
        if (objectHeld != null && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) && !isLeft)
        {
            fakeChild.transform.position = objectHeld.transform.position;
            fakeChild.transform.rotation = objectHeld.transform.rotation;
            objectHeld.GetComponent<Rigidbody>().isKinematic = true;
        }
        if (objectHeld != null && OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && !isLeft)
        {
            objectHeld.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (objectHeld != null && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !isLeft)
        {
            objectHeld.GetComponent<Rigidbody>().MovePosition(fakeChild.transform.position);
            objectHeld.GetComponent<Rigidbody>().MoveRotation(fakeChild.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CanBeGrabed>() != null)
        {
            objectHeld = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectHeld)
        {
            objectHeld = null;
        }
    }
}
