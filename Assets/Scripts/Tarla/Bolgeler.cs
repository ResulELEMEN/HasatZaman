using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bolgeler : MonoBehaviour
{
    [SerializeField] List<GameObject> bolgeler;
    [SerializeField] List<RectTransform> bolge_TR;
    [SerializeField] List<RectTransform> bolge_EN;
    [SerializeField] List<RectTransform> bolge_ARB;
    List<RectTransform> bolge_Now;
    int dil;
    [SerializeField] RectTransform up;
    [SerializeField] RectTransform down;
    bool delay=true;
    [SerializeField] MeyvePanel meyvePanel;
    // Start is called before the first frame update
    int index;
    void Start()
    {
        OpenBolge();
        FirstAnim();
    }
    void OpenBolge()
    {
        dil = PlayerPrefs.GetInt("DilNo");
        bolgeler[dil].SetActive(true);
        switch (dil)
        {
            case 0:
                bolge_Now = bolge_TR; break;
            case 1:
                bolge_Now = bolge_EN; break;
            case 2:
                bolge_Now = bolge_ARB; break;
            default:
                break;
        }
    }
    public void FirstAnim()
    {
        bolge_Now[LevelManeger.Instance.currentLevel].transform.DOMove(down.position, 0.25f);
    }
    public void IleriBolge()
    {
        int current = LevelManeger.Instance.currentLevel;
        if (current<bolge_Now.Count-1 && delay)
        {
            meyvePanel.IleriPanel();
            delay = false;
            bolge_Now[current].DOMove(up.position, 0.25f).OnComplete(() =>
            {
                bolge_Now[current+1].DOMove(down.position, 0.25f);
            });
        }
        StartCoroutine(Delay());
    }
    public  void GeriBolge()
    {
        int current = LevelManeger.Instance.currentLevel;
        if (current > 0 && delay)
        {
            delay=false;
            meyvePanel.IleriPanel();
            bolge_Now[current ].DOMove(up.position, 0.25f).OnComplete(() =>
            {
                bolge_Now[current-1].DOMove(down.position, 0.25f);
            });
        }
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        delay = true; ;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
