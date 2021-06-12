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
    private KeyCode lineKey, lineKey2;

    // Start is called before the first frame update
    void Start()
    {
        lineKey = GameUtil.GetKeyCodeByLineNum(lineNum);
        lineKey2 = GameUtil.GetKeyCodeByLineNum2(lineNum);
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        judgmentLine = GameObject.FindWithTag("JudgmentLine").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInLine)
        {
            CheckInput(lineKey, lineKey2);
        }

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(-notesSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInLine = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInLine = false;

        if (other.gameObject.tag == "MissLine")
        {
            gameController.ComboCount(false);
        }
    }

    private void OnBecameInvisible()
    {
        GameManager.instance.NotesCount++;
        gameObject.SetActive(false);
    }

    void CheckInput(KeyCode key, KeyCode key2)
    {
        if (Input.GetKeyDown(key) || Input.GetKeyDown(key2))
        {
            JudgmentResult();
            transform.position += new Vector3(-30, 0, 0);
            //Destroy(this.gameObject);
        }
    }

    // ???????C?????m?[?c????????????????????
    void JudgmentResult()
    {
        JudgmentType judgmentType = new JudgmentType();

        float distance = Mathf.Abs(judgmentLine.transform.position.x - transform.position.x);

        if (distance <= 0.15f)
        {
            Instantiate(GameManager.instance.pref[0], transform.position, transform.rotation);
            gameController.ScoreCount(100);
            gameController.ComboCount(true);

            GameManager.instance.JudgmentManager(1, lineKey);
        }
        else if(distance <= 0.30f)
        {
            Instantiate(GameManager.instance.pref[1], transform.position, transform.rotation);
            gameController.ScoreCount(50);
            gameController.ComboCount(true);
            GameManager.instance.JudgmentManager(2, lineKey);
        }
        else if(distance <= 0.40f)
        {
            Instantiate(GameManager.instance.pref[2], transform.position, transform.rotation);
            gameController.ScoreCount(10);
            gameController.ComboCount(true);
            GameManager.instance.JudgmentManager(3, lineKey);
        }
        else if(distance <= 0.50f)
        {
            Instantiate(GameManager.instance.pref[3], transform.position, transform.rotation);
            gameController.ScoreCount(1);
            gameController.ComboCount(false);
            GameManager.instance.JudgmentManager(4, lineKey);
        }
        else
        {
            Instantiate(GameManager.instance.pref[4], transform.position, transform.rotation);
            GameManager.instance.ComboCount = 0;
            gameController.ComboCount(false);
            GameManager.instance.JudgmentManager(5, lineKey);
        }

    }

}
