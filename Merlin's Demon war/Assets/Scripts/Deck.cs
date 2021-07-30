using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Deck 
{
    public List<CardData> cardDatas = new List<CardData>();

    public void create()
    {
        
        //fill in the oredered list
        List<CardData> cardDataInOrder = new List<CardData>();
        foreach(CardData cardData in GameController.instance.cards)
        {
            for(int i = 0;i<cardData.numberInDeck;i++)
             cardDataInOrder.Add(cardData);
            
        }
        //Debug.Log(cardDataInOrder.Count);

        //randomise
        while (cardDataInOrder.Count > 0)
        {

            int randomIndex = UnityEngine.Random.Range(0, cardDataInOrder.Count);
            cardDatas.Add(cardDataInOrder[randomIndex]);
            cardDataInOrder.RemoveAt(randomIndex);
            //Debug.Log(cardDataInOrder.Count);
        }

    }
    private CardData randomCard()
    {
        CardData result = null;

        if (cardDatas.Count == 0)
        {
            create();
        }
        result = cardDatas[0];
        cardDatas.RemoveAt(0);
        return result;
    }

    private Card createNewCard(Vector3 position,string animeName)
    {
        GameObject newCard = GameObject.Instantiate(GameController.instance.cardPrefab,GameController.instance.canvas.gameObject.transform);
        newCard.transform.position = position;
        Card card = newCard.GetComponent<Card>();
        if(card)
        {
            card.cardData = randomCard();
            card.initialise();
            Animator animator = newCard.GetComponentInChildren<Animator>();
            if(animator)
            {
                animator.CrossFade(animeName, 0);
            }
            else 
            {
                Debug.LogError("No Animator found!");
            }
            return card;
        }
        else
        {
            Debug.LogError("No Card component found!");
            return null;
        }

    }

    internal void dealCard(Hand hand)
    {
        for(int h=0;h<3;h++)
        {
            if(hand.cards[h] == null)
            {
                hand.cards[h] = createNewCard(hand.positions[h].position, hand.animeName[h]);
                return;
            }
        }
    }
}
