
using UnityEngine;
using System.Collections;
public class CharactorMove : MonoBehaviour
{
    ///
/// <summary>
/// 埋め込んだオブジェクトをキーでマス目移動させる
/// iTweenでマス目移動する際に一瞬で移動しないように調整をかける
/// </summary>
    bool moveflg = false; // 移動中をtrue
    private Animator animator;
    void Start(){
        animator = GetComponent<Animator>();

    }
    /// <summary>
    /// キーを押すと現在位置と移動量で移動先を算出し移動させる
    /// 入力した方向に向かってボディを回転させる
    /// </summary>
    void Update()
    {
        // Vector3をNULL許容型に変換
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

            if (transform.eulerAngles.y==0)  //標準
            {
                movepos = transform.position + new Vector3(0.0f, 0.0f, 25.0f);
            }
            if (transform.eulerAngles.y==90)//右向き
            {
                movepos = transform.position + new Vector3(25.0f, 0.0f, 0.0f);
            }
            if (transform.eulerAngles.y == 180)//後ろ
            {
                movepos = transform.position + new Vector3(0.0f, 0.0f, -25.0f);
            }
            if (transform.eulerAngles.y == 270)//左
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