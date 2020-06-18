using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public enum Status
    {
        Active,
        Inactive
    }

    [Tooltip("Panel with the menu items on them. Gets enabled and disabled.")]
    [SerializeField] GameObject UIPanel = null;

    Status status;

    void Start()
    {
        status = Status.Inactive;
        Time.timeScale = 1;
        UIPanel.SetActive(false);
    }

   
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    public void Open()
    {
        Time.timeScale = 0;
        status = Status.Active;
        UIPanel.SetActive(true);
    }

   
    public void Close()
    {
        Time.timeScale = 1;
        status = Status.Inactive;
        UIPanel.SetActive(false);
    }

  
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
