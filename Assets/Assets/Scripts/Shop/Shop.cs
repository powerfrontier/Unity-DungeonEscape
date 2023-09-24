using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopPanel;

    private int _currentItemSelected;

    Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if (player != null)
            {
                UIManager.Instance.OpenShop(player.Gems);
            }
            _shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        // 0: Flame sword
        // 1: Boots of Flight
        // 2: Key to Castle
        Debug.Log("Button press: " + item);
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(28);
                _currentItemSelected = 0;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-79);
                _currentItemSelected = 1;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-178);
                _currentItemSelected = 2;
                break;
        }
    }

    public void BuyItem()
    {
        int cost = UIManager.Instance.GetCost(_currentItemSelected);
        
        if (cost <=  player.Gems)
        {
            player.Gems -= cost;
            UIManager.Instance.OpenShop(player.Gems);
            Debug.Log("Item " + _currentItemSelected + "Purchased!");
        }
        else
        {
            Debug.Log("Item " + _currentItemSelected + "not enought gems");
        }
    }

    
}
