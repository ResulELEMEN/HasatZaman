using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Oyunu kapatmak i�in bir butona t�klan�rsa bu fonksiyon �a�r�l�r.
    public void KapatOyun()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
