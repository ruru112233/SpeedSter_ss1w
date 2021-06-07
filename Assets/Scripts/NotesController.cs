using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgmentType
{
    public string Perfect = "�p�[�t�F�N�g";
    public string Great = "�O���[�g";
    public string Good = "�O�b�h";
    public string Bad = "�o�b�h";
    public string Miss = "�~�X";
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
        //transform.position += new Vector3(-notesSpeed * Time.deltaTime, 0, 0);


        //if (transform.position.x <= -10f)
        //{
        //    Debug.Log(lineNum);
        //    Destroy(gameObject);
        //}

        if (isInLine)
        {
            CheckInput(lineKey);
        }

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(-notesSpeed * Time.deltaTime, 0, 0);

        //if (transform.position.x <= -10f)
        //{
        //    Destroy(gameObject);
        //}

        //if (isInLine)
        //{
        //    CheckInput(lineKey);
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInLine = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInLine = false;
    }

    private void OnBecameInvisible()
    {
        // ��ʊO�ɍs������A��A�N�e�B�u�ɂ���
        gameObject.SetActive(false);
    }

    void CheckInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            JudgmentResult();
            transform.position += new Vector3(-30, 0, 0);
            //Destroy(this.gameObject);
        }
    }

    // ���胉�C���ƃm�[�c�̋����ɂ�锻�茋��
    void JudgmentResult()
    {
        JudgmentType judgmentType = new JudgmentType();

        float distance = Mathf.Abs(judgmentLine.transform.position.x - transform.position.x);

        if (distance <= 0.10f)
        {
            GameManager.instance.testText.text = judgmentType.Perfect;
            Instantiate(GameManager.instance.pref[0], transform.position, transform.rotation);
            gameController.ScoreCount(100);
            gameController.ComboCount(true);
        }
        else if(distance <= 0.20f)
        {
            GameManager.instance.testText.text = judgmentType.Great;
            Instantiate(GameManager.instance.pref[1], transform.position, transform.rotation);
            gameController.ScoreCount(50);
            gameController.ComboCount(true);
        }
        else if(distance <= 0.30f)
        {
            GameManager.instance.testText.text = judgmentType.Good;
            Instantiate(GameManager.instance.pref[2], transform.position, transform.rotation);
            gameController.ScoreCount(10);
            gameController.ComboCount(true);
        }
        else if(distance <= 0.40f)
        {
            GameManager.instance.testText.text = judgmentType.Bad;
            Instantiate(GameManager.instance.pref[3], transform.position, transform.rotation);
            gameController.ScoreCount(1);
            gameController.ComboCount(false);
        }
        else
        {
            GameManager.instance.testText.text = judgmentType.Miss;
            Instantiate(GameManager.instance.pref[4], transform.position, transform.rotation);
            GameManager.instance.ComboCount = 0;
            gameController.ComboCount(false);
        }

    }

}
