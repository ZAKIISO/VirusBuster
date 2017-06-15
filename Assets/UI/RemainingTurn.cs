using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingTurn : MonoBehaviour {

    private Stage StageScript; // ステージからの情報取得用
    private int RT = 0; // 残りターン数

    private SpriteRenderer Goal10SR; // １０桁のスプライトレンダー
    private SpriteRenderer Goal1SR;  // １桁のスプライトレンダー

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

        // 初期残りターンを目標ターン数に設定
        RT = StageScript.turn;

        // １０桁のスプライトレンダー
        Goal10SR = GameObject.Find("limit10").GetComponent<SpriteRenderer>();

        // １桁のスプライトレンダー
        Goal1SR = GameObject.Find("limit1").GetComponent<SpriteRenderer>();

        // 初期画像の設定
        Goal10SR.sprite = zero;
        Goal1SR.sprite = zero;
    }
	
	void Update ()
    {
        // テスト用
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                GameObject tapObject = collition2d.transform.gameObject;

                if (tapObject == GameObject.Find("Roulette"))
                {
                    RT -= 1;
                }
            }
        }

        if (RT == 15)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = five;
        }
        if (RT == 14)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = four;
        }
        if (RT == 13)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = three;
        }
        if (RT == 12)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = two;
        }
        if (RT == 11)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = one;
        }
        if (RT == 10)
        {
            Goal10SR.sprite = one;
            Goal1SR.sprite = zero;
        }
        if (RT == 9)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = nine;
        }
        if (RT == 8)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = eight;
        }
        if (RT == 7)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = seven;
        }
        if (RT == 6)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = six;
        }
        if (RT == 5)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = five;
        }
        if (RT == 4)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = four;
        }
        if (RT == 3)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = three;
        }
        if (RT == 2)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = two;
        }
        if (RT == 1)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = one;
        }
        if (RT == 0)
        {
            Goal10SR.sprite = zero;
            Goal1SR.sprite = zero;
        }
    }
}
