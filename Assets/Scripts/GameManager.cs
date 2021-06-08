using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class GameManager : MonoBehaviour
{
    public Text testText = null;

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
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RankingButton()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(Score);
    }


}
