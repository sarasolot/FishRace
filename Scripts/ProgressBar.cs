using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

    [SerializeField] GameObject finishLine = null;
    [SerializeField] RectTransform firstPlayerProgress = null;
    [SerializeField] RectTransform secondPlayerProgress = null;
    [SerializeField] Player1 player1 = null;

    float finishPosition;
    float firstStartPosition;
    float courseLength;

    void Start () 
    {  
        finishPosition = finishLine.transform.position.z;
        firstStartPosition = player1.transform.position.z;
        courseLength = finishLine.transform.position.z - firstStartPosition;
    }

    public void FirstUpdateSlider(float distance)
    {
        if (distance > finishPosition)
        {
            return;
        }
        if (firstPlayerProgress == null)
        {
            return;
        }
        float relativeScale = 1 - (finishPosition - distance) / courseLength;
        Vector3 scale = firstPlayerProgress.transform.localScale;
        scale.x = relativeScale;
        firstPlayerProgress.transform.localScale = scale;
    }
    public void SecondUpdateSlider(float distance)
    {
        if (distance > finishPosition)
        {
            return;
        }
        if (secondPlayerProgress == null)
        {
            return;
        }

        float relativeScale = 1 - (finishPosition - distance) / courseLength;
        Vector3 scale = secondPlayerProgress.transform.localScale;
        scale.x = relativeScale;
        secondPlayerProgress.transform.localScale = scale;
    }


}
