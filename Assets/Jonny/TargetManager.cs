using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 90 * Time.deltaTime * speed);

        transform.localScale -= new Vector3(0.4f * Time.deltaTime * speed, 0.4f * Time.deltaTime * speed, 1);
        if (transform.localScale.x <= 0.5f)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
    }
}
