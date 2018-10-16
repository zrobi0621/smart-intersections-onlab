using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionController : MonoBehaviour
{
    public GameObject tl1red;
    public GameObject tl1green;
    public GameObject tl1yellow;
    public GameObject tl2red;
    public GameObject tl2green;
    public GameObject tl2yellow;
    public GameObject tl3red;
    public GameObject tl3green;
    public GameObject tl3yellow;
    public GameObject tl4red;
    public GameObject tl4green;
    public GameObject tl4yellow;

    private IEnumerator changeLight()
    {
        while (true)
        {
            tl1yellow.SetActive(false);
            tl2yellow.SetActive(false);
            tl3yellow.SetActive(false);
            tl4yellow.SetActive(false);

            tl1red.SetActive(true);
            tl2red.SetActive(false);
            tl3red.SetActive(true);
            tl4red.SetActive(false);

            tl1green.SetActive(false);
            tl2green.SetActive(true);
            tl3green.SetActive(false);
            tl4green.SetActive(true);

            yield return new WaitForSeconds(4);
            //YELLOW SECTION1
            tl2green.SetActive(false);
            tl4green.SetActive(false);

            tl1yellow.SetActive(false);
            tl2yellow.SetActive(true);
            tl3yellow.SetActive(false);
            tl4yellow.SetActive(true);
            
            yield return new WaitForSeconds(2);

            tl1yellow.SetActive(false);
            tl2yellow.SetActive(false);
            tl3yellow.SetActive(false);
            tl4yellow.SetActive(false);

            tl1red.SetActive(false);
            tl2red.SetActive(true);
            tl3red.SetActive(false);
            tl4red.SetActive(true);

            tl1green.SetActive(true);
            tl2green.SetActive(false);
            tl3green.SetActive(true);
            tl4green.SetActive(false);

            yield return new WaitForSeconds(4);

            //YELLOW SECTION2
            tl1green.SetActive(false);
            tl3green.SetActive(false);

            tl1yellow.SetActive(true);
            tl2yellow.SetActive(false);
            tl3yellow.SetActive(true);
            tl4yellow.SetActive(false);

            yield return new WaitForSeconds(2);
        }
    }

    void Start()
    {
        StartCoroutine(changeLight());

    }
}
