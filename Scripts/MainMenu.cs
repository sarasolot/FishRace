using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    [SerializeField] GameObject UIPanel = null;

    
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
