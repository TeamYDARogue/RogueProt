using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

    [SerializeField]
    private float m_distance = 5.0f;
    [SerializeField]
    private float m_hAngle = 0.0f;
    [SerializeField]
    private float m_vAngle = 0.0f;
    [SerializeField]
    private Vector3 m_offset = Vector3.zero;
    [SerializeField]
    private Transform m_lookAt = null;

    private float m_rotateTime;

    public bool IsChanged
    {
        get;
        private set;
    }


    void Update()
    {
        if(m_lookAt != null)
        {
            Vector3 lookPosition = m_lookAt.position + m_offset;
            Vector3 relativePos = Quaternion.Euler(m_vAngle, m_hAngle, 0) * new Vector3(0, 0, -m_distance);

            transform.position = lookPosition + relativePos;
            transform.LookAt(m_lookAt);
        }

        CheckInputKey();
    }

    void CheckInputKey()
    {
        if (IsChanged) return;
        if(Input.GetAxis("Horizontal") > 0)
        {
            ChangeRotation(0.5f, m_hAngle, m_hAngle + 90.0f);
            IsChanged = false;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            ChangeRotation(0.5f, m_hAngle, m_hAngle - 90.0f);
            IsChanged = false;
        }
        if(m_hAngle >= 360.0f) { m_hAngle = 0.0f; }
        if(m_hAngle < 0) { m_hAngle *= -3.0f; }
    }

    void ChangeRotation(float time,float begin,float end)
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
}
