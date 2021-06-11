using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JonnyTestSc : MonoBehaviour
{
    [SerializeField] Text text;
    int num = 0;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = num.ToString();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.X))
        {
            num++;
        }
    }
}
