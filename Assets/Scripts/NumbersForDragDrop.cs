using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NumbersForDragDrop : MonoBehaviour
{
    [SerializeField] private List<GameObject> numbers;
    [SerializeField] private List<Transform> spawnTransforms;

    private System.Random rand = new System.Random();
    private int indexofNumberToLearn;
    private List<GameObject> tempList = new List<GameObject>();

   

    private void OnDisable()
    {
        GameManager.instance.clickedNumber -= SpawnNumbers;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.clickedNumber += SpawnNumbers;
        SettingGameObjectsInList();
        ShuffleSpawnPoints();
        SpawnNumbers(GameManager.instance.GetNumber());
    }


    void SpawnNumbers(int number)
    {
        FindingIndex(number);
        for (int i = 0; i < spawnTransforms.Count; i++)
        {
            if (i == 0)
            {
                
                Instantiate(numbers[indexofNumberToLearn], spawnTransforms[i].position, Quaternion.identity);
                Debug.Log("Spawned number to learn" + number);
            }
            else
            {
                int tempIndex = GetRandomIndexForNumbers();
                
                Instantiate(tempList[tempIndex], spawnTransforms[i].transform.position, Quaternion.identity);
                Debug.Log("Spawned number to learn" + tempList[tempIndex].name);

            }
        }
       
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

    void ShuffleSpawnPoints()
    {
        int n = spawnTransforms.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            var temp = spawnTransforms[k];
            spawnTransforms[k] = spawnTransforms[n];
            spawnTransforms[n] = temp;
        }
    }
    int GetRandomIndexForNumbers()
    {
        int randomIndex;
        if (indexofNumberToLearn == 0)
        {
            tempList.Add(numbers[indexofNumberToLearn + 2]);
            tempList.Add(numbers[indexofNumberToLearn + 1]);
            randomIndex = rand.Next(tempList.Count);
        }
        else if (indexofNumberToLearn == numbers.Count - 1)
        {
            tempList.Add(numbers[indexofNumberToLearn - 2]);
            tempList.Add(numbers[indexofNumberToLearn - 1]);
            randomIndex = rand.Next(tempList.Count);
        }
        else
        {
            tempList.Add(numbers[indexofNumberToLearn - 1]);
            tempList.Add(numbers[indexofNumberToLearn + 1]);
            randomIndex = rand.Next(tempList.Count);
        }

        return randomIndex;
    }
    
}
