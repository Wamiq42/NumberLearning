using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FindTheNumber : MonoBehaviour
{
    [SerializeField] private List<GameObject> numbers;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<Transform> positions;

    [SerializeField] private List<GameObject> generatedPrefabs = new List<GameObject>();
    private int indexofNumberToLearn;
    private List<GameObject> tempList = new List<GameObject>();


    void OnEnable()
    {
        SettingGameObjectsInList();
        SpawnNumbers(GameManager.instance.numberToLearn);


    }

   

    void SettingGameObjectsInList()
    {
        numbers = new List<GameObject>();

        foreach (var item in Resources.LoadAll<GameObject>("Prefabs"))
        {
            numbers.Add(item);
        }
    }

    void FindingIndex(int number)
    {
        foreach (var item in numbers)
        {
            if (item.GetComponent<Numbers>().GetNumber() == number)
            {
                indexofNumberToLearn = numbers.IndexOf(item);
            }
        }
        //Debug.Log(indexofNumberToLearn);
    }
    void SpawnNumbers(int number)
    {
        FindingIndex(number);
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            GameObject temp = Instantiate(numbers[indexofNumberToLearn], spawnPoints[i].position, Quaternion.identity);
            temp.GetComponent<Numbers>().MoveToPosition(spawnPoints[i].position, positions[i].position);
            tempList.Add(temp);
        }
       
    }
}
