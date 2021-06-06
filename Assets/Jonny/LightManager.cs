using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] float speed;
    int rad;

    void Start()
    {
        rad = 5;
        StartCoroutine(ColorChange());
    }

    void Update()
    {
        /*
        transform.eulerAngles += new Vector3(0, 0, rad * Time.deltaTime * speed);

        if (transform.rotation.z >= 15)
        {
            rad = -5;
        }
        else if (transform.rotation.z <= -15)
        {
            rad = 5;
        }*/
    }

    IEnumerator ColorChange()
    {
        yield return new WaitForSeconds(2);
        
        while(true)
        {
            byte red = (byte)Random.Range(1, 256);
            byte blue = (byte)Random.Range(1, 256);
            byte green = (byte)Random.Range(1, 256);

            GetComponentInChildren<Light>().color = new Color(red, green, blue);
            yield return new WaitForSeconds(2);
        }
    }
}
