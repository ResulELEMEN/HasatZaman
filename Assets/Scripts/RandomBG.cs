using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBG : MonoBehaviour
{
    public List<Sprite> spriteBG;
    // Start is called before the first frame update
    private void Awake()
    {
        RandomBgFonk();
        
    }
    void RandomBgFonk()
    {
        gameObject.GetComponent<Image>().sprite = spriteBG[(Random.Range(0, spriteBG.Count))];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
