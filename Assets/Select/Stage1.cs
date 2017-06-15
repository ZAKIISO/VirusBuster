using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    private Fade fade;
    private float frameCnt = 0;
    private bool SceneChange = false;

    void Start()
    {
        SceneChange = false;
        fade = GameObject.Find("Fade").GetComponent<Fade>();
    }

    void Update()
    {
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
