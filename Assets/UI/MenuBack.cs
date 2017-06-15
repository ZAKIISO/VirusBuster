using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBack : MonoBehaviour {

    private roulette RouletteScript; // ルーレットのスクリプト取得
    private RemainingTurn RTScript;  // 残りターンのスクリプト取得

    /*********** スプライトレンダー ************/
    private SpriteRenderer ThisSp;      // このオブジェクトのスプライトレンダー
    private SpriteRenderer BG;          // MenuBGのスプライトレンダー
    private SpriteRenderer Back;        // MenuBackのスプライトレンダー
    private SpriteRenderer Redoing;     // MenuRedoingのスプライトレンダー
    private SpriteRenderer Select;      // MenuSelectのスプライトレンダー
    private SpriteRenderer Title;       // MenuTitleのスプライトレンダー

    /*********** コライダー ************/
    private CircleCollider2D MenuColl;  // Menuのコライダー
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

        // このオブジェクト
        ThisSp = gameObject.GetComponent<SpriteRenderer>();

        // MenuBG
        BG = GameObject.Find("MenuBG").GetComponent<SpriteRenderer>();

        // MenuBack
        Back = GameObject.Find("MenuBack").GetComponent<SpriteRenderer>();

        // MenuRedoing
        Redoing = GameObject.Find("MenuRedoing").GetComponent<SpriteRenderer>();

        // MenuSelect
        Select = GameObject.Find("MenuSelect").GetComponent<SpriteRenderer>();

        // MenuTitle
        Title = GameObject.Find("MenuTitle").GetComponent<SpriteRenderer>();

        /*********** コライダー ************/

        // Menu
        MenuColl = GameObject.Find("Menu").GetComponent<CircleCollider2D>();

        // MenuBack
        BackColl = GameObject.Find("MenuBack").GetComponent<BoxCollider2D>();

        // MenuRedoing
        RedoingColl = GameObject.Find("MenuRedoing").GetComponent<BoxCollider2D>();

        // MenuSelect
        SelectColl = GameObject.Find("MenuSelect").GetComponent<BoxCollider2D>();

        // MenuTitle
        TitleColl = GameObject.Find("MenuTitle").GetComponent<BoxCollider2D>();
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

        // クリックUP
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
                    // 移動モノの再起動用
                    if (Time.timeScale == 0)
                    {
                        Time.timeScale = 1;
                        RouletteScript.enabled = true;
                        RTScript.enabled = true;
                    }

                    /*********** スプライトレンダー ************/
                    BG.enabled = false;       // MenuBG　false
                    Back.enabled = false;     // MenuBack　false
                    Redoing.enabled = false;  // MenuRedoing　false
                    Select.enabled = false;   // MenuSelect　false
                    Title.enabled = false;    // MenuTitle　false

                    /*********** コライダー ************/
                    MenuColl.enabled = true;      // Menu　false
                    BackColl.enabled = false;     // MenuBack　false
                    RedoingColl.enabled = false;  // MenuRedoing　false
                    SelectColl.enabled = false;   // MenuSelect　false
                    TitleColl.enabled = false;    // MenuTitle　false
                }
            }
        }
    }
}
