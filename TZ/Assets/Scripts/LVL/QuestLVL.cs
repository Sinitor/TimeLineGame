using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestLVL : MonoBehaviour
{
    public static List<int> questGame = new List<int> { 0, 0, 0, 0 };
    private List<int> currentGame = new List<int> { 1, 2, 3, 4 };
    [SerializeField] private Sprite pressPlate;
    [SerializeField] private Sprite plate;
    [SerializeField] private SpriteRenderer[] sr;
    [SerializeField] private GameObject openDoor;
    [SerializeField] private GameObject door;


    private void Update() //Checking pressing plates
    {
        if (questGame.SequenceEqual(currentGame))
        {
            door.gameObject.SetActive(false);
            openDoor.gameObject.SetActive(true);
        }
        if (sr[0].sprite == pressPlate && sr[1].sprite == pressPlate && sr[2].sprite == pressPlate && sr[3].sprite == pressPlate)
        {
            for (int i = 0; i < 4; i++)
            {
                sr[i].sprite = plate;
            }
            RunePlate.number = 0; 
            questGame = new List<int> { 0, 0, 0, 0 };
        }
    }
}
