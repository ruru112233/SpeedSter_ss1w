using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentType
{
    public string Perfect = "パーフェクト";
    public string Great = "グレート";
    public string Good = "グッド";
    public string Bad = "バッド";
    public string Miss = "ミス";
}

public class NotesController : MonoBehaviour
{
    [SerializeField]
    private float notesSpeed = 0;

    [SerializeField]
    private int lineNum;

    [SerializeField]
    private Transform judgmentLine = null;

    public GameController gameController;

    private bool isInLine = false;
    private KeyCode lineKey;

    // Start is called before the first frame update
    void Start()
    {
        lineKey = GameUtil.GetKeyCodeByLineNum(lineNum);
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        judgmentLine = GameObject.FindWithTag("JudgmentLine").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-notesSpeed * Time.deltaTime, 0, 0);

        
        if (transform.position.x <= -10f)
        {
            Debug.Log(lineNum);
            Destroy(gameObject);
        }

        if (isInLine)
        {
            CheckInput(lineKey);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInLine = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInLine = false;
    }

    void CheckInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            JudgmentResult();
            gameController.GoodTimingFunc(lineNum);
            Destroy(this.gameObject);
        }
    }

    // 判定ラインとノーツの距離による判定結果
    void JudgmentResult()
    {
        JudgmentType judgmentType = new JudgmentType();

        float distance = Mathf.Abs(judgmentLine.transform.position.x - transform.position.x);

        if (distance <= 0.05f)
        {
            GameManager.instance.testText.text = judgmentType.Perfect;
        }
        else if(distance <= 0.10f)
        {
            GameManager.instance.testText.text = judgmentType.Great;
        }
        else if(distance <= 0.20f)
        {
            GameManager.instance.testText.text = judgmentType.Good;
        }
        else if(distance <= 0.30f)
        {
            GameManager.instance.testText.text = judgmentType.Bad;
        }
        else
        {
            GameManager.instance.testText.text = judgmentType.Miss;
        }

    }

}
