using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatScreenCharacterController : MonoBehaviour
{
    public CharacterController CC;
    public float speed = 6f;
    public Camera myCamera;
    private Transform CurrentSlectedObject;
    private Transform CurrentHeldObject;
    //private Vector3 offset;
    public GameObject fakeChild;
    // Update is called once per frame
    void Update()
    {
        //gets wasd input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //make a vector based on the rotation of the character
        Vector3 move = transform.right * x + transform.forward * z;

        //To add gravity: https://youtu.be/_QajrabyTJc?t=889
        //Actually moves player
        CC.Move(move * speed * Time.deltaTime);

        //RayCast
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layer_mask = LayerMask.GetMask("CanInteract");
        if (Physics.Raycast(ray, out hit, 5f, layer_mask))
        {
            //draw invisible ray cast/vector
            Debug.DrawLine(ray.origin, hit.point);
            CurrentSlectedObject = hit.transform;
        }
        else
        {
            CurrentSlectedObject = null;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Grab();
        }
        if (Input.GetMouseButtonUp(0))
        {
            UnGrab();
        }

        if(CurrentHeldObject != null)
        {
            CurrentHeldObject.GetComponent<Rigidbody>().MovePosition( fakeChild.transform.position);
            CurrentHeldObject.GetComponent<Rigidbody>().MoveRotation(fakeChild.transform.rotation);
            //CurrentHeldObject.transform.position = myCamera.transform.TransformPoint(transform.localPosition);
        }
        //RayCast to grab objects
        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layer_mask = LayerMask.GetMask("CanInteract");
            if (Physics.Raycast(ray, out hit, 5f, layer_mask))
            {
                //draw invisible ray cast/vector
                Debug.DrawLine(ray.origin, hit.point);
                CurrentSlectedObject = hit.transform;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(CurrentSlectedObject != null)
            {
                if (CurrentSlectedObject.GetComponent<OVRGrabbable>() != null)
                {
                    CurrentHeldObject = CurrentSlectedObject;
                    offset = myCamera.transform.position - CurrentHeldObject.position;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CurrentHeldObject.parent = null;
            CurrentHeldObject.GetComponent<Rigidbody>().isKinematic = false;
            CurrentHeldObject = null;
            CurrentSlectedObject = null;
        }

        if(CurrentHeldObject != null)
        {
            CurrentHeldObject.GetComponent<Rigidbody>().isKinematic = true;
            CurrentHeldObject.parent = myCamera.transform;
        }*/
    }

    void Grab()
    {
        if (CurrentSlectedObject != null)
        {
            if (CurrentSlectedObject.GetComponent<OVRGrabbable>() != null)
            {

                fakeChild.transform.position = CurrentSlectedObject.transform.position;
                fakeChild.transform.rotation = CurrentSlectedObject.transform.rotation;
                CurrentHeldObject = CurrentSlectedObject;
                CurrentHeldObject.GetComponent<Rigidbody>().useGravity = false;
                //offset = CurrentHeldObject.position - myCamera.transform.position;
            }
        }
    }
    void UnGrab()
    {
        CurrentHeldObject.GetComponent<Rigidbody>().useGravity = true;
        CurrentHeldObject = null;
    }

}
