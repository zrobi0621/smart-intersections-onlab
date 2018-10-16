using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionController4New : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    
    private IEnumerator changeLight()
    {
        while (true)
        {
            light1.GetComponent<Renderer>().material.color = Color.green;
            light2.GetComponent<Renderer>().material.color = Color.red;
            light3.GetComponent<Renderer>().material.color = Color.green;
            light4.GetComponent<Renderer>().material.color = Color.red;

            yield return new WaitForSeconds(4);
            //YELLOW SECTION1
            light1.GetComponent<Renderer>().material.color = Color.yellow;
            light3.GetComponent<Renderer>().material.color = Color.yellow;

            yield return new WaitForSeconds(2);
            light1.GetComponent<Renderer>().material.color = Color.red;
            light2.GetComponent<Renderer>().material.color = Color.green;
            light3.GetComponent<Renderer>().material.color = Color.red;
            light4.GetComponent<Renderer>().material.color = Color.green;

            yield return new WaitForSeconds(4);

            //YELLOW SECTION2
            light2.GetComponent<Renderer>().material.color = Color.yellow;
            light4.GetComponent<Renderer>().material.color = Color.yellow;

            yield return new WaitForSeconds(2);
        }
    }

    void Start()
    {
        StartCoroutine(changeLight());
    }
}
