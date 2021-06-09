using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager2 : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 120 * Time.deltaTime);

        transform.localScale -= new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 1);
        if (transform.localScale.x <= 2.5f)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
    }
}
