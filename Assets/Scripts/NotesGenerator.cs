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

    private float startTime = 0;
    
    [SerializeField]
    private CsvWriter csvWriter;

    private bool isPlaying = false;

    private void Awake()
    {
        testStartButton.onClick.SetListener(StartMusic);
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(NotesInstanceTiming());
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            DetectKeys();
        }
    }

    // 音楽スタート
    public void StartMusic()
    {
        AudioManager.instance.PlayBGM(0);
        startTime = Time.time;
        isPlaying = true;
    }

    void DetectKeys()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            WriteNotesTiming(0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            WriteNotesTiming(1);
        }
    }

    void WriteNotesTiming(int num)
    {
        Debug.Log(GetTiming());

        csvWriter.WriteCSV(GetTiming().ToString() + "," + num.ToString());
    }

    float GetTiming()
    {
        return Time.time - startTime;
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
