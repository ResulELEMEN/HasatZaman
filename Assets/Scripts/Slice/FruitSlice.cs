using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSlice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D isinVurusu;
            isinVurusu = Physics2D.Raycast(origin, Vector2.zero);
            if (isinVurusu.collider.gameObject.GetComponent<Fruit>())
            {
                isinVurusu.collider.gameObject.GetComponent<Fruit>().Hitting(); 
            }
        }
    }

}
