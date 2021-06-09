using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager2 : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 160 * Time.deltaTime);

        transform.localScale -= new Vector3(3 * Time.deltaTime, 3 * Time.deltaTime, 1);
        if (transform.localScale.x <= 2.2f)
        {
            transform.localScale = new Vector3(3.5f, 3.5f, 1);
        }
    }
}
