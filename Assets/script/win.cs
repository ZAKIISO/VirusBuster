using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour {

    private testwin test;
    public GameObject retry;//リトライボタン
    public GameObject select_back;//セレクト画面に戻るボタン

    bool winflg =false ;

    float fall_stop_position = 0.0f;

    // Use this for initialization
    void Start ()
    {
		test = GameObject.Find("winflgyou").GetComponent<testwin>();
    }

	
	// Update is called once per frame
	void Update ()
    {
        if(test.flg == true && gameObject.transform.position.y > fall_stop_position)
        {
            transform.position += new Vector3(0.0f, -0.5f, 0.0f);
            winflg = true; 
        }
        else if(winflg == true)
        {
            Instantiate(retry, new Vector3(-2f, -2f, -3.0f), transform.rotation);//リトライ表示
            Instantiate(select_back, new Vector3(2.0f, -2.0f, -3.0f), transform.rotation);//セレクト表示
            winflg = false;
            Debug.Log("表示されました");
        }
    }
}