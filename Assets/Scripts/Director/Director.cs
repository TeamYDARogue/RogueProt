using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    void Awake()
    {
        var sceneManager = SceneManager.Instance;

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
}