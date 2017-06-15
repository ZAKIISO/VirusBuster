using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuRedoing : MonoBehaviour
{
    private Fade fade;                  // Fadeのスクリプト
    private float frameCnt = 0;         // フレームカウント
    private bool SceneChange = false;   // シーン遷移用
    private SpriteRenderer ThisSp;      // スプライトレンダー

    void Start ()
    {
        // シーン遷移用
        SceneChange = false;

        // Fade用
        fade = GameObject.Find("Fade").GetComponent<Fade>();

        // スプライトレンダー
        ThisSp = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // クリックDOWN
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
                    // 画像小さく
                    transform.localScale = new Vector2(0.28f, 0.28f);
                    // 色変更
                    ThisSp.color = new Color(0.5f, 0.5f, 0.5f);
                }
            }
        }

        // クリックしたら・・・
        if (Input.GetMouseButtonUp(0))
        {
            // 画像大きく
            transform.localScale = new Vector2(0.3f, 0.3f);
            // 色変更
            ThisSp.color = new Color(1, 1, 1);

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
                    fade.enabled = true; // fade開始
                    SceneChange = true;  // シーンチェンジフラグ
                }
            }
        }

        // シーンチェンジフラグがtrueならば
        if (SceneChange == true)
        {
            frameCnt++; // フレームカウント

            // 一秒後
            if (frameCnt % 60 == 0)
            {
                // シーン移動
                SceneManager.LoadScene("stage");
                frameCnt = 0;
                SceneChange = false;
            }
        }
    }
}
