using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 5);

        transform.localScale -= new Vector3(0.02f, 0.02f, 1);
        if (transform.localScale.x <= 0.5f)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
    }
}
