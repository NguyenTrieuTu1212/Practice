using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnermyDead : MonoBehaviour
{
    [SerializeField] private Transform Container;
    [SerializeField] private SlotLoot slotLootPrefab;
    [SerializeField] private Image contentScrollView;
    [SerializeField][Range(1, 10f)] private float radius;
    [SerializeField] private LayerMask whatIsLayerDetect;
    bool isDetected;
    EnermyLoot enermyLoot;


    private void Awake()
    {
        enermyLoot = GetComponent<EnermyLoot>();
    }
    private void Update()
    {
        if (Check())
        {
            OpenPanelLoot();
        }
    }



    private void OpenPanelLoot()
    {
        contentScrollView.gameObject.SetActive(true);
        foreach (ItemDrop item in enermyLoot.listDropRandom)
        {
            SlotLoot slotLoot = Instantiate(slotLootPrefab, Container);
            slotLoot.LoadInfoItemLoot(item);
            slotLoot.gameObject.SetActive(true);
        }
    }




    private bool Check()
    {
        isDetected = Physics2D.OverlapCircle(transform.position,radius, whatIsLayerDetect);
        return isDetected;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }


}
