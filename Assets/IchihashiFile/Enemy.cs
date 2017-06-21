using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //向き定数
    public const int NO = 0;//初期値
    public const int UP = 1;//上
    public const int RIGHT = 2;//右
    public const int DOWN = 3;//下
    public const int LEFT = 4;//左

    //壁の判定
    public bool WallUp = false;//上の壁の判定
    public bool WallRight = false;//右の壁の判定
    public bool WallDown = false;//下の壁の判定
    public bool WallLeft = false;//左の壁の判定
    public bool Player1Flg = false;//プレイヤー１の判定
    public bool Player2Flg = false;//プレイヤー２の判定

    //向き判定
    public int muki;//向きの初期値
    public int mukiOld = NO;//前の向き

    //移動速度
    public float speed = 2.0f;

    //ポジションの変数
    Vector3 FourCorner1;//kado1
    Vector3 FourCorner2;//kado2
    Vector3 FourCorner3;//kado3
    Vector3 FourCorner4;//kado4
    Vector3 EnemyPos;//EnemyのPosition

    //他のScript取得の変数
    ComputingDevice CD;//ComputingDeviceの変数

    //フレームカウント関連
    int frameNo;
    int Cnt = 30;

    //逃避の変数
    int ESPCNT = 0;

    void Start()
    {
        //他のScript取得
        CD = GameObject.Find("EnemyRoulette").GetComponent<ComputingDevice>();//ComputingDevice取得
        //他のオブジェクトのポジション取得
        FourCorner1 = GameObject.Find("kado1").transform.position;//kado1のポジション取得
        FourCorner2 = GameObject.Find("kado2").transform.position;//kado2のポジション取得
        FourCorner3 = GameObject.Find("kado3").transform.position;//kado3のポジション取得
        FourCorner4 = GameObject.Find("kado4").transform.position;//kado4のポジション取得
    }
    void Update()
    {
        //向きに対する移動
        switch (muki)
        {
            //上に移動
            case UP:
                frameNo++;
                if (frameNo % Cnt == 0)
                {
                    transform.position += new Vector3(0, 1, 0);
                    frameNo = 0;
                }
                break;
            //下に移動
            case DOWN:
                frameNo++;
                if (frameNo % Cnt == 0)
                {
                    transform.position += new Vector3(0, -1, 0);
                    frameNo = 0;
                }
                break;
            //右に移動
            case RIGHT:
                frameNo++;
                if (frameNo % Cnt == 0)
                {
                    transform.position += new Vector3(1, 0, 0);
                    frameNo = 0;
                }
                break;
            //左に移動
            case LEFT:
                frameNo++;
                if (frameNo % Cnt == 0)
                {
                    transform.position += new Vector3(-1, 0, 0);
                    frameNo = 0;
                }
                break;
        }
        //mukiOldを変更後の向きに変更
        mukiOld = muki;

        //-------------------------------------------------------------------------------------------------------------------
        //移動処理
        //-------------------------------------------------------------------------------------------------------------------
        //左上に行くーーーーー！！
        if (CD.F1flg == true)
        {
            //左当たってない　かつ　前右じゃない
            if (WallLeft == false && mukiOld != RIGHT)
            {
                muki = LEFT;
            }
            //左当たってる
            else if (WallLeft == true)
            {
                //上当たってない かつ　前下じゃない
                if (WallUp == false && mukiOld != DOWN)
                {
                    muki = UP;
                }
                //上当たってる
                else if (WallUp == true)
                {
                    //下当たってない　かつ　前左
                    if (WallDown == false && mukiOld == LEFT)
                    {
                        muki = DOWN;
                    }
                    //右当たってない　かつ　前上
                    else if (WallRight == false && mukiOld == UP)
                    {
                        muki = RIGHT;
                    }
                    //どこも向いてない
                    else if (mukiOld == NO)
                    {
                        muki = DOWN;
                    }
                }
            }
        }

        //右上に行くーーーーー！！
        if (CD.F2flg == true)
        {
            //右当たってない　かつ　前左じゃない
            if (WallRight == false && mukiOld != LEFT)
            {
                muki = RIGHT;
            }
            //右当たってる
            else if (WallRight == true)
            {
                //上当たってない かつ　前下じゃない
                if (WallUp == false && mukiOld != DOWN)
                {
                    muki = UP;
                }
                //上当たってる
                else if (WallUp == true)
                {
                    //下当たってない　かつ　前右
                    if (WallDown == false && mukiOld == RIGHT)
                    {
                        muki = DOWN;
                    }
                    //右当たってない　かつ　前上
                    else if (WallLeft == false && mukiOld == UP)
                    {
                        muki = LEFT;
                    }
                    //どこも向いてない
                    else if (mukiOld == NO)
                    {
                        muki = DOWN;
                    }
                }
            }
        }

        //右下に行くーーーーー！！
        if (CD.F3flg == true)
        {
            //右当たってない　かつ　前左じゃない
            if (WallRight == false && mukiOld != LEFT)
            {
                muki = RIGHT;
            }
            //右に当たってる
            else if (WallRight == true)
            {
                //下当たってない
                if (WallDown == false && mukiOld != UP)
                {
                    muki = DOWN;
                }
                //下当たってる
                else if (WallDown == true)
                {
                    //上当たってない　かつ　前右
                    if (WallUp == false && mukiOld == RIGHT)
                    {
                        muki = UP;
                    }
                    //左当たってない　かつ　前下
                    else if (WallLeft == false && mukiOld == DOWN)
                    {
                        muki = LEFT;
                    }
                    //どこも向いてない
                    else if (mukiOld == NO)
                    {
                        muki = UP;
                    }
                }
            }
        }

        //左下に行くーーーーー！！
        if (CD.F4flg == true)
        {
            //左当たってない　かつ　前右じゃない
            if (WallLeft == false && mukiOld != RIGHT)
            {
                muki = LEFT;
            }
            //左当たった
            else if (WallLeft == true)
            {
                //下当たってない
                if (WallDown == false)
                {
                    muki = DOWN;
                }
                //下当たってる
                else if (WallDown == true)
                {
                    //上当たってない　かつ　前左
                    if (WallUp == false && mukiOld == LEFT)
                    {
                        muki = UP;
                    }
                    //右当たってない　かつ　前下
                    else if (WallRight == false && mukiOld == DOWN)
                    {
                        muki = RIGHT;
                    }
                    //どこも向いてない
                    else if (mukiOld == NO)
                    {
                        muki = UP;
                    }
                }
            }
        }

        //プレイヤ１ or ２に当たった
        if (Player1Flg == true || Player2Flg == true)
        {
            //前回の向きを調べ、逆方向に動く
            if (ESPCNT == 0)
            {
                //前上
                if (mukiOld == UP)
                {
                    muki = DOWN;
                    ESPCNT = 1;
                }
                //前下
                if (mukiOld == DOWN)
                {
                    muki = UP;
                    ESPCNT = 2;
                }
                //前左
                if (mukiOld == LEFT)
                {
                    muki = RIGHT;
                    ESPCNT = 3;
                }
                //前右
                if (mukiOld == RIGHT)
                {
                    muki = LEFT;
                    ESPCNT = 4;
                }
            }
            //前回が上の時
            if (ESPCNT == 1)
            {
                //下に当たった
                if (WallDown == true)
                {
                    //左に当たった　かつ　前回右じゃない
                    if (WallLeft == true && mukiOld != RIGHT)
                    {
                        muki = RIGHT;
                    }
                    //右に当たった　かつ　前回左じゃない
                    else if (WallRight == true && mukiOld != LEFT)
                    {
                        muki = LEFT;
                    }
                }
            }
            //前回が下の時
            if (ESPCNT == 2)
            {
                //上に当たった
                if (WallUp == true)
                {
                    //左に当たった　かつ　前回右じゃない
                    if (WallLeft == true && mukiOld != RIGHT)
                    {
                        muki = RIGHT;
                    }
                    //右に当たった　かつ　前回左じゃない
                    else if (WallRight == true && mukiOld != LEFT)
                    {
                        muki = LEFT;
                    }
                }
            }
            //前回が左の時
            if (ESPCNT == 3)
            {
                //右に当たった
                if (WallRight == true)
                {
                    //上に当たった　かつ　前回下じゃない
                    if (WallUp == true && mukiOld != DOWN)
                    {
                        muki = DOWN;
                    }
                    //下に当たった　かつ　前回上じゃない
                    else if (WallDown == true && mukiOld != UP)
                    {
                        muki = UP;
                    }
                }
            }
            //前回が右の時
            if (ESPCNT == 4)
            {
                //左に当たった
                if (WallLeft == true)
                {
                    //上に当たった　かつ　前回右じゃない
                    if (WallUp == true && mukiOld != DOWN)
                    {
                        muki = DOWN;
                    }
                    //下に当たった　かつ　前回上じゃない
                    else if (WallDown == true && mukiOld != UP)
                    {
                        muki = UP;
                    }
                }
            }
        }

        //プレイヤー１と２に一回ずつ当たった
        if (Player1Flg == true && Player2Flg == true)
        {
            //止まる
            muki = NO;
        }
    }
}