using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerScript : MonoBehaviour
{
    [Range(0, 1)]
    public float waterPercent;
    public Transform Liquid;
    public float fullValue;
    public float emptyValue;
    public float fillRate;
    public float drainRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calculate the water level
        float val = ((fullValue - emptyValue) * waterPercent) + emptyValue;
        //apply it
        Liquid.localScale = new Vector3(Liquid.localScale.x, Liquid.localScale.y, val);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (waterPercent <= 1 && waterPercent >= 0)
        {
            waterPercent = waterPercent + fillRate;
        }
    }
}
