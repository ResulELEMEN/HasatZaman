using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public TarlaP Parent;
    private void Start()
    {
        
    }
    private void Update()
    {
     
    }
    private void OnMouseDown()
    {
        Parent.PayCost();
    }
    
}
