using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreExplosion : MonoBehaviour
{
    public GameObject intestinesA;
    public Transform intestinesARig;
    public GameObject intestinesB;
    public Transform intestinesBRig;
    public GameObject heart;
    public GameObject explodeFX;
    public Material intenstinesMaterial;
    public Material heartMaterial;

    // Use this for initialization
    void Start()
    {
        Color color = intenstinesMaterial.color;
        color.a = 1.0f; 
        intenstinesMaterial.color = color;
        heartMaterial.color = color;

        StartCoroutine("Explosion");
    }

    IEnumerator Explosion()
    {
        if (explodeFX != null)
        {
            explodeFX.SetActive(true);
        }
        
        if (intestinesA != null)
        {
            intestinesA.SetActive(true);
        }

        // Launch dymanic flesh pieces
        if (intestinesARig != null) 
        {
            intestinesARig.GetComponent<Rigidbody>().AddForce(Random.Range(0, 10), Random.Range(25, 50), Random.Range(0, 10), ForceMode.Impulse);
        }

        if (intestinesBRig != null)
        {
            intestinesBRig.GetComponent<Rigidbody>().AddForce(Random.Range(0, 10), Random.Range(50, 75), Random.Range(0, 10), ForceMode.Impulse);
        }

        if (heart != null)
        {
            heart.GetComponent<Rigidbody>().AddForce(Random.Range(0, 5), Random.Range(10, 20), Random.Range(0, 5), ForceMode.Impulse);
        }

        yield return new WaitForSeconds(20f);

        StartCoroutine("RemoveDynamicObjects");

        yield return new WaitForSeconds(0.1f);

        if (explodeFX != null)
        {
            explodeFX.SetActive(false);
        }
    }


    IEnumerator RemoveDynamicObjects()
    {
        while ((intenstinesMaterial.color.a >= 0))
        {

            Color colorA = intenstinesMaterial.color;  //The variable "color" is the renderers material color
            Color colorB = heartMaterial.color;  //The variable "color" is the renderers material color

            if (colorA.a >= 0) // If the colors alpha is greater than 0
            {
                colorA.a -= 0.05f;
                colorB.a -= 0.05f;
                intenstinesMaterial.color = colorA;  // Update the renderers material color
                heartMaterial.color = colorB;
            }

            yield return 0;
        }
    }
}

