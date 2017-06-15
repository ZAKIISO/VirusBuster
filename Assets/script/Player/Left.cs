//---------------------------------------------------------------------------------
//左矢印のScript
//記述内容：壁との当たり判定を探知し、表示・非表示の切り替え
//---------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour {

    private LArrow Arrow;
	// Use this for initialization
	void Start () {
        Arrow = GameObject.Find("LeftArrow").GetComponent<LArrow>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Debug.Log("aaa");
            Arrow.enabled = false;
        }
    }
}
