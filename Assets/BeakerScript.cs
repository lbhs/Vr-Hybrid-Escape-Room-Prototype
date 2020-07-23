using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerScript : MonoBehaviour //to-do: mix colors??
{
    [Range(0, 1)]
    public float waterPercent;
    public Transform Liquid;
    public float fullValue=0.85f;
    public float emptyValue=0.03f;
    public float fillRate=0.001f;
    public float drainRate=0.001f;

    public Transform[] EmitPoints;
    private Transform EmitPoint;
    public GameObject particle;
    public int pourThreshold = 45;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waterPercent < 0)
        {
            waterPercent = 0;
        }
        else if(waterPercent >1)
        {
            waterPercent = 1;
        }
        //find the lowest emit point
        foreach (var item in EmitPoints)
        {
            if (EmitPoint != null)
            {
                if (item.transform.position.y < EmitPoint.transform.position.y)
                {
                    EmitPoint = item;
                }
            }
            else
            {
                EmitPoint = EmitPoints[0];
            }
        }
        //calculate the water level
        float val = ((fullValue - emptyValue) * waterPercent) + emptyValue;
        //apply it
        Liquid.localScale = new Vector3(Liquid.localScale.x, Liquid.localScale.y, val);

        //spilling
        if (CaculatePourAngles() <= pourThreshold)
        {
            if (waterPercent > 0 && waterPercent <= 1)
            {
                Instantiate(particle, EmitPoint.position, EmitPoint.rotation);
                waterPercent = waterPercent - fillRate;
            }
        }
        else
        {

        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (waterPercent <= 1 && waterPercent >= 0 )
        {
            waterPercent = waterPercent + fillRate;
            //addColor
        }
    }

    float CaculatePourAngles()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }
}
