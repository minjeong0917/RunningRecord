using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeImg : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentLives == 3)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (playerHealth.currentLives == 2)
        {
            spriteRenderer.sprite = sprites[1];

        }
        else if (playerHealth.currentLives == 1)
        {
            spriteRenderer.sprite = sprites[2];

        }
        else if (playerHealth.currentLives == 0)
        {
            spriteRenderer.sprite = sprites[3];

        }
        else
        {
            spriteRenderer.sprite = sprites[0];

        }

    }
}