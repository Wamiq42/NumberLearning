using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NumbersForDragDrop : MonoBehaviour
{
    [SerializeField] private List<GameObject> numbers;
    [SerializeField] private List<Transform> spawnTransforms;
    [SerializeField] private List<GameObject> spawnedPrefabs = new List<GameObject>();


    private System.Random rand = new System.Random();
    private int indexofNumberToLearn;
    private List<GameObject> tempList = new List<GameObject>();


    private void Awake()
    {
       // GameManager.instance.clickedNumber += SpawnNumbers;
    }
    private void OnEnable()
    {
        GameManager.instance.clickedNumber += SpawnNumbers;
        GameManager.instance.counterAdded += DeleteSpawnedPrefabs;
        GameManager.instance.nextMiniGame += DeleteSpawnedPrefabs;
    }

    private void OnDisable()
    {
        GameManager.instance.clickedNumber -= SpawnNumbers;
        GameManager.instance.counterAdded -= DeleteSpawnedPrefabs;
        GameManager.instance.nextMiniGame -= DeleteSpawnedPrefabs;

    }
    // Start is called before the first frame update
    void Start()
    {
       
        SettingGameObjectsInList();
        ShuffleSpawnPoints();
        //SpawnNumbers(GameManager.instance.GetNumberToLearn());

    }


    void SpawnNumbers(int number)
    {
        Debug.Log(GameManager.instance.numberToLearn);
        if (spawnedPrefabs != null)
        {
            Debug.Log("Deleting Prefabs");
          
        }
        FindingIndex(number);
        for (int i = 0; i < spawnTransforms.Count; i++)
        {
            
            if (i == 0)
            {
                
               GameObject temp = Instantiate(numbers[indexofNumberToLearn], spawnTransforms[i].position, Quaternion.identity);
                spawnedPrefabs.Add(temp);
                //Debug.Log("Spawned number to learn" + number);
            }
            else
            {
                int tempIndex = GetRandomIndexForNumbers();
                
                GameObject temp =Instantiate(tempList[tempIndex], spawnTransforms[i].transform.position, Quaternion.identity);
                spawnedPrefabs.Add(temp);
                //Debug.Log("Spawned number to learn" + tempList[tempIndex].name);

            }
            Debug.Log("Spawned Objects");
        }
       
    }
    void SpawnNumbers()
    {
        FindingIndex(GameManager.instance.numberToLearn);
        if (spawnedPrefabs != null)
        {
            Debug.Log("Deleting Prefabs" + " Overloaded Method without arguement");
            
        }
        for (int i = 0; i < spawnTransforms.Count; i++)
        {
            if (i == 0)
            {

                GameObject temp = Instantiate(numbers[indexofNumberToLearn], spawnTransforms[i].position, Quaternion.identity);
                temp.transform.SetParent(spawnTransforms[i]);
                spawnedPrefabs.Add(temp);
                //Debug.Log("Spawned number to learn" + number);
            }
            else
            {
                int tempIndex = GetRandomIndexForNumbers();

                GameObject temp = Instantiate(tempList[tempIndex], spawnTransforms[i].transform.position, Quaternion.identity);
                temp.transform.SetParent(spawnTransforms[i]);
                spawnedPrefabs.Add(temp);
                //Debug.Log("Spawned number to learn" + tempList[tempIndex].name);

            }
        }

    }

    void DeleteSpawnedPrefabs(int counter)
    {
        if (counter <=4)
        {
            Debug.Log(counter);
            foreach (var item in spawnedPrefabs)
            {
                Destroy(item);
            }
        }
        if(counter < 4)
        {
            SpawnNumbers();
        }

    }
    void DeleteSpawnedPrefabs(bool nextGame)
    {
        
        foreach (var item in spawnedPrefabs)
        {
            Destroy(item);
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
