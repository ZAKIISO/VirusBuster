using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    private Stage StageScript;  // ステージからの情報取得用

    private SpriteRenderer Goal10SR; // １０桁のスプライトレンダー
    private SpriteRenderer Goal1SR; // １桁のスプライトレンダー

    // 数字のスプライト
    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;

    void Start ()
    {
        // ステージからの情報取得用
        StageScript = GameObject.Find("Main Camera").GetComponent<Stage>();

        // １０桁のスプライトレンダー
        Goal10SR = GameObject.Find("goal10").GetComponent<SpriteRenderer>();

        // １桁のスプライトレンダー
        Goal1SR = GameObject.Find("goal1").GetComponent<SpriteRenderer>();

        // 初期画像の設定
        Goal10SR.sprite = zero;
        Goal1SR.sprite = zero;
	}

    void Update()
    {
        if (StageScript.turn == 15)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = five;
        }
        if (StageScript.turn == 14)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = four;
        }
        if (StageScript.turn == 13)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = three;
        }
        if (StageScript.turn == 12)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = two;
        }
        if (StageScript.turn == 11)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = one;
        }
        if (StageScript.turn == 10)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = zero;
        }
        if (StageScript.turn == 9)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = nine;
        }
        if (StageScript.turn == 8)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = eight;
        }
        if (StageScript.turn == 7)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = seven;
        }
        if (StageScript.turn == 6)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = six;
        }
        if (StageScript.turn == 5)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = five;
        }
        if (StageScript.turn == 4)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = four;
        }
        if (StageScript.turn == 3)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = three;
        }
        if (StageScript.turn == 2)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = two;
        }
        if (StageScript.turn == 1)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = one;
        }
        if (StageScript.turn == 0)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = zero;
        }
    }
}
