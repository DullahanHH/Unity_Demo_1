using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int splitCannonPrice = 100;
    public int lifePrice = 500;

    public Text splitPriceText;
    public GameObject item0_Btn;
    public Text lifePriceText;

    private int coinOwn;
    private int lifeOwn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinOwn = FindObjectOfType<Player>().coinTotal;
        lifeOwn = FindObjectOfType<Player>().health;

        splitPriceText.text = splitCannonPrice.ToString();
        lifePriceText.text = lifePrice.ToString();
    }

    public void SplitCannonPurchase()
    {

        if (coinOwn >= splitCannonPrice)
        {
            FindObjectOfType<Player>().coinTotal = coinOwn - splitCannonPrice;
            FindObjectOfType<Player>().weaponType = "Split";
            item0_Btn.SetActive(false);

        } else
        {
            Debug.Log("Not enough coins!");
        }
    }

    public void LifePurchase()
    {

        if (coinOwn >= lifePrice && lifeOwn != 3)
        {
            FindObjectOfType<Player>().coinTotal = coinOwn - lifePrice;
            FindObjectOfType<Player>().health++;
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

}
