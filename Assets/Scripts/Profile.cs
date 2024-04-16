using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Profile : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _percentText;

    // Start is called before the first frame update
    void OnEnable()
    {
        //_percentText.text = $"{GameManager.Instance.CalculateTotalPercent().ToString()}%";
        if(float.IsNaN(GameManager.Instance.CalculateTotalPercent()))
        { 
            _percentText.text= "0%"; 
        }
        else
        {
            _percentText.text = $"{((int)GameManager.Instance.CalculateTotalPercent()).ToString()}%";
        }
    }
}
