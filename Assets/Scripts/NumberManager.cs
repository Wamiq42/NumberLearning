using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberManager : MonoBehaviour
{
    [SerializeField] protected List<GameObject> numbers;
    [SerializeField] protected int indexOfNumberToLearn;

    [SerializeField] protected List<Transform> spawnPoints;
    [SerializeField] protected List<Transform> positions;

    private System.Random rand = new System.Random();

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
                indexOfNumberToLearn = numbers.IndexOf(item);
            }
        }

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
}
