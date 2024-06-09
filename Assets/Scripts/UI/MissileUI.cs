using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileUI : MonoBehaviour
{
    private int MissileCount;
    private Image figureImage;
    private Text textMissile;
    private Image circleImage;
    private float fillAmount = 0f;
    private float timerToNextMissile = 0f;
    private float startTimerToNextMissile = 0f;
    void Start()
    {
        Transform figureTransform = transform.Find("Figure");
        Transform circleTransform = transform.Find("CircleTimer");
        Transform textTransform = transform.Find("Text");
        figureImage = figureTransform.GetComponent<Image>();
        textMissile = textTransform.GetComponent<Text>();
        circleImage = circleTransform.GetComponent<Image>();
        circleImage.fillAmount = 0f;

    }

    void Update()
    {
        if (MissileCount == 0 && timerToNextMissile > 0) {
            startTimerToNextMissile += Time.deltaTime;
            fillAmount = startTimerToNextMissile / timerToNextMissile;
            if (fillAmount < 0f) fillAmount = 0f;
            circleImage.fillAmount = fillAmount;
        }
        if (MissileCount > 0) {
            startTimerToNextMissile = 0f;
            timerToNextMissile = 0f;
            fillAmount = 0f;
            circleImage.fillAmount = fillAmount;
        }
    }

    public void SetMissileCount(int count) {
        MissileCount = count;

        if (figureImage == null) return;
        if (textMissile == null) return;

        Color currentColor = figureImage.color;

        if(MissileCount > 0) {
            figureImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1.0f);
            textMissile.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1.0f);
        }
        else{
            figureImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.3f);
            textMissile.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.3f);
        }
    }

    public void SetTimerToNextMissile(float timer) {
        if(timer != 0 && timerToNextMissile == 0) {
            timerToNextMissile = timer;
            startTimerToNextMissile = 0f;
        }
    }
}
