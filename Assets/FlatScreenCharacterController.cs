using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlatScreenCharacterController : MonoBehaviour
{
    public CharacterController CC;
    public float speed = 6f;
    public float objectRotateSpeed = 100;
    public float gravity = -9.81f;
    public Camera myCamera;
    [Header("A child of the camera")] //used to calculate the position of the held gameobject without parenting the held gameobject
    public GameObject fakeChild;

    private Transform CurrentSlectedObject;
    private Transform CurrentHeldObject;
    private Vector3 velocityStore; //velocity from the last frame

    void Update()
    {
        ///----------------------------player movement-----------------   https://youtu.be/_QajrabyTJc?t=889
        //doesn't accelerate if the player is on the ground
        if (CC.isGrounded && velocityStore.y < 0)
        {
            velocityStore.y = -2; //makes sure the player stick to the ground just in case
        }

        //gets wasd input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //make a vector based on the rotation of the character
        Vector3 move = transform.right * x + transform.forward * z;
        
        //Actually moves player
        CC.Move(move * speed * Time.deltaTime);

       

        //Apply Gravity
        velocityStore.y += gravity * Time.deltaTime;
        CC.Move(velocityStore * Time.deltaTime);


        ///-------------------picking up objects-------------------------
        //RayCast to detect what were looking at
        //old: Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(myCamera.transform.position, myCamera.transform.forward);
        RaycastHit hit;
        //int layer_mask = LayerMask.GetMask("CanInteract");
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.transform.gameObject.layer == 8) //Layer #8 = CanInteract
            {
                //draw invisible ray cast/vector
                Debug.DrawLine(ray.origin, hit.point);
                CurrentSlectedObject = hit.transform;
            }
        }
        else
        {
            CurrentSlectedObject = null;
        }

        // UI detection
        int layer_mask2 = LayerMask.GetMask("UIButton");
        if (Physics.Raycast(ray, out hit, 2f, layer_mask2))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                hit.transform.GetComponent<Button>().onClick.Invoke();
            }
        }

        //Input detecting
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Grab();
        }
        if (Input.GetMouseButtonUp(0))
        {
            UnGrab();
        }

        //move the object if grabbed
        if(CurrentHeldObject != null)
        {
            //if (CurrentHeldObject.GetComponent<CanBeGrabed>() != null)
            if(CurrentHeldObject.tag == "Interactable")
            {
                //fakeChild.transform.Rotate(new Vector3(-Input.GetAxisRaw("Vertical2"), 0,-Input.GetAxisRaw("Horosontial2"))*objectRotateSpeed*Time.deltaTime);
                fakeChild.transform.RotateAround(fakeChild.transform.position,transform.up, -Input.GetAxis("Horosontial2") *objectRotateSpeed * Time.deltaTime);
                fakeChild.transform.RotateAround(fakeChild.transform.position, transform.right, Input.GetAxis("Vertical2") * objectRotateSpeed * Time.deltaTime);
                CurrentHeldObject.GetComponent<Rigidbody>().MovePosition(fakeChild.transform.position);
                CurrentHeldObject.GetComponent<Rigidbody>().MoveRotation(fakeChild.transform.rotation);
            }
        }
    }

    void Grab()
    {
        if (CurrentSlectedObject != null)
        {
            //if (CurrentSlectedObject.GetComponent<CanBeGrabed>() != null)
            if (CurrentSlectedObject.tag == "Interactable")
            {
                fakeChild.transform.position = CurrentSlectedObject.transform.position;
                fakeChild.transform.rotation = CurrentSlectedObject.transform.rotation;
                CurrentHeldObject = CurrentSlectedObject;
                CurrentHeldObject.GetComponent<Rigidbody>().isKinematic = true; //disable physic so it doesn't fight with this script
            }
        }
    }

    void UnGrab()
    {
        if (CurrentHeldObject != null)
        {
            if (CurrentHeldObject.GetComponent<Rigidbody>() != null)
            {
                CurrentHeldObject.GetComponent<Rigidbody>().isKinematic = false; //re-enabled physics
            }
            CurrentHeldObject = null;
        }
    }
}
