using UnityEngine;
using System.Collections;
public class AssistCamera : MonoBehaviour
{
    /// <summary>
    /// カメラに追従させる物体につけるもの
    /// キャラクターと何も変わらない
    /// </summary>
    bool moveflg = false; // 移動中をtrue
   
    void Start()
    {
   

    }

    void Update()
    {
   
        Vector3? movepos = null;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
			if (transform.eulerAngles.y==0.0f)//標準
			{
				movepos = transform.position + new Vector3(25.0f, 0.0f, 25.0f);
			}
			if (transform.eulerAngles.y==90.00001f)//右向き
			{
				movepos = transform.position + new Vector3(25.0f, 0.0f, -25.0f);
			}
			if (transform.eulerAngles.y == 180.0f)//後ろ
			{
				movepos = transform.position + new Vector3(-25.0f, 0.0f, -25.0f);
			}
			if (transform.eulerAngles.y == 270.0f)//左
			{
				movepos = transform.position + new Vector3(-25.0f, 0.0f, 25.0f);
			}
            transform.Rotate(new Vector3(0f, -90f, 0f));//カメラを回す
		

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))//カメラを回す
        {
            
			if (transform.eulerAngles.y==0.0f)//標準
			{
				movepos = transform.position +new Vector3(-25.0f, 0.0f, 25.0f);
			}
			if (transform.eulerAngles.y==90.00001f)//右向き
			{
				movepos = transform.position + new Vector3(25.0f, 0.0f, 25.0f);
			}
			if (transform.eulerAngles.y == 180.0f)//後ろ
			{
				movepos = transform.position + new Vector3(25.0f, 0.0f, -25.0f);
			}
			if (transform.eulerAngles.y == 270.0f)//左
			{
				movepos = transform.position + new Vector3(-25.0f, 0.0f, -25.0f);
			}
			transform.Rotate(new Vector3(0f, 90f, 0f));//カメラを回す 
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
    
			if (transform.eulerAngles.y==0.0f)//標準
			{
				movepos = transform.position + new Vector3(0.0f, 0.0f, 25.0f);
			}
			if (transform.eulerAngles.y==90.00001f)//右向き
			{
				movepos = transform.position + new Vector3(25.0f, 0.0f, 0.0f);
			}
			if (transform.eulerAngles.y == 180.0f)//後ろ
			{
				movepos = transform.position + new Vector3(0.0f, 0.0f, -25.0f);
			}
			if (transform.eulerAngles.y == 270.0f)//左
			{
				movepos = transform.position + new Vector3(-25.0f, 0.0f, 0.0f);
			}

          
        }
        // キーが押されて移動量が算出された状態且つ移動中でない場合に発動する
        if (movepos != null && moveflg == false)
        {
            iTween.MoveTo(gameObject, 
                iTween.Hash(
            "position",
            movepos, // 移動先
           "time", 0.7,// 移動にかかる秒数(要調整)
           "oncomplete",
           "complete" // 移動が終了すると関数complete()が呼ばれる
           ));

            moveflg = true;

        }
       
    }


    /// <summary>
    /// moveflgを折る
    /// </summary>
    void complete()
    {
        moveflg = false;
    }

}