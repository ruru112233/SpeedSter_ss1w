using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public float speed;
    public float movePos;
    public float nowPos;

    void Update()
    {
        transform.Translate(speed, 0, 0);
        if (transform.position.x > movePos)
        {
            transform.position = new Vector3(nowPos, 0, 0);
        }
    }
}
