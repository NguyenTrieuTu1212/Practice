using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUse : MonoBehaviour
{


    private void Start()
    {
        InventorySlots.OnClickSlotPostion += GetPostionCallback;
        gameObject.SetActive(false);
    }


    public void OnClickUseItem()
    {
        InventoryManager.Instance.UseItem();
        gameObject.SetActive(false);
    }

    private void GetPostionCallback(Vector3 postionTarget)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = postionTarget + new Vector3(0, -1f, 0);
    }

    private void OnDestroy()
    {
        InventorySlots.OnClickSlotPostion -= GetPostionCallback;
    }
    


    
}
