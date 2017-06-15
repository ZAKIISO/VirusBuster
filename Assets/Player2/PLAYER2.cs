//--------------------------------------------------------------------------------------------------------------------------
//記 述 者：磯崎　
//記　　述：プレイヤー2のScript
//記述内容：矢印の表示・非表示　等
//--------------------------------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER2 : MonoBehaviour
{

    //----------------------------------------------------------------------------------------------------------------------
    //上下左右の当たり判定を行うオブジェクトを入れる変数
    //----------------------------------------------------------------------------------------------------------------------
    GameObject Up2;                  //上
    GameObject Down2;                //下
    GameObject Right2;               //右
    GameObject Left2;                //左

    //----------------------------------------------------------------------------------------------------------------------
    //上下左右の矢印オブジェクトを入れる変数
    //----------------------------------------------------------------------------------------------------------------------
    GameObject UpArrow2;             //上
    GameObject DownArrow2;           //下
    GameObject RightArrow2;          //右
    GameObject LeftArrow2;           //左

    //----------------------------------------------------------------------------------------------------------------------
    //上下左右の当たり判定スクリプトを入れる変数
    //----------------------------------------------------------------------------------------------------------------------
    UP2 Uscript2;                     //上
    DOWN2 Dscript2;                   //下
    RIGHT2 Rscript2;                  //右
    LEFT2 Lscript2;                   //左

    //----------------------------------------------------------------------------------------------------------------------
    //その他変数
    //----------------------------------------------------------------------------------------------------------------------
    bool Ctrigger = false;          //クリック判定；
    public int direction2 = 0;       //プレイヤーの進む向きを判別する変数
    bool display = false;           //プレイヤーがクリックされた際の表示非表示を切り替えるための変数

    // Use this for initialization
    void Start()
    {
        //-----------------------------------------------------------------------------------------------------------------
        //当たり判定オブジェクト取得
        //-----------------------------------------------------------------------------------------------------------------
        Up2 = GameObject.Find("Player2/Up2");
        Down2 = GameObject.Find("Player2/Down2");
        Right2 = GameObject.Find("Player2/Right");
        Left2 = GameObject.Find("Player2/Left2");

        //-----------------------------------------------------------------------------------------------------------------
        //当たり判定のスクリプト取得
        //-----------------------------------------------------------------------------------------------------------------
        Uscript2 = GameObject.Find("Up2").GetComponent<UP2>();
        Dscript2 = GameObject.Find("Down2").GetComponent<DOWN2>();
        Rscript2 = GameObject.Find("Right2").GetComponent<RIGHT2>();
        Lscript2 = GameObject.Find("Left2").GetComponent<LEFT2>();

        //-----------------------------------------------------------------------------------------------------------------
        //矢印オブジェクト取得
        //-----------------------------------------------------------------------------------------------------------------
        UpArrow2 = GameObject.Find("UpArrow2");
        DownArrow2 = GameObject.Find("DownArrow2");
        RightArrow2 = GameObject.Find("RightArrow2");
        LeftArrow2 = GameObject.Find("LeftArrow2");

        //-----------------------------------------------------------------------------------------------------------------
        //初期化
        //-----------------------------------------------------------------------------------------------------------------
        Ctrigger = false;    //クリック判定初期化
        direction2 = 0;       //向き変数の初期化

    }

    // Update is called once per frame
    void Update()
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
            if (Uscript2.Wflg == false && direction2 != 3)
            {
                UpArrow2.GetComponent<BoxCollider>().enabled = true;
                UpArrow2.GetComponent<Renderer>().enabled = true;
            }
            //下当たり判定が壁に当たっていない　&& プレイヤーの向いている方向が上ではない
            if (Dscript2.Wflg == false && direction2 != 1)
            {
                DownArrow2.GetComponent<BoxCollider>().enabled = true;
                DownArrow2.GetComponent<Renderer>().enabled = true;
            }
            //右当たり判定が壁に当たっていない　&& プレイヤーの向いている方向が左ではない
            if (Rscript2.Wflg == false && direction2 != 2)
            {
                RightArrow2.GetComponent<BoxCollider>().enabled = true;
                RightArrow2.GetComponent<Renderer>().enabled = true;
            }
            //左当たり判定が壁に当たっていない  && プレイヤーの向いている方向が右ではない
            if (Lscript2.Wflg == false && direction2 != 4)
            {
                LeftArrow2.GetComponent<BoxCollider>().enabled = true;
                LeftArrow2.GetComponent<Renderer>().enabled = true;
            }

            //-------------------------------------------------------------------------------------------------------------
            //判定が壁に当たっている ＆　プレイヤーが今進んでいる方向と逆に進めないように
            //-------------------------------------------------------------------------------------------------------------

            //上当たり判定が壁に当たっている || プレイヤーの向いている向きが下
            if (Uscript2.Wflg == true || direction2 == 3)
            {
                UpArrow2.GetComponent<BoxCollider>().enabled = false;
                UpArrow2.GetComponent<Renderer>().enabled = false;
            }
            //下当たり判定が壁に当たっている || プレイヤーの向いている向きが上
            if (Dscript2.Wflg == true || direction2 == 1)
            {
                DownArrow2.GetComponent<BoxCollider>().enabled = false;
                DownArrow2.GetComponent<Renderer>().enabled = false;
            }
            //右当たり判定が壁に当たっている || プレイヤーの向いている向きが左
            if (Rscript2.Wflg == true || direction2 == 2)
            {
                RightArrow2.GetComponent<BoxCollider>().enabled = false;
                RightArrow2.GetComponent<Renderer>().enabled = false;
            }
            //左当たり判定が壁に当たっている || プレイヤーの向いている向きが右
            if (Lscript2.Wflg == true || direction2 == 4)
            {
                LeftArrow2.GetComponent<BoxCollider>().enabled = false;
                LeftArrow2.GetComponent<Renderer>().enabled = false;
            }

            //-------------------------------------------------------------------------------------------------------------
            //行き止まりになったら
            //-------------------------------------------------------------------------------------------------------------

            //上方向に進んでいる時行き止まりになったら
            if (Uscript2.Wflg == true && Rscript2.Wflg == true && Lscript2.Wflg == true && direction2 == 1)
            {
                direction2 = 0;
            }
            //下方向に進んでいる時行き止まりになったら
            if (Dscript2.Wflg == true && Rscript2.Wflg == true && Lscript2.Wflg == true && direction2 == 3)
            {
                direction2 = 0;
            }
            //右方向に進んでいる時行き止まりになったら
            if (Rscript2.Wflg == true && Uscript2.Wflg == true && Dscript2.Wflg == true && direction2 == 4)
            {
                direction2 = 0;
            }
            //左方向に進んでいる時行き止まりになったら
            if (Lscript2.Wflg == true && Uscript2.Wflg == true && Dscript2.Wflg == true && direction2 == 2)
            {
                direction2 = 0;
            }

            //-------------------------------------------------------------------------------------------------------------
            //矢印表示状態
            //-------------------------------------------------------------------------------------------------------------
            display = true;
        }

        //-----------------------------------------------------------------------------------------------------------------
        //矢印が表示されている時にプレイヤーがクリックされたら矢印を非表示にする
        //-----------------------------------------------------------------------------------------------------------------
        if (Ctrigger == false)
        {
            //矢印を全て非表示にする
            UpArrow2.GetComponent<BoxCollider>().enabled = false;
            UpArrow2.GetComponent<Renderer>().enabled = false;
            DownArrow2.GetComponent<BoxCollider>().enabled = false;
            DownArrow2.GetComponent<Renderer>().enabled = false;
            RightArrow2.GetComponent<BoxCollider>().enabled = false;
            RightArrow2.GetComponent<Renderer>().enabled = false;
            LeftArrow2.GetComponent<BoxCollider>().enabled = false;
            LeftArrow2.GetComponent<Renderer>().enabled = false;

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
