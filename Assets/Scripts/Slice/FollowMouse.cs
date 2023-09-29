using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    private Transform objeTransform;
    public bool tasinmaModu = false;
    public float trailTime;
    public bool IsLocked;
    void Start()
    {
        objeTransform = transform;
    }

    void Update()
    {
        if (IsLocked) return;

        if (Input.GetMouseButtonDown(0))
        {
            Follow();
            GetComponent<TrailRenderer>().enabled = true;
            GetComponent<TrailRenderer>().time = trailTime;

        }
        if (tasinmaModu)
        {
            Follow();
        }
        if (tasinmaModu && Input.GetMouseButtonUp(0))
        {
            StartCoroutine(TrailEnableFalse());
            
        }
    }
    IEnumerator TrailEnableFalse()
    {
        yield return new WaitForSeconds(trailTime);
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().time = 0.0f;
    }
    void Follow()
    {
        Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D isinVurusu;
        Debug.Log("raycast 1 ");
        isinVurusu = Physics2D.Raycast(origin, Vector2.zero);
        if (isinVurusu.collider != null)
        {
            Vector3 hedefNokta = isinVurusu.point;
            objeTransform.position = hedefNokta;
            tasinmaModu = true;
        }
    }

}
