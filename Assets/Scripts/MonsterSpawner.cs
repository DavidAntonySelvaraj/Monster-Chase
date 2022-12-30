using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterReference;
    [SerializeField] private Transform leftPos, rightPos;
    private GameObject spawnedMonster;
    private int randomIndex, randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMonster()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            //left side
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 8);
                spawnedMonster.transform.position = new Vector3(leftPos.position.x, leftPos.position.y, 0f);
            }
            else//right side
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 8);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                spawnedMonster.transform.position = new Vector3(rightPos.position.x, rightPos.position.y, 0f);

            }
        }

    }
}//class











