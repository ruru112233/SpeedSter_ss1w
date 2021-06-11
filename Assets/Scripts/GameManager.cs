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

    // ?A?j???[?V???????W
    [SerializeField]
    private Animator anime = null;
    [SerializeField]
    private Animator animeZ = null;


    [SerializeField]
    private Button rankingButton = null;

    private int rankingViewCount = 0;

    public int RankingViewCount
    {
        get { return rankingViewCount; }
        set { rankingViewCount = value; }
    }

    private int notesCount = 0;

    public int NotesCount
    {
        get { return notesCount; }
        set { notesCount = value; }
    }

    bool rankingFlag = false;

    // ?X?R?A
    private int score = 0;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    // ?R???{
    private int comboCount = 0;

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

    // ?^?[?Q?b?g?i???j?????????W
    [SerializeField]
    private GameObject blueJudgment = null;
    float blueTime = 0;
    public bool blueFlag = false;

    // ?^?[?Q?b?g?i???j?????????W
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
        AnimeChenge();
        blueJudgment.SetActive(false);
        redJudgment.SetActive(false);
        comboObj.SetActive(false);

        

    }

    // Update is called once per frame
    void Update()
    {
        AnimeChenge();

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

        if(RankingViewCount <= NotesCount && !rankingFlag)
        {
            rankingFlag = true;
            RankingButton();
        }
    }

    void RankingButton()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Score);
    }

    // ????????
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

    // ?X?v???C?g??????????
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


    // ?R???{?????????A?j???[?V???????`?F???W
    public void AnimeChenge()
    {
        if (ComboCount < 5)
        {
            PlayerAnime(true, false, false, false);
        }
        else if(ComboCount < 10)
        {
            PlayerAnime(false, true, false, false);
        }
        else if (ComboCount < 15)
        {
            PlayerAnime(false, false, true, false);
        }
        else
        {
            PlayerAnime(false, false, false, true);
        }
    }

    // ?A?j???[?V????
    public void PlayerAnime(bool combo1, bool combo5, bool combo10, bool combo15)
    {
        anime.SetBool("combo1", combo1);
        anime.SetBool("combo5", combo5);
        anime.SetBool("combo10", combo10);
        anime.SetBool("combo15", combo15);
        animeZ.SetBool("combo1", combo1);
        animeZ.SetBool("combo5", combo5);
        animeZ.SetBool("combo10", combo10);
        animeZ.SetBool("combo15", combo15);
    }

}
