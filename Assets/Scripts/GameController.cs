using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] notes = null;
    
    private float[] timing = null;
    private int[] lineNum = null;

    public string filePass = null;

    private int notesCount = 0;

    private float startTime = 0;

    [SerializeField]
    private float timeOffset = -1;

    private bool isPlaying = false;
    
    [SerializeField]
    private GameObject startButton = null;

    [SerializeField]
    private Text scoreText;

    private int score = 0;

    [SerializeField]
    int bgmNum;

    // プール用のオブジェクト
    [SerializeField]
    private Transform bluePool = null
                    , redPool = null;

    private void Awake()
    {
        startButton.GetComponent<Button>().onClick.SetListener(StartGame);
    }

    // Start is called before the first frame update
    void Start()
    {
        timing = new float[1024];
        lineNum = new int[1024];
        LoadCSV();

    }

    void Update()
    {
        //if (isPlaying)
        //{
        //    CheckNextNotes();
        //} 
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            CheckNextNotes();
        }
    }

    // オブジェクトプール
    void InstNotes(int num, Vector3 pos, Quaternion rotation)
    {
        if (num == 1)
        {
            foreach (Transform t in bluePool)
            {
                if (!t.gameObject.activeSelf)
                {
                    t.SetPositionAndRotation(pos, rotation);
                    t.gameObject.SetActive(true);
                    return;
                }
            }
        }
        else if(num == 0)
        {
            foreach (Transform t in redPool)
            {
                if (!t.gameObject.activeSelf)
                {
                    t.SetPositionAndRotation(pos, rotation);
                    t.gameObject.SetActive(true);
                    return;
                }
            }
        }

        if (num == 1)
        {
            Instantiate(notes[num], pos, Quaternion.identity, bluePool);
        }
        else if(num == 0)
        {
            Instantiate(notes[num], pos, Quaternion.identity, redPool);
        }
    }


    // ???y?X?^?[?g
    private void StartGame()
    {
        startButton.SetActive(false);
        AudioManager.instance.PlayBGM(bgmNum);
        startTime = Time.time;
        isPlaying = true;
    }

    void CheckNextNotes()
    {
        while (timing[notesCount] + timeOffset < GetMusicTime() && timing[notesCount] != 0)
        {
            SpawnNotes(lineNum[notesCount]);
            notesCount++;
        }
    }

    void SpawnNotes(int num)
    {
        Vector3 pos = new Vector3(10.0f, (3.0f * num) - 1.8f);

        InstNotes(num, pos, Quaternion.identity);

        //Instantiate(notes[num],
        //    new Vector3(10.0f ,  (3.0f * num) - 1.8f, 0),
        //    Quaternion.identity);
    }

    void LoadCSV()
    {
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        StringReader reader = new StringReader(csv.text);

        int i = 0;

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                timing[i] = float.Parse(values[0]);
                lineNum[i] = int.Parse(values[1]);
            }
            i++;
        }

    }

    float GetMusicTime()
    {
        return Time.time - startTime;
    }

    public void GoodTimingFunc(int num)
    {
        Debug.Log("Line:" + num + " good! ");
        Debug.Log(GetMusicTime());

        score++;
    }

}
