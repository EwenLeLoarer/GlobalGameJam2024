using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UseItem : MonoBehaviour
{
    private InputManager _inputManager;
    private CharacterController _characterController;
    [SerializeField] private GameObject _bananaPrefab;

    [SerializeField] private Transform _bananaSpawnTransform;

    void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        _inputManager.OnUseItem += DoUseItem;
    }

    void OnDisable()
    {
        _inputManager.OnUseItem -= DoUseItem;
    }

    void DoUseItem()
    {
        // if (Inventory.Instance.Items.Count == 0) return;

        // var item = Inventory.Instance.Items.First();
        // Inventory.Instance.Remove();

        var obj = Instantiate(_bananaPrefab, _bananaSpawnTransform.position, Quaternion.identity);
    }
}
