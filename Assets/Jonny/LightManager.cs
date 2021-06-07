using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject[] lights;

    void Start()
    {
        StartCoroutine(Flash());
        StartCoroutine(Flash());
        StartCoroutine(Flash());
        StartCoroutine(Flash());
    }

    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 1 * Time.deltaTime * speed);

        /*if (transform.rotation.z >= 15)
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

    IEnumerator Flash()
    {
        while(true)
        {
            float waitTime = Random.Range(0.5f, 1f);

            int n = Random.Range(0, lights.Length);
            LightOn(n);
            yield return new WaitForSeconds(waitTime);

            LightOff(n);
            yield return new WaitForSeconds(0.2f);
        }
    }

    void LightOff(int n)
    {
        lights[n].SetActive(false);
    }

    void LightOn(int n)
    {
        lights[n].SetActive(true);
    }
}
