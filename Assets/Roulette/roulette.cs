using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roulette : MonoBehaviour {

    // オーディオ
    private AudioSource SE;

    private bool rouletteON = false;   // ルーレット回転　true = ON　false = OFF
    public int rouletteNO = 0;        // ルーレットの数値取得用
    private int frameCnt = 0;          // frameCnt用
    private int rouletteTime = 0;      // ルーレット回転時間
    private bool NoDoubleTouch = true; // 二度押し防止用フラグ

    private SpriteRenderer SPR;        // スプライトレンダー

    private PLAYER1 P1;
    private PLAYER2 P2;

    public bool Pstart = false;                 //プレイヤー操作の可(true)、不可(false)

    // 画像
    public Sprite Base;                // 初期画像
    public Sprite NO1;
    public Sprite NO2;
    public Sprite NO3;
    public Sprite NO4;
    public Sprite NO5;
    public Sprite NO6;

    void Start ()
    {
        // オーディオ
        SE = gameObject.GetComponent<AudioSource>();

        // スプライトレンダー
        SPR = GetComponent<SpriteRenderer>();
        // 初期画像をBaseに設定
        SPR.sprite = Base;

        P1 = GameObject.Find("Player").GetComponent<PLAYER1>(); //プレイヤーオブジェクトのPLAYER1スクリプト読み込み
        P2 = GameObject.Find("Player2").GetComponent<PLAYER2>(); //プレイヤーオブジェクトのPLAYER2スクリプト読み込み
    }
	
    void Update ()
    {
        //ルーレットで出た数が０になったら
        if(rouletteNO ==　0)
        {
            Pstart = false; //playerの操作を不可に
        }

        // クリックしたら・・・
        if (Input.GetMouseButtonDown(0))
        {

           
            // rayの設定
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                // クリックしたオブジェクトを取得
                GameObject tapObject = collition2d.transform.gameObject;

                // クリックしたオブジェクトがこのオブジェクトだったら
                if (tapObject == gameObject)
                {
                    P1.direction = 0;//プレイヤーの進む向きを判別する変数をリセット
                    P2.direction2 = 0;//プレイヤーの進む向きを判別する変数をリセット
                    // ルーレット回転開始
                    rouletteON = true;
                }
            }
        }

        // ルーレットがONならば・・・
        if (rouletteON == true)
        {
            frameCnt++;
            // 3フレーム毎に
            if (frameCnt % 3 == 0)
            {
        
                Debug.Log(rouletteNO);
                // 1～6の数値をランダムで取得
                rouletteNO = Random.Range(1, 7);
                // 音声再生
                SE.Play();
            }

            // 一秒ごとに・・・
            if (frameCnt % 60 == 0)
            {
                
                // ルーレット回転時間＋１
                rouletteTime += 1;
                frameCnt = 0;
            }    

            // rouletteNoに合わせて画像変更
            if (rouletteNO == 1)
            {
                SPR.sprite = NO1;
            }
            if (rouletteNO == 2)
            {
                SPR.sprite = NO2;
            }
            if (rouletteNO == 3)
            {
                SPR.sprite = NO3;
            }
            if (rouletteNO == 4)
            {
                SPR.sprite = NO4;
            }
            if (rouletteNO == 5)
            {
                SPR.sprite = NO5;
            }
            if (rouletteNO == 6)
            {
                SPR.sprite = NO6;
            }
        }

        // ルーレット回転時間が３秒になったら・・・
        if (rouletteTime == 3)
        {
            // ルーレット回転停止
            rouletteON = false;
            frameCnt = 0;
            rouletteTime = 0;
            Pstart = true; //playerの操作を解放
            Debug.Log("stop");
        }
    }
}
