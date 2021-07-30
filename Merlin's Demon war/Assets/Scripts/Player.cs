using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image playerImage = null;
    public Image mirrorImage = null;
    public Image healthImage = null;
    public Image glowImage = null;

    public int health = 5;
    public int mana = 1;
    public bool isPlayer;
    public bool isFire;

    public GameObject[] manaballs = new GameObject[5];
    private Animator animator = null; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    internal void playHitAnime()
    {
        if(animator != null)
        {
            animator.SetTrigger("hit");
        }
    }
}
