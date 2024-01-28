using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    private InputManager _inputManager;
    private CharacterController _characterController;
    [SerializeField]private GameObject BananaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputManager.useItem)
        {
            foreach(var item in Inventory.Instance.Items)
            {
                //Inventory.Instance.Remove(item.Key);
                var obj = Instantiate(BananaPrefab, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
                
            }
        }
    }
}
