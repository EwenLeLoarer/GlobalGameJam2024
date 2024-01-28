using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    [SerializeField] private int _moveSpeed;

    private int _pointIndex;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = _points[_pointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_pointIndex <= _points.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_pointIndex].transform.position, _moveSpeed * Time.deltaTime);

            if(transform.position == _points[_pointIndex].transform.position)
            {
                _pointIndex++;
            }
        }
    }
}
