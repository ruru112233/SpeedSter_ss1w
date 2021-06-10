using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public RectTransform textReady = null
                       , textGo = null;

    public GameObject[] pref;

    [SerializeField]
    private Button rankingButton = null;

    // スコア
    private int score = 0;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    // コンボ
    private int comboCount;

    public int ComboCount
    {
        get { return comboCount; }
        set { comboCount = value; }
    }

    public Sprite perfect = null
                , great = null
                , good = null
                , bad = null
                , miss = null;

    // ターゲット（青）の判定関係
    [SerializeField]
    private GameObject blueJudgment = null;
    float blueTime = 0;
    public bool blueFlag = false;

    // ターゲット（赤）の判定関係
    [SerializeField]
    private GameObject redJudgment = null;
    float redTime = 0;
    public bool redFlag = false;

    public GameObject comboObj = null;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (rankingButton != null)
            rankingButton.onClick.SetListener(RankingButton);
    }

    // Start is called before the first frame update
    void Start()
    {
        blueJudgment.SetActive(false);
        redJudgment.SetActive(false);
        comboObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (blueFlag)
        {
            blueTime += Time.deltaTime;

            if (blueTime >= 0.5f)
            {
                blueJudgment.SetActive(false);
                blueFlag = false;

            }
        }

        if (redFlag)
        {
            redTime += Time.deltaTime;

            if (redTime >= 0.5f)
            {
                redJudgment.SetActive(false);
                redFlag = false;
                
            }
        }

        if (ComboCount > 3)
        {
            comboObj.SetActive(true);
        }
        else
        {
            comboObj.SetActive(false);
        }
    }

    void RankingButton()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Score);
    }

    // 判定管理
    public void JudgmentManager(int num, KeyCode key)
    {

        SpriteRenderer BSR = blueJudgment.GetComponent<SpriteRenderer>();
        SpriteRenderer RSR = redJudgment.GetComponent<SpriteRenderer>();

        if (key == KeyCode.UpArrow)
        {
            JudgmentSprite(num, BSR);
            blueTime = 0;
            blueFlag = true;
            blueJudgment.SetActive(true);
        }
        else if (key == KeyCode.DownArrow)
        {
            JudgmentSprite(num, RSR);
            redTime = 0;
            redFlag = true;
            redJudgment.SetActive(true);
        }
        
    }

    // スプライトの切り替え
    void JudgmentSprite(int num, SpriteRenderer sr)
    {
        switch (num)
        {
            case 1:
                sr.sprite = perfect;
                break;
            case 2:
                sr.sprite = great;
                break;
            case 3:
                sr.sprite = good;
                break;
            case 4:
                sr.sprite = bad;
                break;
            case 5:
                sr.sprite = miss;
                break;
        }
    }

    public IEnumerator StartScale()
    {

        textReady.DOScale(new Vector3(3, 3, 1), 1.0f);

        yield return new WaitForSeconds(3.5f);

        textReady.DOScale(Vector3.zero, 0.0f);

        textGo.DOScale(new Vector3(3, 3, 1), 1.0f);

        yield return new WaitForSeconds(2.0f);

        textGo.DOScale(Vector3.zero, 0.5f);

    }


}
