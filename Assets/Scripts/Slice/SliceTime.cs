using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliceTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public int totalSeconds = 100;
    public GameObject endPanel;
    public GameObject sliceTrail;
    public GameObject fruits;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LessTime());
        // Zamaný biçimlendirilmiþ bir metin olarak ayarla
    }
    IEnumerator LessTime()
    {
        while (totalSeconds >= 0)
        {
            FormatTime(totalSeconds);
            yield return new WaitForSeconds(1f);
            totalSeconds--;
        }
        endPanel.SetActive(true);
        Tohum.Instance.InGameTotalWrite();
        sliceTrail.SetActive(false);
        fruits.SetActive(false);
    }
    void FormatTime(int seconds)
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;

        // Zamaný 00:00 biçimine dönüþtür
        string timeString = string.Format("{0:00}:{1:00}", minutes, remainingSeconds);

        // TextMeshPro nesnesine yazdýr
        timeText.text = timeString;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
