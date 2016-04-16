
using UnityEngine;
using System.Collections;
public class CharactorMove : MonoBehaviour
{
    
/// <summary>
/// Charactor move script
/// iTweenでマス目移動する際に一瞬で移動しないように調整をかける
/// </summary>
    bool moveflg = false; // 移動中をtrue
    private Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// 左右キーで方向転換
    /// 上キーで向いている方向に移動
    /// </summary>
    void Update()
    {
        Vector3? movepos = null;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0.0f, -90f, 0.0f));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0.0f, 90f, 0.0f));
		
        }
	
        if (Input.GetKey(KeyCode.UpArrow))
        {

            if (transform.eulerAngles.y==0.0f)//標準
            {
                movepos = transform.position + new Vector3(0.0f, 0.0f, 25.0f);
            }
            if (transform.eulerAngles.y==90.00001f)//右向き
            { //右を向いたときになぜか補正がかかるのでこのような数値になっている
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
                     ///ターン送るときはここに記述

        }
        // キーが押されて移動量が算出された状態且つ移動中でない場合に発動する
        if (movepos != null && moveflg == false){
                iTween.MoveTo(gameObject,  iTween.Hash(
                "position",
                movepos, // 移動先
               "time",0.7 , // 移動にかかる秒数(要調整)
               "oncomplete",
               "complete" // 移動が終了すると関数complete()が呼ばれる
               ));
            moveflg = true;

        }
        animator.SetBool("moveflg", moveflg);
    }

    /// <summary>
    /// moveflgを折る
    /// </summary>
    void complete()
    {
        moveflg = false;
    }

}