using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DilPanel : MonoBehaviour
{
    [SerializeField] List<Sprite> buttonStorklu;
    [SerializeField] List<Sprite> buttonStroksuz;
    [SerializeField] List<Image> button;

    [SerializeField] List<Sprite> logoSpirite;
    [SerializeField] Image logo;
    // Start is called before the first frame update
    void Start()
    {
        SelectLang(PlayerPrefs.GetInt("DilNo", 0));
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelectLang(int LangNo)
    {
        for (int i = 0; i < button.Count; i++)
        {

            button[i].sprite = buttonStroksuz[i];
            button[i].SetNativeSize();
        }
        button[LangNo].sprite = buttonStorklu[LangNo];
        button[LangNo].SetNativeSize();
        logo.sprite = logoSpirite[LangNo];
        logo.SetNativeSize();
        PlayerPrefs.SetInt("DilNo", LangNo);
    }
}
