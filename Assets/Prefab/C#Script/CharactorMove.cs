
using UnityEngine;
using System.Collections;
public class CharactorMove : MonoBehaviour
{
    
    private Animator animator;
    [SerializeField]
    private float m_distance = 5.0f;
    [SerializeField]
    private float m_hAngle = 0.0f;
    [SerializeField]
    private float m_vAngle = 0.0f;
    [SerializeField]
    private Vector3 m_offset = Vector3.zero;
    private float m_rotateTime;

    public bool IsChanged
    {
        get;
        private set;
    }
    bool moveflg = false;
    void Start(){
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Vector3? movepos = null;
        transform.rotation = Quaternion.Euler(m_vAngle, m_hAngle, 0);
        if (Input.GetKey(KeyCode.UpArrow))
        {

            if (m_hAngle==0)
            {
                movepos = transform.position + new Vector3(0.0f, 0.0f, 25.0f);
            }
            if (m_hAngle==90.0f)
            { 
                movepos = transform.position + new Vector3(25.0f, 0.0f, 0.0f);
            }
            if (m_hAngle ==180.0f)
            {
                movepos = transform.position + new Vector3(0.0f, 0.0f, -25.0f);
            }
            if (m_hAngle== 270.0f)
            {
                movepos = transform.position + new Vector3(-25.0f, 0.0f, 0.0f);
            }
     
        }
        if (movepos != null && moveflg == false)
        {
                iTween.MoveTo(gameObject,  iTween.Hash("position", movepos,"time",0.7 ,"oncomplete","complete"));
                moveflg = true;
        }
        animator.SetBool("moveflg", moveflg);
        CheckInputKey();
    }

    void CheckInputKey()
    {
        if (IsChanged) return;
        if (Input.GetAxis("Horizontal") > 0)
        {
            ChangeRotation(0.7f, m_hAngle, m_hAngle + 90.0f);
            IsChanged = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            ChangeRotation(0.7f, m_hAngle, m_hAngle - 90.0f);
            IsChanged = false;
        }
        if (m_hAngle >= 360.0f) { m_hAngle = 0.0f; }
        if (m_hAngle < 0) { m_hAngle *= -3.0f; }
    }
    void ChangeRotation(float time, float begin, float end)
    {
        m_rotateTime = time;
        IsChanged = true;
        iTween.ValueTo(gameObject, iTween.Hash("from", begin, "to", end, "time", m_rotateTime, "onupdate", "UpdateHandler"));
    }
    void UpdateHandler(float value)
    {
        m_hAngle = value;
        m_rotateTime -= Time.deltaTime;
    }
    void complete()
    {
        moveflg = false;
    }

}
