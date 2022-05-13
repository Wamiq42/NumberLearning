using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NumbersForSelectMiniGame : MonoBehaviour
{




    //public NumbersForSelectMiniGame()
    //{
    //    //SettingGameObjectsInList();
    //    //ShuffleTransformArray(base.spawnPoints);
    //    //ShuffleTransformArray(base.positions);

    //}
    //private void OnEnable()
    //{
    //    SettingGameObjectsInList();
    //    ShuffleTransformArray(base.spawnPoints);
    //    ShuffleTransformArray(base.positions);
    //}



    //public void SpawnNumbers(int number)
    //{
    //    FindingIndex(number);
    //    for (int i = 0; i < spawnPoints.Count / 2; i++)
    //    {

    //        //counter++;
    //        //Debug.Log("Entered First loop to spawn " + number);
    //        //Debug.Log("number to learn" + indexofNumberToLearn);
    //        GameObject temp = Instantiate(numbers[indexofNumberToLearn], spawnPoints[i].transform.position, Quaternion.identity);
    //        temp.GetComponent<Numbers>().MoveToPosition(spawnPoints[i].position, positions[i].position);
    //        temp.transform.SetParent(positions[i]);
    //        generatedPrefabs.Add(temp);
    //        //Debug.Log(tempIndexNumber);
    //        //Debug.Log(i);    
    //    }

    //    for (int j = spawnPoints.Count - spawnPoints.Count / 2; j < spawnPoints.Count; j++)
    //    {
    //        int tempIndex = GetRandomIndexForNumbers();
    //        // Debug.Log("ForLoopStarted" + j);
    //        GameObject temp = Instantiate(tempList[tempIndex], spawnPoints[j].transform.position, Quaternion.identity);
    //        temp.GetComponent<Numbers>().MoveToPosition(spawnPoints[j].position, positions[j].position);
    //        temp.transform.SetParent(positions[j]);
    //        generatedPrefabs.Add(temp);
    //    }
    //}






































    [SerializeField] private List<GameObject> numbers;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<Transform> positions;
    [SerializeField] private List<GameObject> generatedPrefabs = new List<GameObject>();


    // private int counter = 0;
    private int indexofNumberToLearn;
    private System.Random rand = new System.Random();
    List<GameObject> tempList = new List<GameObject>();
    private List<int> randomIntegers;


    private void OnEnable()
    {

        //GameManager.instance.clickedNumber += SpawnNumbers;
        GameManager.instance.nextMiniGame += DestroyNumber;
        SettingGameObjectsInList();
        spawnPoints = ShuffleTransformArray(spawnPoints);
        positions = ShuffleTransformArray(positions);
        SpawnNumbers(GameManager.instance.numberToLearn);
    }

    private void OnDisable()
    {
        //GameManager.instance.clickedNumber -= SpawnNumbers;
        GameManager.instance.nextMiniGame = DestroyNumber;
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

    }

    void SpawnNumbers(int number)
    {

        FindingIndex(number);
        for (int i = 0; i < spawnPoints.Count / 2; i++)
        {

            //counter++;
            //Debug.Log("Entered First loop to spawn " + number);
            //Debug.Log("number to learn" + indexofNumberToLearn);
            GameObject temp = Instantiate(numbers[indexofNumberToLearn], spawnPoints[i].transform.position, Quaternion.identity);
            temp.GetComponent<Numbers>().MoveToPosition(spawnPoints[i].position, positions[i].position);
            temp.transform.SetParent(positions[i]);
            generatedPrefabs.Add(temp);
            //Debug.Log(tempIndexNumber);
            //Debug.Log(i);    
        }

        for (int j = spawnPoints.Count - spawnPoints.Count / 2; j < spawnPoints.Count; j++)
        {
            int tempIndex = GetRandomIndexForNumbers();
            // Debug.Log("ForLoopStarted" + j);
            GameObject temp = Instantiate(tempList[tempIndex], spawnPoints[j].transform.position, Quaternion.identity);
            temp.GetComponent<Numbers>().MoveToPosition(spawnPoints[j].position, positions[j].position);
            temp.transform.SetParent(positions[j]);
            generatedPrefabs.Add(temp);
        }

    }
    void DestroyNumber(bool nextGame)
    {
        foreach (var item in generatedPrefabs)
        {
            if (item != null)
            {
                Destroy(item);
            }
        }
        Debug.Log("Deleted All Objects Level 1");
    }









    List<Transform> ShuffleTransformArray(List<Transform> transforms)
    {
        int n = transforms.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            var temp = transforms[k];
            transforms[k] = transforms[n];
            transforms[n] = temp;
        }
        return transforms;
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
