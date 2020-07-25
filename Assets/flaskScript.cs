using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidType
{
    public Color color;
    public string name;
}

public class flaskScript : MonoBehaviour
{
    public Transform EmitPoint;
    public GameObject particle;
    public int pourThreshold = 45;
    public Color Liquidcolor;
    public string LiquidName;
    public Renderer FlaskRenderer;
    public static List<LiquidType> ListOfLiquids = new List<LiquidType>();
    // Start is called before the first frame update
    void Start()
    {
        FlaskRenderer.materials[2].color = Liquidcolor;
        ListOfLiquids.Add(new LiquidType() { color = Liquidcolor, name = LiquidName });
    }

    // Update is called once per frame
    void Update()
    {
        if (CaculatePourAngles() <= pourThreshold)
        {
            GameObject GO = Instantiate(particle, EmitPoint.position, EmitPoint.rotation);
            GO.name = LiquidName;
            GO.GetComponent<ParticleSystemRenderer>().material.color = Liquidcolor;
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
