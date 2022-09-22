using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandom : MonoBehaviour
{
    public ObjectColor color;
    [SerializeField] private Sprite[] spritesArray;
    [SerializeField] private int randomColor;
    [SerializeField] private SpriteRenderer render;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        randomColor = Random.Range(0, spritesArray.Length);
        switch(randomColor)
        {
            case 0:
                color = ObjectColor.Red;
                break;
            case 1:
                color = ObjectColor.Yellow;
                break;
            case 2:
                color = ObjectColor.Green;
                break;
        }
        render.sprite = spritesArray[randomColor];
    }
}
