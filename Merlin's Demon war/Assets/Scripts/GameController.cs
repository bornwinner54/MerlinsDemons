using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static public GameController instance;
    public Sprite[] healthImage = new Sprite[10];
    public Sprite[] damageImage = new Sprite[10];
    public Deck playerDeck = new Deck();
    public Deck EnemyDeck = new Deck();
    public List<CardData> cards = new List<CardData>();

    public Hand playerHand = new Hand();
    public Hand enemyHand = new Hand();

    public GameObject cardPrefab = null;
    public Canvas canvas = null;

    private void Awake() 
    {
       // Debug.Log("In Awake");
        instance = this;
        playerDeck.create();
        EnemyDeck.create();

        StartCoroutine(dealHand());
    }
    public void quit()
    {
        SceneManager.LoadScene(0); 
    }

    public void skipTurn()
    {
        Debug.Log("Skip Turn");//finish this code 
    }

    internal IEnumerator dealHand()
    {
        yield return new WaitForSeconds(1);
        for(int t=0; t<3;t++)
        {
            playerDeck.dealCard(playerHand);
            EnemyDeck.dealCard(enemyHand);
            yield return new WaitForSeconds(1);
        }
    }
}
