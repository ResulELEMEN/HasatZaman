using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
public class TohumPlusSprite : MonoBehaviour
{
    [SerializeField] List<GameObject> TohumSpirites;
     int index;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CreateTohumSprite(Transform trans,int plusUnit)
    {
    
        index = index % TohumSpirites.Count;
        string plusText = "+" + plusUnit.ToString();
        TohumSpirites[index].GetComponentInChildren<TextMeshProUGUI>().text = plusText;
        TohumSpirites[index].GetComponent<RectTransform>().transform.position = trans.position;
        TohumSpirites[index].transform.localScale = new Vector3 (0, 0, 0);
        TohumSpirites[index].SetActive (true);
        StartCoroutine(TohumSpirites[index].GetComponent<TohumPlusAnim>().CreateTohumSpriteAnim()); 
        index++;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
