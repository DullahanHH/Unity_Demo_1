using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text coinText;
    public Image[] lifeList = new Image[3];

    public Text minText;
    public Text secText;
    public Text ColdDownText;

    public void Start()
    {
        
    }


    public void Update()
    {
        int coin_player = FindObjectOfType<Player>().coinTotal;     //coins that player currently have
        int life_player = FindObjectOfType<Player>().health;        //player's current health

        coinText.text = "COIN: " + coin_player;     //display coin's number on coinText

        for (int i = 0; i < 3; i++)     //show health state based on current health
        {
            if (i < life_player)
            {
                lifeList[i].enabled = true;
            } else
            {
                lifeList[i].enabled = false;
            }
        }

        minText.text = FindObjectOfType<GameManager>().getMin();
        secText.text = FindObjectOfType<GameManager>().getSec();

        ColdDownText.text = FindObjectOfType<Player>().getColdDownCounting();

        ColorChange();
    }

    private void ColorChange()
    {
        if (!ColdDownText.text.Equals("00"))
        {
            ColdDownText.color = Color.red;
        } else
        {
            ColdDownText.color = Color.white;
        }
    }
}
