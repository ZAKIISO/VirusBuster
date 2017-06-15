using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {

    private SpriteRenderer StartSR;
    private SpriteRenderer NPCSR;
    private SpriteRenderer VSSR;

    private BoxCollider2D StartColl;
    private BoxCollider2D NPCColl;
    private BoxCollider2D VSColl;

    private float frameCnt;
    private bool touch = false;

    private float a = 1;
    private float b = 0;

    private bool sa = false;

    void Start ()
    {
        StartSR = GameObject.Find("start").GetComponent<SpriteRenderer>();
        NPCSR = GameObject.Find("NPC").GetComponent<SpriteRenderer>();
        VSSR = GameObject.Find("VS").GetComponent<SpriteRenderer>();

        StartColl = GameObject.Find("start").GetComponent<BoxCollider2D>();
        NPCColl = GameObject.Find("NPC").GetComponent<BoxCollider2D>();
        VSColl = GameObject.Find("VS").GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // スタートタッチ前
        if (touch == false)
        {
            frameCnt++;

            if (frameCnt % 20 == 0)
            {
                StartSR.enabled = false;
            }

            if (frameCnt % 40 == 0)
            {
                StartSR.enabled = true;
                frameCnt = 0;
            }
        }

        // タッチ後
        if (touch == true)
        {
            frameCnt++;
            // 透明度変更
            StartSR.color = new Color(1, 1, 1, a);
            NPCSR.color = new Color(1, 1, 1, b);
            VSSR.color = new Color(1, 1, 1, b);

            // スタート消す用
            if (frameCnt % 2 == 0)
            {
                a -= 0.1f;
            }

            // スタート消えたら
            if (frameCnt % 60 == 0)
            {
                sa = true;
                frameCnt = 0;
            }

            // スタート消えた後
            if (sa == true)
            {
                if (frameCnt % 2 == 0)
                {
                    b += 0.1f;
                }

                if (frameCnt % 60 == 0)
                {
                    NPCColl.enabled = true;
                    VSColl.enabled = true;
                }
            }
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
                    touch = true;
                    frameCnt = 0;

                    StartSR.enabled = true;
                    StartColl.enabled = false;
                }
            }
        }
    }
}
