using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardData cardData = null;
    public Text titleText = null;
    public Text descText = null;
    public Image cardImage = null;
    public Image damageImage = null;
    public Image costImage = null;
    public Image frameImage = null;
    public Image burnImage = null;

    public void initialise()
    {
        if(cardData == null)
        {
            Debug.LogError("Card does not have data!");
            return;
        }

        titleText.text = cardData.cardTitle;
        descText.text = cardData.desc;
        cardImage.sprite = cardData.cardImage;
        frameImage.sprite = cardData.frameImage;
        costImage.sprite = GameController.instance.healthImage[cardData.cost];
        damageImage.sprite = GameController.instance.damageImage[cardData.damage];
    }
}
