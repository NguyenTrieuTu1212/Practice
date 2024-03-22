using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private static BulletManager instance; 
    public static BulletManager Instance => instance;
    [SerializeField] private Transform pool;
    [SerializeField] private List<Bullet> listBullet = new List<Bullet> ();
    private Queue<Bullet> queue = new Queue<Bullet> ();

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than instance in your game !!!!");
            instance = this;
        }
        instance = this;
        AddPrefabs();
    }



    private void AddPrefabs()
    {
        Transform objPrefabs = transform.Find("Prefabs");
        if (objPrefabs == null) return;
        foreach(Transform obj in objPrefabs)
        {
            listBullet.Add(obj.GetComponent<Bullet>());
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


    private void Prepare()
    {
        for(int i = 0; i < 10; i++)
        {
            Bullet bullet = Instantiate(listBullet[0], pool);
            bullet.gameObject.SetActive(false);
            queue.Enqueue(bullet);
        }
    }



    public Bullet TakeBullet(Vector3 posSpawn)
    {
        if(queue.Count <= 0) Prepare();
        Bullet bullet = queue.Dequeue();
        bullet.transform.position = posSpawn;
        bullet.gameObject.SetActive(true);
        return bullet;  
    }


    public void RemoveBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.gameObject.transform.SetParent(pool);
        queue.Enqueue(bullet);
    }

}
