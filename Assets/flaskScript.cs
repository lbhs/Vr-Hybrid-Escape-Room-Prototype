using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaskScript : MonoBehaviour
{
    public Transform EmitPoint;
    public GameObject particle;
    public int pourThreshold = 45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CaculatePourAngles() <= pourThreshold)
        {
            Instantiate(particle, EmitPoint.position, EmitPoint.rotation);
        }
        else
        {
            
        }
    }

    float CaculatePourAngles()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }
}
