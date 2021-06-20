using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int splitCannonPrice = 100;
    public int lifePrice = 500;
    public int skillFlashPrice = 250;

    public Text splitPriceText;
    public Text lifePriceText;
    public Text skillFlashText;

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
        skillFlashText.text = skillFlashPrice.ToString();
    }

    public void SplitCannonPurchase()
    {

        if (coinOwn >= splitCannonPrice)
        {
            FindObjectOfType<Player>().coinTotal = coinOwn - splitCannonPrice;
            FindObjectOfType<Player>().weaponType = "Split";
        } else
        {
            Debug.Log("Not enough coins!");
        }
    }

    public void LifePurchase()
    {

        if (coinOwn >= lifePrice && lifeOwn < 3)
        {
            FindObjectOfType<Player>().coinTotal = coinOwn - lifePrice;
            FindObjectOfType<Player>().health++;
        }
        else if (lifeOwn >=3)
        {
            Debug.Log("Your health is full!");
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    public void SkillFlashPurchase()
    {
        if (coinOwn >= skillFlashPrice)
        {
            FindObjectOfType<Player>().coinTotal = coinOwn - skillFlashPrice;
            FindObjectOfType<Player>().isSkillFlashPurchase = true;
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}
