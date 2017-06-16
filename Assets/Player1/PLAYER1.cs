//--------------------------------------------------------------------------------------------------------------------------
//記 述 者：磯崎　大輝
//記　　述：プレイヤー1のScript
//記述内容：矢印の表示・非表示　等
//--------------------------------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER1 : MonoBehaviour {

    //----------------------------------------------------------------------------------------------------------------------
    //上下左右の当たり判定を行うオブジェクトを入れる変数
    //----------------------------------------------------------------------------------------------------------------------
    GameObject Up;                  //上
    GameObject Down;                //下
    GameObject Right;               //右
    GameObject Left;                //左

    //----------------------------------------------------------------------------------------------------------------------
    //上下左右の矢印オブジェクトを入れる変数
    //----------------------------------------------------------------------------------------------------------------------
    GameObject UpArrow;             //上
    GameObject DownArrow;           //下
    GameObject RightArrow;          //右
    GameObject LeftArrow;           //左

    //----------------------------------------------------------------------------------------------------------------------
    //上下左右の当たり判定スクリプトを入れる変数
    //----------------------------------------------------------------------------------------------------------------------
    UP Uscript;                     //上
    DOWN Dscript;                   //下
    RIGHT Rscript;                  //右
    LEFT Lscript;                   //左

    //----------------------------------------------------------------------------------------------------------------------
    //その他変数
    //----------------------------------------------------------------------------------------------------------------------
    bool Ctrigger = false;          //クリック判定；
    public int direction = 0;       //プレイヤーの進む向きを判別する変数
    bool display = false;           //プレイヤーがクリックされた際の表示非表示を切り替えるための変数

    // Use this for initialization
    void Start ()
    {
        //-----------------------------------------------------------------------------------------------------------------
        //当たり判定オブジェクト取得
        //-----------------------------------------------------------------------------------------------------------------
        Up = GameObject.Find("Player/Up");
        Down = GameObject.Find("Player/Down");
        Right = GameObject.Find("Player/Right");
        Left = GameObject.Find("Player/Left");

        //-----------------------------------------------------------------------------------------------------------------
        //当たり判定のスクリプト取得
        //-----------------------------------------------------------------------------------------------------------------
        Uscript = GameObject.Find("Up").GetComponent<UP>();
        Dscript = GameObject.Find("Down").GetComponent<DOWN>();
        Rscript = GameObject.Find("Right").GetComponent<RIGHT>();
        Lscript = GameObject.Find("Left").GetComponent<LEFT>();

        //-----------------------------------------------------------------------------------------------------------------
        //矢印オブジェクト取得
        //-----------------------------------------------------------------------------------------------------------------
        UpArrow = GameObject.Find("UpArrow");
        DownArrow = GameObject.Find("DownArrow");
        RightArrow = GameObject.Find("RightArrow");
        LeftArrow = GameObject.Find("LeftArrow");

        //-----------------------------------------------------------------------------------------------------------------
        //初期化
        //-----------------------------------------------------------------------------------------------------------------
        Ctrigger = false;    //クリック判定初期化
        direction = 0;       //向き変数の初期化

    }
	
	// Update is called once per frame
	void Update ()
    {
        //-----------------------------------------------------------------------------------------------------------------
        //プレイヤー位置を取得
        //-----------------------------------------------------------------------------------------------------------------
        //Vector3 Ppos = transform.position;

        //-----------------------------------------------------------------------------------------------------------------
        //上下左右の当たり判定がない時の矢印の非表示
        //-----------------------------------------------------------------------------------------------------------------

        //プレイヤーがクリックされたら矢印を表示する
        if (Ctrigger == true)
        {
            //-------------------------------------------------------------------------------------------------------------
            //判定が壁に当たっていない
            //-------------------------------------------------------------------------------------------------------------

            //上当たり判定が壁に当たっていない　&& プレイヤーの向いている方向が下ではない
            if (Uscript.Wflg == false && direction != 3)
            {
                UpArrow.GetComponent<BoxCollider>().enabled = true;
                UpArrow.GetComponent<Renderer>().enabled = true;
            }
            //下当たり判定が壁に当たっていない　&& プレイヤーの向いている方向が上ではない
            if (Dscript.Wflg == false && direction != 1)
            {
                DownArrow.GetComponent<BoxCollider>().enabled = true;
                DownArrow.GetComponent<Renderer>().enabled = true;
            }
            //右当たり判定が壁に当たっていない　&& プレイヤーの向いている方向が左ではない
            if (Rscript.Wflg == false && direction != 2)
            {
                RightArrow.GetComponent<BoxCollider>().enabled = true;
                RightArrow.GetComponent<Renderer>().enabled = true;
            }
            //左当たり判定が壁に当たっていない  && プレイヤーの向いている方向が右ではない
            if (Lscript.Wflg == false && direction != 4)
            {
                LeftArrow.GetComponent<BoxCollider>().enabled = true;
                LeftArrow.GetComponent<Renderer>().enabled = true;
            }

            //-------------------------------------------------------------------------------------------------------------
            //判定が壁に当たっている ＆　プレイヤーが今進んでいる方向と逆に進めないように
            //-------------------------------------------------------------------------------------------------------------

            //上当たり判定が壁に当たっている || プレイヤーの向いている向きが下
            if (Uscript.Wflg == true || direction ==3)
            {
                UpArrow.GetComponent<BoxCollider>().enabled = false;
                UpArrow.GetComponent<Renderer>().enabled = false;
            }
            //下当たり判定が壁に当たっている || プレイヤーの向いている向きが上
            if (Dscript.Wflg == true || direction == 1)
            {
                DownArrow.GetComponent<BoxCollider>().enabled = false;
                DownArrow.GetComponent<Renderer>().enabled = false;
            }
            //右当たり判定が壁に当たっている || プレイヤーの向いている向きが左
            if (Rscript.Wflg == true || direction == 2)
            {
                RightArrow.GetComponent<BoxCollider>().enabled = false;
                RightArrow.GetComponent<Renderer>().enabled = false;
            }
            //左当たり判定が壁に当たっている || プレイヤーの向いている向きが右
            if (Lscript.Wflg == true || direction == 4)
            {
                LeftArrow.GetComponent<BoxCollider>().enabled = false;
                LeftArrow.GetComponent<Renderer>().enabled = false;
            }

            //-------------------------------------------------------------------------------------------------------------
            //行き止まりになったら
            //-------------------------------------------------------------------------------------------------------------

            //上方向に進んでいる時行き止まりになったら
            if(Uscript.Wflg == true && Rscript.Wflg == true && Lscript.Wflg == true && direction == 1)
            {
                direction = 0;
            }
            //下方向に進んでいる時行き止まりになったら
            if(Dscript.Wflg == true && Rscript.Wflg == true && Lscript.Wflg == true && direction == 3)
            {
                direction = 0;
            }
            //右方向に進んでいる時行き止まりになったら
            if(Rscript.Wflg == true && Uscript.Wflg == true && Dscript.Wflg == true && direction == 4)
            {
                direction = 0;
            }
            //左方向に進んでいる時行き止まりになったら
            if(Lscript.Wflg == true && Uscript.Wflg == true && Dscript.Wflg == true && direction == 2)
            {
                direction = 0;
            }

            //-------------------------------------------------------------------------------------------------------------
            //矢印表示状態
            //-------------------------------------------------------------------------------------------------------------
            display = true;
        }

        //-----------------------------------------------------------------------------------------------------------------
        //矢印が表示されている時にプレイヤーがクリックされたら矢印を非表示にする
        //-----------------------------------------------------------------------------------------------------------------
        if(Ctrigger == false)
        {
            //矢印を全て非表示にする
            UpArrow.GetComponent<BoxCollider>().enabled = false;
            UpArrow.GetComponent<Renderer>().enabled = false;
            DownArrow.GetComponent<BoxCollider>().enabled = false;
            DownArrow.GetComponent<Renderer>().enabled = false;
            RightArrow.GetComponent<BoxCollider>().enabled = false;
            RightArrow.GetComponent<Renderer>().enabled = false;
            LeftArrow.GetComponent<BoxCollider>().enabled = false;
            LeftArrow.GetComponent<Renderer>().enabled = false;

            //矢印非表示状態
            display = false;
        }
    }

    //プレイヤーのクリック判定
    void OnMouseUpAsButton()
    {
        //矢印非表示状態でプレイヤーがクリックされたら
        if (display == false)
        {
            Ctrigger = true;
        }
        //矢印表示状態でプレイヤーがクリックされたら
        if (display == true)
        {
            Ctrigger = false;
        }
    }
}
