using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberManager : MonoBehaviour
{
    [SerializeField] protected List<GameObject> numbers;
    [SerializeField] protected int indexofNumberToLearn;

    [SerializeField] protected List<Transform> spawnPoints;
    [SerializeField] protected List<Transform> positions;

    private System.Random rand = new System.Random();
    protected List<GameObject> generatedPrefabs = new List<GameObject>();
    protected List<GameObject> tempList = new List<GameObject>();

    protected void SettingGameObjectsInList()
    {
        numbers = new List<GameObject>();

        foreach (var item in Resources.LoadAll<GameObject>("Prefabs"))
        {
            numbers.Add(item);
        }

    }

    protected void FindingIndex(int number)
    {
        foreach (var item in numbers)
        {
            if (item.GetComponent<Numbers>().GetNumber() == number)
            {
                indexofNumberToLearn = numbers.IndexOf(item);
            }
        }

    }

    protected List<Transform> ShuffleTransformArray(List<Transform> transforms)
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
    protected int GetRandomIndexForNumbers()
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
