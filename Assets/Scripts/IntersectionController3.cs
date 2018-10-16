using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionController3 : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;

    private IEnumerator changeLight3()
    {
        while (true)
        {
            light1.GetComponent<Renderer>().material.color = Color.red;
            light2.GetComponent<Renderer>().material.color = Color.green;
            light3.GetComponent<Renderer>().material.color = Color.green;

            yield return new WaitForSeconds(4);

            //YELLOW SECTION1
            light2.GetComponent<Renderer>().material.color = Color.yellow;
            light3.GetComponent<Renderer>().material.color = Color.yellow;

            yield return new WaitForSeconds(2);

            light1.GetComponent<Renderer>().material.color = Color.green;
            light2.GetComponent<Renderer>().material.color = Color.red;
            light3.GetComponent<Renderer>().material.color = Color.red;

            yield return new WaitForSeconds(4);

            //YELLOW SECTION2
            
            light1.GetComponent<Renderer>().material.color = Color.yellow;;

            yield return new WaitForSeconds(2);
        }
    }

    void Start()
    {
        StartCoroutine(changeLight3());
    }
}
