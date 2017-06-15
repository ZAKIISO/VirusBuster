using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //当たり判定があったとき
    void OnTriggerEnter(Collider other)
    {
        //交差点
        if (other.gameObject.tag == "kado")
        {
            //親オブジェクトを取得
            GameObject objParent = this.transform.parent.gameObject;
            //親オブジェクトのコンポーネント(Script)を取得
            Enemy EnemyScript = objParent.GetComponent<Enemy>();
            EnemyScript.cross = true;
        }
    }

}
