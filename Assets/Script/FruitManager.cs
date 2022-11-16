using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitsPrefabs = default;

    private float posX = default;
    private float posZ = default;
    private int fruit = default;

    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("SpawnFruit",1f, 10);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnFruit()
    {
        posX = Random.Range(-7, 7);
        posZ = Random.Range(-7, 7);
        fruit = Random.Range(0, 2);
        Instantiate(fruitsPrefabs[fruit], new Vector3(posX, 3, posZ), Quaternion.identity);
    }
}
