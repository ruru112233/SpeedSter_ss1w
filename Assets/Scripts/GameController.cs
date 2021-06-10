using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using System;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject zoomGirl = null;

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

    [SerializeField]
    private Text comboText;

    [SerializeField]
    int bgmNum;

    // プール用のオブジェクト
    [SerializeField]
    private Transform bluePool = null
                    , redPool = null;

    float time = 0;


    private void Awake()
    {
        startButton.GetComponent<Button>().onClick.SetListener(StartGame);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        timing = new float[1024];
        lineNum = new int[1024];
        zoomGirl.SetActive(false);

        LoadCSV();

        StartCoroutine(GameStart());

    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(0.3f);
        StartGame();
    }

    void Update()
    {
        if (isPlaying)
        {
            CheckNextNotes();
            time = Time.time;
        }

        
        if (time > 50.0f)
        {
            zoomGirl.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        //if (isPlaying)
        //{
        //    CheckNextNotes();
        //}
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

            Instantiate(notes[num], pos, Quaternion.identity, bluePool);

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

            Instantiate(notes[num], pos, Quaternion.identity, redPool);

        }

    }


    // ???y?X?^?[?g
    private void StartGame()
    {
        startButton.SetActive(false);
        StartCoroutine(GameManager.instance.StartScale());
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
    }

    void LoadCSV()
    {
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        StringReader reader = new StringReader(csv.text);

        string textLines = csv.text;
        string[] textMessage = textLines.Split('\n');

        int rowLength = textMessage.Length;

        GameManager.instance.RankingViewCount = rowLength;

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

    public void ScoreCount(int num)
    {
        int comboCount = 1;

        if (GameManager.instance.ComboCount >= 5)
            comboCount = GameManager.instance.ComboCount;
        
        GameManager.instance.Score += num * comboCount;

        // スコアの表示
        scoreText.text = GameManager.instance.Score.ToString();
    }


    public void ComboCount(bool gjobFlag)
    {
        if (gjobFlag)
        {
            GameManager.instance.ComboCount++;
            GameManager.instance.comboObj.GetComponentInChildren<Text>().color = ColorChange();
        }
        else
        {
            GameManager.instance.ComboCount = 0;
        }

        comboText.text = GameManager.instance.ComboCount.ToString();
    }

    // コンボ数の色を変更
    Color ColorChange()
    {
        Color color = new Color(Random.value, Random.value, Random.value, 1.0f);

        return color;
    }

    

}
