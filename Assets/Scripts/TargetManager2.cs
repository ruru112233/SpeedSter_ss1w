using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager2 : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 90 * Time.deltaTime);

        transform.localScale -= new Vector3(0.4f * Time.deltaTime, 0.4f * Time.deltaTime, 1);
        if (transform.localScale.x <= 0.5f)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
    }
}
