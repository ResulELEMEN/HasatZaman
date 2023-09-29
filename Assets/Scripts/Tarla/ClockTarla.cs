using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
public class ClockTarla : MonoBehaviour
{
    public bool TimesUp;
    public bool ekili = false;
    public TextMeshPro TarlaTimeTMP;
    public int TarlaNo;
    public TarlaP tarlaParent;
    public Topla toplaButton;
    void Start()
    {
        TimesUp = false;
        ekili =PlayerPrefs.GetInt("ekili" + TarlaNo.ToString(),0) == 0 ? false : true;
        if(ekili)
        {
            ReturnGameCountTime();
        }
        else
        {
            transform.DOScale(Vector3.zero, 0f);
        }

    }
    public void LessTimeVoid(int totalSeconds,int getiri)
    {
        StartCoroutine(LessTime(totalSeconds,getiri));
    }
    IEnumerator LessTime(int totalSeconds,int getiri)
    {
        transform.DOScale(Vector3.one, 0.3f);
        ekili = true;
        PlayerPrefs.SetInt("ekili" + TarlaNo.ToString(), ekili ? 1 : 0);
        while (totalSeconds >= 0)
        {
            FormatTime(totalSeconds);
            yield return new WaitForSeconds(1f);
            totalSeconds--;
            TimeSave(totalSeconds);
            PlayerPrefs.SetInt("ekili" + TarlaNo.ToString(), ekili ? 1 : 0 );
        }
        tarlaParent.ToprakSpriteChange(7);
        toplaButton.ToplaGorun(getiri);
        TimesUp = true;
        transform.DOScale(Vector3.zero, 0.3f);
    }
    void FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;
        string timeString = string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
        TarlaTimeTMP.text = timeString;
    }
    void TimeSave(int totalSecond)
    {
        System.DateTime currentTime = System.DateTime.Now;
        string dateTimeString = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
        PlayerPrefs.SetString("LastTime" + TarlaNo.ToString(), dateTimeString);
        PlayerPrefs.SetInt("totalSecond" + TarlaNo.ToString(), totalSecond);
        PlayerPrefs.Save();
    }
    void ReturnGameCountTime()
    {
        System.DateTime currentTime = System.DateTime.Now;
        string savedDateTimeString = PlayerPrefs.GetString("LastTime" + TarlaNo.ToString());
        System.DateTime lastDateTime = DateTime.ParseExact(savedDateTimeString, "yyyy-MM-dd HH:mm:ss", null);
        TimeSpan timeDif = currentTime - lastDateTime;
        int DifSec = (int)timeDif.TotalSeconds;
        int totalSecond = PlayerPrefs.GetInt("totalSecond" + TarlaNo.ToString());
        totalSecond = totalSecond - DifSec;
        int getiri= PlayerPrefs.GetInt("Birim" + TarlaNo, 0);
        if (totalSecond <= 0)
        {
            TimesUp = true;
            transform.DOScale(Vector3.zero, 0f);
        }
        else
        {
            StartCoroutine(LessTime(totalSecond, getiri));
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
