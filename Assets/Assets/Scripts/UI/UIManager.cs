using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
           if (_instance == null)
           {
            Debug.LogError("UI Manager is null");
           } 
           return _instance;
        }
    }

    public TextMeshProUGUI playerGems;
    public Image selectionSlider;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gems)
    {
        playerGems.text = gems.ToString() + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionSlider.rectTransform.anchoredPosition = new Vector2(selectionSlider.rectTransform.anchoredPosition.x, yPos);
    }
}
