using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    private GameObject Container;
    private bool _isDead = false;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    public void StartSpawning()
    {
        StartCoroutine(spawn());
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(3.0f);
        while (!_isDead)
        {
            Vector3 pos = new Vector3(Random.Range(-9.5f, 9.5f), 6, 0);
           GameObject enemy =  Instantiate(EnemyPrefab, pos, Quaternion.identity);
            enemy.transform.parent = Container.transform;
            yield return new WaitForSeconds(2.0f);
        }
    }

    public void stop_spawning()
    {
        _isDead = true;
    }
}
