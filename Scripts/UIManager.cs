using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField] WinnerText winnerPanel = null;
    [SerializeField] ProgressBar firstProgress = null;
    [SerializeField] ProgressBar secondProgress = null;
    

    static UIManager instance;

    void Awake()
    {
        instance = this;
    }

    public static void SetWinner(int number)
    {
        instance.winnerPanel.SetWinner(number);
    }
    public static void FirstUpdateSlider(float distance)
    {
        instance.firstProgress.FirstUpdateSlider(distance);
    }
    public static void SecondUpdateSlider(float distance)
    {
        instance.secondProgress.SecondUpdateSlider(distance);
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}