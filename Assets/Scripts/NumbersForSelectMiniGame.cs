using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NumbersForSelectMiniGame : MonoBehaviour
{
   
    [SerializeField] private List<GameObject> numbers;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private List<GameObject> generatedPrefabs = new List<GameObject>();
    
    
    // private int counter = 0;
    private int indexofNumberToLearn;
    private System.Random rand = new System.Random();
    List<GameObject> tempList = new List<GameObject>();
   // private List<int> randomIntegers;
    private int numberToLearn;
    

    private void OnEnable()
    {
        
        GameManager.instance.clickedNumber += SpawnNumbers;
        GameManager.instance.nextMiniGame += DestroyNumber;
    }

    private void OnDisable()
    {
        GameManager.instance.clickedNumber -= SpawnNumbers;
        GameManager.instance.nextMiniGame += DestroyNumber;
    }

    private void Start()
    {
        //numberToLearn = GameManager.instance.GetNumber();
        SettingGameObjectsInList();       
        ShuffleSpawnPoints();
        
        //Debug.Log(numbers[indexofNumberToLearn].GetComponent<Numbers>().GetNumber());

        
    }

  

    void SettingGameObjectsInList()
    {
        numbers = new List<GameObject>();

        foreach (var item in Resources.LoadAll<GameObject>("Prefabs"))
        {
            numbers.Add(item);
        }

        //numbers.Add(GetNumbersGameObjects("One"));
        //numbers.Add(GetNumbersGameObjects("Two"));
        //numbers.Add(GetNumbersGameObjects("Three"));
        //numbers.Add(GetNumbersGameObjects("Four"));
    }

    //GameObject GetNumbersGameObjects(string path)
    //{
    //    var number = Resources.Load(path, (typeof(GameObject))) as GameObject;
    //    return number;
    //}

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
        //Debug.Log("EnteredSpawnning-Method");
        FindingIndex(number);
        for (int i = 0; i < spawnPoints.Length / 2; i++)
        {

            //counter++;
            //Debug.Log("Entered First loop to spawn " + number);
            //Debug.Log("number to learn" + indexofNumberToLearn);
            GameObject temp = Instantiate(numbers[indexofNumberToLearn], spawnPoints[i].transform.position, Quaternion.identity);
            generatedPrefabs.Add(temp);
            //Debug.Log(tempIndexNumber);
            //Debug.Log(i);    
        }

        for (int j = spawnPoints.Length - spawnPoints.Length / 2; j < spawnPoints.Length; j++)
        {
            int tempIndex = GetRandomIndexForNumbers();
            // Debug.Log("ForLoopStarted" + j);
            GameObject temp = Instantiate(tempList[tempIndex], spawnPoints[j].transform.position, Quaternion.identity);
            generatedPrefabs.Add(temp);
        }

    }
    void DestroyNumber(bool nextGame)
    {
        foreach (var item in generatedPrefabs)
        {
            if(item != null)
            {
                Destroy(item);
            }
        }
        GameManager.instance.SetGameObjectSecondActive(true);
        GameManager.instance.SetGameObjectFirstActive(false);
        
        
    }

   
  

   

    void ShuffleSpawnPoints()
    {
        int n = spawnPoints.Length;
        while (n>1)
        {
            n--;
            int k = rand.Next(n + 1);
            var temp = spawnPoints[k];
            spawnPoints[k] = spawnPoints[n];
            spawnPoints[n] = temp;
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
