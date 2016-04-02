using UnityEngine;
using System.Collections;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T m_instance = null;

    public static T Instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = (T)FindObjectOfType(typeof(T));
                if (m_instance == null)
                {
                    Debug.LogError(typeof(T) + "is nothing");
                }
            }
            return m_instance;
        }
    }
}