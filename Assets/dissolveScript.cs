using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolveScript : MonoBehaviour
{
    public MeshRenderer MR;
    public float interval;
    private Color initalColor;
    private void Start()
    {
        initalColor = MR.material.color;
    }
    private void OnParticleCollision(GameObject other)
    {
            Color c = MR.material.color;
            c.a -= interval;
            MR.material.color = c;
    }
}
