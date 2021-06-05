using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NotesGenerator : MonoBehaviour
{
    [SerializeField]
    private Button testStartButton = null;

    [SerializeField]
    private GameObject notes1 = null;


    [SerializeField]
    private Transform notesTopPos = null
                    , notesBottmPos = null;
    
    private void Awake()
    {
        //testStartButton.onClick.SetListener(NotesGen);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NotesInstanceTiming());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ノーツの生成タイミング
    private IEnumerator NotesInstanceTiming()
    {
        yield return new WaitForSeconds(0.2f);

        NotesGen(true);

        yield return new WaitForSeconds(0.4f);

        NotesGen(false);
        yield return new WaitForSeconds(0.4f);

        NotesGen(true);
        yield return new WaitForSeconds(0.4f);

        NotesGen(false);

        yield return new WaitForSeconds(0.2f);

        NotesGen(false);

        yield return new WaitForSeconds(0.2f);

        NotesGen(false);

        yield return new WaitForSeconds(0.2f);

        NotesGen(true);
        NotesGen(false);
    }


    // ノーツを流す
    private void NotesGen(bool topFlag)
    {
        if (topFlag)
        {
            Instantiate(notes1, notesTopPos);
        }
        else
        {
            Instantiate(notes1, notesBottmPos);
        }

    }
}
