using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesController : MonoBehaviour
{
    [SerializeField]
    private float notesSpeed = 0;

    [SerializeField]
    private int lineNum;

    public GameController gameController;

    private bool isInLine = false;
    private KeyCode lineKey;

    // Start is called before the first frame update
    void Start()
    {
        lineKey = GameUtil.GetKeyCodeByLineNum(lineNum);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-notesSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= -10f)
        {
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
        Debug.Log(isInLine);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInLine = false;
        Debug.Log(isInLine);
    }

    void CheckInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            gameController.GoodTimingFunc(lineNum);
            Destroy(this.gameObject);
        }
    }

}
