﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_ARROW : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------
    //変数
    //----------------------------------------------------------------------------------------------------------------------
    GameObject Player;      //プレイヤーオブジェクトを入れる変数
    PLAYER1 Pscript;        //プレイヤーオブジェクトのスクリプトを入れる変数
    Vector3 Ppos;           //プレイヤーの位置を入れる変数
    bool Ctrigger = false;  //オブジェクト上でクリックボタンが離されたか判定

    private roulette Rscript;//ルーレットのスクリプト読み込み

    // Use this for initialization
    void Start ()
    {
        //-----------------------------------------------------------------------------------------------------------------
        //オブジェクトやスクリプトを取得する
        //-----------------------------------------------------------------------------------------------------------------
        Player = GameObject.Find("Player");                             //プレイヤーオブジェクト取得
        Pscript = GameObject.Find("Player").GetComponent<PLAYER1>();     //プレイヤースクリプト取得

        Rscript = GameObject.Find("Roulette").GetComponent<roulette>();　//ルーレットオブジェクトのrouletteスクリプト読み込み
        //-----------------------------------------------------------------------------------------------------------------
        //初期化
        //-----------------------------------------------------------------------------------------------------------------
        Ctrigger = false;                                                //クリックトリガーの初期化

	}
	
	// Update is called once per frame
	void Update ()
    {
        Ppos = Player.transform.position;                               //プレイヤーの位置を取得
        transform.position = new Vector3(Ppos.x - 1, Ppos.y, -2.0f);    //左矢印を常にPlayerの左隣に配置
    }

    //----------------------------------------------------------------------------------------------------------------------
    //オブジェクト上で左ボタンを押した。オブジェクト外で左ボタンを押してからオブジェクト内に入っても呼ばれない
    //----------------------------------------------------------------------------------------------------------------------
    void OnMouseDown()
    {
        Ctrigger = true;
    }

    //----------------------------------------------------------------------------------------------------------------------
    //オブジェクトから出た時に一度だけ呼ばれる。ボタンの状態は無関係
    //----------------------------------------------------------------------------------------------------------------------
    void OnMouseExit()
    {
        Ctrigger = false;
    }

    //----------------------------------------------------------------------------------------------------------------------
    //オブジェクト上で左ボタンをアップ。オブジェクト外でアップした場合は呼ばれない。
    //----------------------------------------------------------------------------------------------------------------------
    void OnMouseUpAsButton()
    {
        if (Rscript.rouletteNO > 0 && Rscript.Pstart == true)//ルーレットで出た数字が0より大きければ＆プレイヤーの操作が開放されていたら
        {
            if (Ctrigger == true)
            {
                Player.transform.position = new Vector3(Ppos.x - 1, Ppos.y, Ppos.z);//PlayerのX座標を-1移動
                Pscript.direction = 2;                                              //プレイヤーの向いている方向を左
                Rscript.rouletteNO -= 1;                                            //ルーレットで出た数から１引く   
            }
        }
    }
}
