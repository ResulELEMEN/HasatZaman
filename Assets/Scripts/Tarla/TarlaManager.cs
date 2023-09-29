using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TarlaManager : MonoBehaviour
{
    public List<GameObject> farms;
    public List<Sprite> tarlaSpirites;
    public GameObject ileriButton;
    public GameObject geriButton;

    // Start is called before the first frame update
    void Start()
    {
        FirstOpen();
    }
    void FirstOpen()
    {
        LevelManeger.Instance.currentLevel = 0;
        farms[0].transform.localScale = Vector3.one;
        Vector3 pos = ileriButton.GetComponent<RectTransform>().position;
        for (int i = 1; i < farms.Count; i++)
        {
            farms[i].transform.localScale = Vector3.zero;
            farms[i].transform.position = new Vector3(pos.x, pos.y, farms[i].transform.position.z);
        }
    }
    bool buttonLock = true;
    public void IleriButton()
    {
        if (buttonLock)
        {
            if (LevelManeger.Instance.currentLevel < farms.Count - 1)
            {
                Vector3 pos = geriButton.GetComponent<RectTransform>().position;
                Vector3 currentpos = farms[LevelManeger.Instance.currentLevel].transform.position;
                farms[LevelManeger.Instance.currentLevel].transform.DOMove(pos, 0.5f);
                farms[LevelManeger.Instance.currentLevel].transform.DOScale(Vector3.zero, 0.5f);
                LevelManeger.Instance.currentLevel++;
                farms[LevelManeger.Instance.currentLevel].transform.DOMove(currentpos, 0.5f);
                farms[LevelManeger.Instance.currentLevel].transform.DOScale(Vector3.one, 0.5f);

            }
            else
            {
                ileriButton.transform.DOShakePosition(0.5f, 15f, 15, 90f);
            }
            buttonLock = false;
            StartCoroutine(Buttonlock());
        }
    }
    public void GeriButton()
    {
        if (buttonLock)
        {
            if (LevelManeger.Instance.currentLevel > 0)
            {
                Vector3 pos = ileriButton.GetComponent<RectTransform>().position;
                Vector3 currentpos = farms[LevelManeger.Instance.currentLevel].transform.position;
                farms[LevelManeger.Instance.currentLevel].transform.DOMove(pos, 0.5f);
                farms[LevelManeger.Instance.currentLevel].transform.DOScale(Vector3.zero, 0.5f);
                LevelManeger.Instance.currentLevel--;
                farms[LevelManeger.Instance.currentLevel].transform.DOMove(currentpos, 0.5f);
                farms[LevelManeger.Instance.currentLevel].transform.DOScale(Vector3.one, 0.5f);

            }
            else
            {
                geriButton.transform.DOShakePosition(0.5f, 15f, 15, 90f);
            }
            buttonLock = false;
            StartCoroutine(Buttonlock());
        }
    }
    IEnumerator Buttonlock()
    {
        yield return new WaitForSeconds(0.5f);
        buttonLock = true;
    }
    public void TarlaEk(int TarlaNo,int TimeSecond,int getiri,int tohumMinus)
    {
        if (!farms[TarlaNo].GetComponent<TarlaP>().clockTarlaScrpt.ekili)
        {
            farms[TarlaNo].GetComponent<TarlaP>().ToprakSpriteChange(3);
            farms[TarlaNo].GetComponent<TarlaP>().StartTime(TimeSecond  * 60, getiri);
            Tohum.Instance.TohumMinus(tohumMinus);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
