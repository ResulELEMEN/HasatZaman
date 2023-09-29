using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrailManeger : MonoBehaviour
{
    public List<FollowMouse> Trails;
    int hamle;
    int mod;
    int previouslyIndex = -1;

    private void Start()
    {
        LockStart();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            IsLockManeger();
        }
    }
    void IsLockManeger()
    {
        int index=hamle%mod;
        Trails[index].IsLocked = true;
        Trails[index].tasinmaModu = false;
        hamle++;
        index = hamle % mod;
        Trails[index].IsLocked = false;
        Trails[index].tasinmaModu = true;

    }
    void LockStart()
    {
        hamle = 0;
        mod = Trails.Count;
        Trails[0].IsLocked = false;
        Trails[0].tasinmaModu = true;
        for (int i = 1;i<Trails.Count;i++)
        {
            Trails[i].IsLocked = true;
            Trails[i].tasinmaModu = false;
        }
    }
    public void Get()
    {
        if (previouslyIndex != -1)
        {
            Trails[previouslyIndex].IsLocked = true;
        }
        hamle++;
        mod = hamle % Trails.Count;
        previouslyIndex = mod;
        Trails[mod].IsLocked = false;
    }

   

}
