using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NumbersForDragDrop : MonoBehaviour
{
    [SerializeField] private List<GameObject> numbers;
    [SerializeField] private List<Transform> spawnTransforms;
    [SerializeField] private List<Transform> positions;
    [SerializeField] private List<GameObject> spawnedPrefabs = new List<GameObject>();


    private System.Random rand = new System.Random();
    private int indexofNumberToLearn;
    private List<GameObject> tempList = new List<GameObject>();


    private void Awake()
    {
        GameManager.instance.clickedNumber += SpawnNumbersDragAndDrop;
    }
    private void OnEnable()
    {
        
        
        GameManager.instance.counterAdded += DeleteSpawnedPrefabs;
        GameManager.instance.nextMiniGame += DeleteSpawnedPrefabs;
        SettingGameObjectsInList();
        spawnTransforms = ShuffleTransformArray(spawnTransforms);
        
        SpawnNumbersDragAndDrop(GameManager.instance.numberToLearn);
    }

    private void OnDisable()
    {

        GameManager.instance.counterAdded -= DeleteSpawnedPrefabs;
        GameManager.instance.nextMiniGame -= DeleteSpawnedPrefabs;

    }
  


    void SpawnNumbersDragAndDrop(int number)
    {
        Debug.Log(GameManager.instance.numberToLearn);
        positions = ShuffleTransformArray(positions);
        FindingIndex(number);
        for (int i = 0; i < spawnTransforms.Count; i++)
        {
            
            if (i == 0)
            {
                
               GameObject temp = Instantiate(numbers[indexofNumberToLearn], spawnTransforms[i].position, Quaternion.identity);
                temp.GetComponent<Numbers>().MoveToPosition(spawnTransforms[i].position, positions[i].position);
                temp.GetComponent<DragDropBehaviour>().SetLastPosition(positions[i].position);
                temp.transform.SetParent(positions[i]);
                spawnedPrefabs.Add(temp);
                //Debug.Log("Spawned number to learn" + number);
            }
            else
            {
                int tempIndex = GetRandomIndexForNumbers();
                
                GameObject temp =Instantiate(tempList[tempIndex], spawnTransforms[i].transform.position, Quaternion.identity);
                temp.transform.SetParent(positions[i]);
                temp.GetComponent<Numbers>().MoveToPosition(spawnTransforms[i].position, positions[i].position);
                temp.GetComponent<DragDropBehaviour>().SetLastPosition(positions[i].position);
                spawnedPrefabs.Add(temp);
                //Debug.Log("Spawned number to learn" + tempList[tempIndex].name);

            }
            //Debug.Log("Spawned Objects");
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
            SpawnNumbersDragAndDrop(GameManager.instance.numberToLearn);
        }
        Debug.Log("Deleted Second Level GameObjects");
    }
    void DeleteSpawnedPrefabs(bool nextGame)
    {
        
        foreach (var item in spawnedPrefabs)
        {
            Destroy(item);
        }
        Debug.Log("Deleted Second Level GameObjects after invoking nextgame delegate" );
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
