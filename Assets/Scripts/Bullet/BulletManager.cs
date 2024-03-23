using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private static BulletManager instance;
    public static BulletManager Instance => instance;
    [SerializeField] private Transform pool;
    [SerializeField] private List<Bullet> listBullet = new List<Bullet>();
    private Queue<Bullet> queue = new Queue<Bullet>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than instance in your game !!!!");
            return;
        }
        instance = this;
        AddPrefabs();
        PrepareBullet();
    }


    private void AddPrefabs()
    {
        Transform objPrefabs = transform.Find("Prefabs");
        if (objPrefabs == null) return;
        foreach(Transform child in objPrefabs)
        {
            listBullet.Add(child.GetComponent<Bullet>());   
        }
        HidePrefabs();
       
    }



    private void HidePrefabs()
    {
        foreach(Bullet bullet in listBullet)
        {
            bullet.gameObject.SetActive(false);
        }
    }


   private void PrepareBullet()
   {
        for(int i = 0; i < 10; i++)
        {
            Bullet bullet = Instantiate(listBullet[0], pool);
            bullet.gameObject.SetActive(false);
            queue.Enqueue(bullet);
        }
   }



    public Bullet TakeBullet(Vector3 posSpawn,float rad)
    {
        if (queue.Count <= 0) PrepareBullet();
        Bullet bullet = queue.Dequeue();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = posSpawn;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, rad);
        return bullet;  
    }



    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.gameObject.transform.SetParent(pool);
        queue.Enqueue(bullet);

    }


}
