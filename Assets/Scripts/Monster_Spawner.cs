using UnityEngine;

public class Monster_Spawner : MonoBehaviour
{
    public GameObject[] monsterPrefab;
    public float spawnInterval=2f;
    int random;
    void Start()
    {
        InvokeRepeating("SpawnMonster", 1f, spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        random=Random.Range(0,2);
    }

    void SpawnMonster()
    {
        float xPos=Random.Range(-2.3f,2.3f);
        Vector3 spawnPos=new Vector3(xPos,5.7f,0);
        Instantiate(monsterPrefab[random], spawnPos, Quaternion.identity);
    }
}
