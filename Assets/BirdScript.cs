using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    public GameObject wingUp;
    public GameObject wingDown;
    public float visibilityDuration = 1f;
    private bool isSpacePressed = false;
    private float visibilityTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
        gameObject.name = "Robert Parrot";
    }

    // Update is called once per frame
    void Update()
    {
        // bird jump when we click space button
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * jumpStrength;
            isSpacePressed = true;
            
            SetWingVisibility(wingDown, true);
            SetWingVisibility(wingUp, false);
        }

        if (isSpacePressed)
        {
            if (visibilityTimer >= visibilityDuration)
            {
                SetWingVisibility(wingUp, true);
                SetWingVisibility(wingDown, false);
                isSpacePressed = false;
                visibilityTimer = 0f;
            }
            else visibilityTimer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("Highscore", 0);
            PlayerPrefs.Save();
            Debug.Log("Zresetowano Highscore na 0.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    private void SetWingVisibility(GameObject wingObject, bool isVisible)
    {
        wingObject.SetActive(isVisible);
    }
}
