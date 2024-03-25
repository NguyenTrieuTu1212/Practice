using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyManager : MonoBehaviour
{
    [SerializeField] private GameObject enermyPrefabs;
    [SerializeField] private Transform pool;
    [SerializeField] private Vector2 rangeArea;


    private void Awake()
    {
        for(int i = 0; i < 100; i++)
        {
            GameObject enermy = Instantiate(enermyPrefabs, pool);
            float posX = Random.Range(- rangeArea.x, rangeArea.x) * 10f;
            float posY = Random.Range(- rangeArea.y, rangeArea.y) * 10f;
            enermy.transform.position = new Vector3(posX,posY,0);
        }
    }

    private void Update()
    {
        if (pool.childCount == 100)
        {
            Debug.Log(pool.childCount);
            return;
        }
        Instantiate(enermyPrefabs, pool);   
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, rangeArea * 10f);
    }
}
