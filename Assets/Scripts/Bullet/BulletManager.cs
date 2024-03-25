using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private static BulletManager instance;
    public static BulletManager Instance => instance;


    [SerializeField] private Transform Pool;
    [SerializeField] private List<Bullet> listBullets = new List<Bullet>();
    private Queue<Bullet> queueBullet = new Queue<Bullet>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 instance in your game !!!");
            return;
        }

        instance = this;
        AddPrefabs();
        Prepare();
    }



    private void AddPrefabs()
    {
        Transform objPrefabs = transform.Find("Prefabs");
        foreach(Transform child in objPrefabs)
        {
            listBullets.Add(child.GetComponent<Bullet>());
        }
        HideBullet();
    }


    private void HideBullet()
    {
        foreach (Bullet bullet in listBullets)
        {
            bullet.gameObject.SetActive(false);
        }
    }


    private void Prepare()
    {
        for(int i = 0; i < 10; i++)
        {
            Bullet bullet = Instantiate(listBullets[0],Pool);
            bullet.gameObject.SetActive(false);
            queueBullet.Enqueue(bullet);
        }
    }



    public Bullet TakeBullet(Vector2 posSpawn)
    {
        if(queueBullet.Count<=0) Prepare();
        Bullet bullet = queueBullet.Dequeue();
        bullet.gameObject.SetActive(true);
        bullet.gameObject.transform.position = posSpawn;
        return bullet;
    }


    public void ReturnBulletInQueue(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.gameObject.transform.SetParent(Pool);
        queueBullet.Enqueue(bullet);
    }
}
