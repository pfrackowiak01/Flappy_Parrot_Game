using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdScript bird;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
        bird = GameObject.FindWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && bird.birdIsAlive)
        {
            logic.addScore(1);
        }

    }
}
