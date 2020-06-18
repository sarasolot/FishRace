using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] GameObject imageObject = null;
    Coroutine startCountdown;

    void Start()
    {
        CountDown();
    }

    public void CountDown()
    {
        startCountdown = StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        Texture2D two = Resources.Load<Texture2D>("2gold");
        Texture2D one = Resources.Load<Texture2D>("1gold");

        yield return new WaitForSeconds(1.0f);
        imageObject.GetComponent<RawImage>().texture = two;
        yield return new WaitForSeconds(1.0f);
        imageObject.GetComponent<RawImage>().texture = one;
        yield return new WaitForSeconds(1.0f);
        imageObject.GetComponent<RawImage>().color = new Color(0, 0, 0, 0);

    }
}