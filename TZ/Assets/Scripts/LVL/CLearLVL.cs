using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLearLVL : MonoBehaviour
{
    public GameObject[] enemy = null;
    [SerializeField] private GameObject[] Door;

    private void Start()
    {
        StartCoroutine(Check());
    }
    IEnumerator Check()
    {
        yield return new WaitForSeconds(3);
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Repeat();
    } 
    private void Repeat()
    {
        if (enemy.Length != 0)
        {
            StartCoroutine(Check()); 
        }
        if (enemy.Length == 0)
        {
            Door[0].gameObject.SetActive(false);
            Door[1].gameObject.SetActive(true);
        }
    }
}
