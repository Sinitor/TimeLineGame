using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePlate : MonoBehaviour
{
    [SerializeField] private Sprite pressPlate;
    [SerializeField] private Sprite plate;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private int count;
    public static int number = 0;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player" && sr.sprite == plate)
        {
            sr.sprite = pressPlate;
            QuestLVL.questGame[number] = count;
            number++;
        }
        else if (collision.gameObject.tag == "Player" && sr.sprite == pressPlate)
        {
            sr.sprite = plate;
            QuestLVL.questGame[number] = 0;
            number--;
        }
    }
}
