using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private static BulletManager instance;
    public static BulletManager Instance => instance;

    [SerializeField] private Transform container;
    [SerializeField] private List<Bullet> bulletList = new List<Bullet>();

    private Queue<Bullet> bulletActiveQueue = new Queue<Bullet>();    

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in your game !!! instance has removed");
            return;
        }
        instance = this;
        AddPrefabs();
        Prepare();
    }




    private void AddPrefabs()
    {
        Transform objPrefabs = transform.Find("Prefabs");
        if (objPrefabs == null) return;
        foreach (Transform child in objPrefabs)
        {
            bulletList.Add(child.gameObject.GetComponent<Bullet>());    
        }
        HidePrefabs();
    }


    private void HidePrefabs()
    {
        foreach(Bullet bullet in bulletList)
        {
            bullet.gameObject.SetActive(false);
        }
    }

    private void Prepare()
    {
        for(int i = 0; i < 10; i++)
        {
            Bullet bullet = Instantiate(bulletList[0], container);
            bullet.gameObject.SetActive(false);
            bulletActiveQueue.Enqueue(bullet);
        }
    }

    public Bullet TakeBullet(Vector3 posSpawn)
    {
        if(bulletActiveQueue.Count <= 0) Prepare();
        Bullet bullet = bulletActiveQueue.Dequeue();
        bullet.gameObject.SetActive(true);
        bullet.gameObject.transform.position = posSpawn;
        return bullet;
    }


    public void ReturnBulletInQueue(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletActiveQueue.Enqueue(bullet);
        
    }
}
