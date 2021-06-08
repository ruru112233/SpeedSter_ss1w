using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] GameObject[] lights;

    void Start()
    {
        StartCoroutine(Flash());
        StartCoroutine(Flash());
        StartCoroutine(Flash());
        StartCoroutine(Flash());
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
