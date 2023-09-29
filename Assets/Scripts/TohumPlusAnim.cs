using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
public class TohumPlusAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator CreateTohumSpriteAnim()
    {
        gameObject.transform.DOScale(new Vector3(1, 1, 1), 0.25f);
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.DOScale(new Vector3(0, 0, 0), 0.25f);
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
