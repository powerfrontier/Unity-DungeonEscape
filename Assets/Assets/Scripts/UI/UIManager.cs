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

    [SerializeField]
    private TextMeshProUGUI _flameSwordPrice;
    [SerializeField]
    private TextMeshProUGUI _bootsOfFlightPrice;
    [SerializeField]
    private TextMeshProUGUI _keyToCastlePrice;

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

    public int GetCost(int item)
    {
        int cost = 0;

        switch (item)
        {
            case 0:
                cost = int.Parse(_flameSwordPrice.text.Remove(_flameSwordPrice.text.Length-1));
                break;
            case 1:
                cost = int.Parse(_bootsOfFlightPrice.text.Remove(_bootsOfFlightPrice.text.Length-1));
                break;
            case 2:
                cost = int.Parse(_keyToCastlePrice.text.Remove(_keyToCastlePrice.text.Length-1));
                break;
        }

        return cost;
    }
}
