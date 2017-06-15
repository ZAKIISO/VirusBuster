using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    //向き
    public const int NO = 0;
    public const int UP = 1;
    public const int RIGHT = 2;
    public const int DOWN = 3;
    public const int LEFT = 4;

    //センサーの位置
    public int Ichi = NO;
    //親オブジェクト
    GameObject objParent;
    //親オブジェクトのスクリプト
    Enemy EnemyScript;


    // Use this for initialization
    void Start()
    {
        //親オブジェクトを取得
        objParent = this.transform.parent.gameObject;
        //親オブジェクトのコンポーネント(Script)を取得
        EnemyScript = objParent.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //当たり判定があったとき
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {

            switch (Ichi)
            {
                case UP:
                    EnemyScript.WallUp = true;
                    break;
                case RIGHT:
                    EnemyScript.WallRight = true;
                    break;
                case DOWN:
                    EnemyScript.WallDown = true;
                    break;
                case LEFT:
                    EnemyScript.WallLeft = true;
                    break;
            }
        }
    }
    //当たり判定があったとき
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            switch (Ichi)
            {
                case UP:
                    EnemyScript.WallUp = false;
                    break;
                case RIGHT:
                    EnemyScript.WallRight = false;
                    break;
                case DOWN:
                    EnemyScript.WallDown = false;
                    break;
                case LEFT:
                    EnemyScript.WallLeft = false;
                    break;
            }
        }
    }

}
