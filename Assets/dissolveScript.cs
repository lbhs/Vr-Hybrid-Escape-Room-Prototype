using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolveScript : MonoBehaviour
{
    //public MeshRenderer MR;
    public float interval;
    //private Color initalColor;
    private void Start()
    {
        //initalColor = MR.material.color;
    }
    private void OnParticleCollision(GameObject other)
    {
        transform.position -= new Vector3(0,interval,0);
        //Color c = MR.material.color;
        //c.a -= interval;
        // MR.material.color = c;
    }
    //public meshrenderer mr;
    //public float interval;
    //private color initalcolor;
    //private void start()
    //{
    //    initalcolor = mr.material.color;
    //}
    //private void onparticlecollision(gameobject other)
    //{
    //    color c = mr.material.color;
    //    c.a -= interval;
    //    mr.material.color = c;
    //}
}
