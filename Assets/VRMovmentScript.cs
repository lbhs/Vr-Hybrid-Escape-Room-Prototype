using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class VRMovmentScript : MonoBehaviour  // TO-DO: add rotation from joystick
{
    public CharacterController CC;
    private Vector3 velocityStore; //velocity from the last frame
    public float speed = 6f;
    public float gravity = -9.81f;
    public GameObject MainCamera;
    public Transform FakeCamera;
    public WebXRController Left;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (CC.isGrounded && velocityStore.y < 0)
        {
            velocityStore.y = -2; //makes sure the player stick to the ground just in case
        }

        //gets wasd input
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        float x = Left.GetAxis("VRH");
        float z = Left.GetAxis("VRV");
        //make a vector based on the rotation of the character
        //FakeCamera.position = MainCamera.transform.position;
        //FakeCamera.eulerAngles = new Vector3(0, MainCamera.transform.eulerAngles.y, 0);
        Vector3 move = FakeCamera.right * x + FakeCamera.forward * z;

        //Actually moves player
        CC.Move(move * speed * Time.deltaTime);
      


        //Apply Gravity
        velocityStore.y += gravity * Time.deltaTime;
        CC.Move(velocityStore * Time.deltaTime);
    }
}
