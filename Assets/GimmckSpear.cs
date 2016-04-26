using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/*
状況
・現状動くsauceには、しているが違和感がある
・打開策としてbool型に直そうとしていて、いまいち書き込めてない
　のでコメントアウトにしています。

*/

public class GimmckSpear: MonoBehaviour
{

    //private bool spearact1 = true;
    //private bool spearact2 = false;

    int cnt = 0;
    void Update()
    {

    }
    public void SpearAction()
    {
        cnt += 1;
        //spearact1

        if (cnt%2==1)
        {
            Vector3 pos = gameObject.transform.position;
            pos.y = 0;
            gameObject.transform.position = pos;
            //Debug.Log("奇数");
        }
        else //if(spearact2)
        {
            Vector3 pos = gameObject.transform.position;
            pos.y = -100;
            gameObject.transform.position = pos;


            //Debug.Log("偶数");
        }
    }
        void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("atari");
        }

    }

}
