using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MagicLightSource : MonoBehaviour
{
    public List<Material> materials;
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Material m in materials)
        {
            m.SetVector("_LightPosition", light.transform.position);
            m.SetVector("_LightDirection", -light.transform.forward);
            m.SetFloat("_LightAngle", light.spotAngle);
        }
        /*
        materials.ForEach()
        reveal.SetVector("_LightPosition", light.transform.position);
        reveal.SetVector("_LightDirection", -light.transform.forward);
        reveal.SetFloat("_LightAngle", light.spotAngle);
        */
    }
}
