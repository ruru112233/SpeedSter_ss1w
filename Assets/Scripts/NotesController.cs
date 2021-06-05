using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    [SerializeField]
    private float notesSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-notesSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -10f)
        {
            //Destroy(gameObject);
        }
    }
}
