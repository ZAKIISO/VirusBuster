using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEFT : MonoBehaviour
{

    //壁当たり判定フラグ　true:壁に当たっている　false:壁に当たっていない
    public bool Wflg;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider col)
    {
        //壁に当たっていたら
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Player2")
        {
            Wflg = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        //壁と離れたら
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Player2")
        {
            Wflg = false;
        }
    }
}