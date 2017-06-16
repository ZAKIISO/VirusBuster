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
    public bool cross = false;//曲がり角の判定
    float crossCnt = 0;//曲がり角カウント
    //向き判定
    public int muki;//向きの初期値
    public int mukiOld = NO;//前の向き
    //スピード
    public float speed = 2.0f;//移動速度
    //ポジションの変数
    Vector3 FourCorner1;//kado1
    Vector3 FourCorner2;//kado2
    Vector3 FourCorner3;//kado3
    Vector3 FourCorner4;//kado4
    Vector3 EnemyPos;//EnemyのPosition
    //他のScript取得の変数
    ComputingDevice CD;//ComputingDeviceの変数

    int frameNo;
    int Cnt = 30;

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
        //交差点の処理
        if (cross)//crossがTrue
        {
            crossCnt += speed;//カウント起動
            if (crossCnt > 5)//カウントが５より上
            {
                MukiSelect();//MukiSelect起動
                cross = false;//crossをFalse
                crossCnt = 0;//カウントを０
            }
        }

        //向きに対する移動
        switch (muki)
        {
            //上に移動
            case UP:
                //GetComponent<Rigidbody>().velocity = new Vector2(0, speed);
                frameNo++;
                if (frameNo % Cnt == 0)
                {
                    transform.position += new Vector3(0, 1, 0);
                    frameNo = 0;
                }
                break;
            //下に移動
            case DOWN:
                //GetComponent<Rigidbody>().velocity = new Vector2(0, -speed);
                frameNo++;
                if (frameNo % Cnt == 0)
                {
                    transform.position += new Vector3(0, -1, 0);
                    frameNo = 0;
                }
                break;
            //右に移動
            case RIGHT:
                //GetComponent<Rigidbody>().velocity = new Vector2(speed, 0);
                frameNo++;
                if (frameNo % Cnt == 0)
                {
                    transform.position += new Vector3(1, 0, 0);
                    frameNo = 0;
                }
                break;
            //左に移動
            case LEFT:
                //GetComponent<Rigidbody>().velocity = new Vector2(-speed, 0);
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
    }

    //移動処理
    void MukiSelect()
    {
        //Enemyのポジション取得
        EnemyPos = transform.position;
        float EnemyPosX = EnemyPos.x;//EnemyのXを取得
        float EnemyPosY = EnemyPos.y;//EnemyのYを取得

        //左上の角が１番遠い
        if (CD.F1flg == true)
        {
            Debug.Log("f1flg");
            //---------------------------------------------
            //FC1のポジション取得
            float FC1X = FourCorner1.x;
            float FC1Y = FourCorner1.y;
            float F1x = EnemyPosX - FC1X;
            float F1y = EnemyPosY - FC1Y;
            //---------------------------------------------

            //--------------------------------------------------------------------
            //F1に最短距離距離で移動
            //--------------------------------------------------------------------
            if (WallLeft == false && mukiOld != RIGHT)
            {
                if (WallLeft == false)
                {
                    muki = LEFT;
                }
            }
            else if (WallRight == false && mukiOld != LEFT)
            {
                if (WallRight == false)
                {
                    muki = RIGHT;
                }
            }
            if (WallDown == false && mukiOld != UP)
            {
                if (WallDown == false)
                {
                    muki = DOWN;
                }
            }
            if (WallUp == false && mukiOld != DOWN)
            {
                if (WallUp == false)
                {
                    muki = UP;
                }
            }
        }

        //--------------------------------------------------------------------
        //F2に最短距離距離で移動
        //--------------------------------------------------------------------
        if (CD.F2flg == true)
        {
            Debug.Log("f2flg");
            float FC2X = FourCorner2.x;
            float FC2Y = FourCorner2.y;
            float F2x = EnemyPosX - FC2X;
            float F2y = EnemyPosY - FC2Y;
            if (Mathf.Abs(F2x) > Mathf.Abs(F2y))
            {
                if (F2x > 0)
                {
                    if (WallLeft == false)
                    {
                        muki = LEFT;
                    }
                }
                else
                {
                    if (WallRight == false)
                    {
                        muki = RIGHT;
                    }
                }
            }
            else
            {
                if (F2y > 0)
                {
                    if(WallDown == false)
                    {
                        muki = DOWN;
                    }
                }
                else
                {
                    if (WallUp == false)
                    {
                        muki = UP;
                    }
                    else
                    {
                        if (WallRight == false)
                        {
                            muki = RIGHT;
                        }
                    }
                }
            }
        }

        //--------------------------------------------------------------------
        //F3に最短距離距離で移動
        //--------------------------------------------------------------------
        if (CD.F3flg == true)
        {
            Debug.Log("f3flg");
            float FC3X = FourCorner3.x;
            float FC3Y = FourCorner3.y;
            float F3x = EnemyPosX - FC3X;
            float F3y = EnemyPosY - FC3Y;
            if (Mathf.Abs(F3x) > Mathf.Abs(F3y))
            {
                if (F3x > 0)
                {
                    if (WallLeft == false)
                    {
                        muki = LEFT;
                    }
                }
                else
                {
                    if (WallRight == false)
                    {
                        muki = RIGHT;
                    }
                }
            }
            else
            {
                if (F3y > 0)
                {
                    if(WallDown == false)
                    {
                        muki = DOWN;
                    }
                }
                else
                {
                    if (WallUp == false)
                    {
                        muki = UP;
                    }
                }
            }
        }

        //--------------------------------------------------------------------
        //F4に最短距離距離で移動
        //--------------------------------------------------------------------
        if (CD.F4flg == true)
        {
            Debug.Log("f4flg");
            float FC4X = FourCorner4.x;
            float FC4Y = FourCorner4.y;
            float F4x = EnemyPosX - FC4X;
            float F4y = EnemyPosY - FC4Y;
            if (Mathf.Abs(F4x) > Mathf.Abs(F4y))
            {
                if (F4x > 0)
                {
                    if (WallLeft == false)
                    {
                        muki = LEFT;
                    }
                    else
                    {
                        if (WallDown == false)
                        {
                            muki = DOWN;
                        }
                    }
                }
                else
                {
                    if (WallRight == false)
                    {
                        muki = RIGHT;
                    }
                }
            }
            else
            {
                if (F4y > 0)
                {
                    if (WallDown == false)
                    {
                        muki = DOWN;
                    }
                }
                else
                {
                    if (WallUp == false)
                    {
                        muki = UP;
                    }
                }
            }
        }
        //バックせず行ける向き
        if (muki == NO && mukiOld != DOWN && WallUp == false) muki = UP;
        if (muki == NO && mukiOld != LEFT && WallRight == false) muki = RIGHT;
        if (muki == NO && mukiOld != UP && WallDown == false) muki = DOWN;
        if (muki == NO && mukiOld != RIGHT && WallLeft == false) muki = LEFT;
        //とにかく進める向き
        if (muki == NO && WallUp == false) muki = UP;
        if (muki == NO && WallRight == false) muki = RIGHT;
        if (muki == NO && WallDown == false) muki = DOWN;
        if (muki == NO && WallLeft == false) muki = LEFT;
    }
}