using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MeyvePanel : MonoBehaviour
{
    public RectTransform meyvePanel;
    public Button OpenButton;
    bool isOpen = false;
    bool delay = true;
    public TarlaManager tarlaManager;
    public List<RectTransform> BolgeMeyveleri;
    // Start is called before the first frame update
    void Start()
    {
        PanelGecisAnim();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PanelOpenOrClose()
    {
        OpenButton.enabled = false;
        if (isOpen)
        {
            OpenButton.transform.DOScaleY(1f, 0.5f);
            meyvePanel.DOAnchorPosY(-620f, 0.5f).OnComplete(() =>
            {
                OpenButton.enabled = true;
            });
            isOpen = !isOpen;
            print("kapa");
        }
        else
        {
            OpenButton.transform.DOScaleY(-1f, 0.5f);
            meyvePanel.DOAnchorPosY(0f, 0.5f).OnComplete(() =>
            {
                OpenButton.enabled = true;
            });
            isOpen = !isOpen;
            print("ac");
        }
    }

    public void IleriPanel()
    {
        PanelGecisAnim();
    }
    public void GeriPanel()
    {
        PanelGecisAnim();
    }
    public void PanelGecisAnim()
    {
        if (delay)
        {
            meyvePanel.DOAnchorPosY(-900f, 0.25f).OnComplete(() =>
            {
                int current = LevelManeger.Instance.currentLevel;
                BolgeMeyveleriPos(current);
                if (tarlaManager.farms[current].GetComponent<TarlaP>().lockBool)
                    meyvePanel.DOAnchorPosY(-620f, 0.25f);
            });
            delay = false;

        }
        StartCoroutine(Delay());
    }
    void BolgeMeyveleriPos(int Index)
    {
        for (int i = 0; i < BolgeMeyveleri.Count; i++)
        {
            BolgeMeyveleri[i].DOAnchorPosY(-1000, 0);
        }
        BolgeMeyveleri[Index].DOAnchorPosY(0, 0);
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        delay = true; ;
    }

}
