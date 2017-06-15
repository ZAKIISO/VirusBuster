using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    private roulette RouletteScript; // ルーレットのスクリプト取得
    private RemainingTurn RTScript;  // 残りターンのスクリプト取得

    /*********** スプライトレンダー ************/
    private SpriteRenderer BG;          // MenuBGのスプライトレンダー
    private SpriteRenderer Back;        // MenuBackのスプライトレンダー
    private SpriteRenderer Redoing;     // MenuRedoingのスプライトレンダー
    private SpriteRenderer Select;      // MenuSelectのスプライトレンダー
    private SpriteRenderer Title;       // MenuTitleのスプライトレンダー

    /*********** コライダー ************/
    private CircleCollider2D ThisColl;  // このオブジェクトのコライダー
    private BoxCollider2D BackColl;     // MenuBackのコライダー
    private BoxCollider2D RedoingColl;  // MenuRedoingのコライダー
    private BoxCollider2D SelectColl;   // MenuSelectのコライダー
    private BoxCollider2D TitleColl;    // MenuTitleのコライダー

    void Start ()
    {
        // ルーレットのスクリプト取得
        RouletteScript = GameObject.Find("Roulette").GetComponent<roulette>();

        // 残りターンのスクリプト取得
        RTScript = GameObject.Find("Turn").GetComponent<RemainingTurn>();

        /*********** スプライトレンダー ************/

        // MenuBG　初期false
        BG = GameObject.Find("MenuBG").GetComponent<SpriteRenderer>();
        BG.enabled = false;

        // MenuBack　初期false
        Back = GameObject.Find("MenuBack").GetComponent<SpriteRenderer>();
        Back.enabled = false;

        // MenuRedoing　初期false
        Redoing = GameObject.Find("MenuRedoing").GetComponent<SpriteRenderer>();
        Redoing.enabled = false;

        // MenuSelect　初期false
        Select = GameObject.Find("MenuSelect").GetComponent<SpriteRenderer>();
        Select.enabled = false;

        // MenuTitle　初期false
        Title = GameObject.Find("MenuTitle").GetComponent<SpriteRenderer>();
        Title.enabled = false;

        /*********** コライダー ************/

        // このオブジェクト　初期true
        ThisColl = gameObject.GetComponent<CircleCollider2D>();
        ThisColl.enabled = true;

        // MenuBack　初期false
        BackColl = GameObject.Find("MenuBack").GetComponent<BoxCollider2D>();
        BackColl.enabled = false;

        // MenuRedoing　初期false
        RedoingColl = GameObject.Find("MenuRedoing").GetComponent<BoxCollider2D>();
        RedoingColl.enabled = false;

        // MenuSelect　初期false
        SelectColl = GameObject.Find("MenuSelect").GetComponent<BoxCollider2D>();
        SelectColl.enabled = false;

        // MenuTitle　初期false
        TitleColl = GameObject.Find("MenuTitle").GetComponent<BoxCollider2D>();
        TitleColl.enabled = false;
    }
	

	void Update ()
    {
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
                    transform.localScale = new Vector2(0.245f, 0.245f);
                    transform.position = new Vector2(-7.48f, 4.11f);
                }
            }
        }

        // クリックしたら・・・
        if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = new Vector2(0.255f, 0.255f);
            transform.position = new Vector2(-7.48f, 4.05f);

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
                    // 移動モノの停止用
                    if (Time.timeScale == 1)
                    {
                        Time.timeScale = 0;
                        RouletteScript.enabled = false;
                        RTScript.enabled = false;
                    }

                    /*********** スプライトレンダー ************/
                    BG.enabled = true;       // MenuBG　true
                    Back.enabled = true;     // MenuBack　true
                    Redoing.enabled = true;  // MenuRedoing　true
                    Select.enabled = true;   // MenuSelect　true
                    Title.enabled = true;    // MenuTitle　true

                    /*********** コライダー ************/
                    ThisColl.enabled = false;    // このオブジェクト　false
                    BackColl.enabled = true;     // MenuBack　true
                    RedoingColl.enabled = true;  // MenuRedoing　true
                    SelectColl.enabled = true;   // MenuSelect　true
                    TitleColl.enabled = true;    // MenuTitle　true
                }
            }
        }
    }
}
