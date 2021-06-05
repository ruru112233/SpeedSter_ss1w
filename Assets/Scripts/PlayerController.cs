using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 topPos,bottomPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = bottomPos;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = topPos;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = bottomPos;
        }
    }
}
