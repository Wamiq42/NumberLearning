using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerateNumbers : MonoBehaviour
{
   
    [SerializeField] private List<GameObject> numbers;
    [SerializeField] private Transform[] spawnPoints;

    // private int counter = 0;
    private int indexofNumberToLearn;
    private System.Random rand = new System.Random();
    List<GameObject> tempList = new List<GameObject>();
    private List<int> randomIntegers;
    private int numberToLearn;

    private void Start()
    {
        numberToLearn = GameManager.instance.numberToLearn;
        SettingGameObjectsInList();
        FindingIndex();
        CreateRandomIntegerList();
        ShuffleRandomIntegerList();
        SpawnNumbers();
        //Debug.Log(numbers[indexofNumberToLearn].GetComponent<Numbers>().GetNumber());
    }

    GameObject GetNumbersGameObjects(string path)
    {
        var number = Resources.Load(path, (typeof(GameObject))) as GameObject;
        return number;
    }

    void SettingGameObjectsInList()
    {
        numbers = new List<GameObject>();
        numbers.Add(GetNumbersGameObjects("One"));
        numbers.Add(GetNumbersGameObjects("Two"));
        numbers.Add(GetNumbersGameObjects("Three"));
        numbers.Add(GetNumbersGameObjects("Four"));

       
    }
    void FindingIndex()
    {
        foreach (var item in numbers)
        {
            if (item.GetComponent<Numbers>().GetNumber() == numberToLearn)
            {
                indexofNumberToLearn = numbers.IndexOf(item);
            }
        }
        Debug.Log(indexofNumberToLearn);
    }

    void SpawnNumbers()
    {
        for (int i = 0; i < spawnPoints.Length / 2; i++)
        {

            //counter++;
            GameObject temp = Instantiate(numbers[indexofNumberToLearn], spawnPoints[i].transform.position, Quaternion.identity);

            //Debug.Log(tempIndexNumber);
            //Debug.Log(i);    
        }

        for (int j = spawnPoints.Length - 4; j < spawnPoints.Length; j++)
        {
            int tempIndex = GetRandomIndexForNumbers();
           // Debug.Log("ForLoopStarted" + j);
            GameObject temp = Instantiate(tempList[tempIndex], spawnPoints[j].transform.position, Quaternion.identity);
        }

    }

  

    void CreateRandomIntegerList()
    {
       
        randomIntegers = new List<int>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            randomIntegers.Add(i);
        }
       
    }

    void ShuffleRandomIntegerList()
    {
        int n = randomIntegers.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            var value = randomIntegers[k];
            randomIntegers[k] = randomIntegers[n];
            randomIntegers[n] = value;
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
        else if(indexofNumberToLearn == numbers.Count-1)
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
