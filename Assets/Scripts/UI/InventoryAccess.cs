using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAccess : MonoBehaviour
{
    [SerializeField]
    //private ThirdPersonController _player;
    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Collectable"))
            return;
        var item = collision.gameObject.GetComponent<ItemController>();
        Debug.Log(item.item);
        Inventory.Instance.Add(item.item);
        Inventory.Instance.ListItems();
        //_player.PlayLootSound();
        Destroy(collision.gameObject);
    }
}
