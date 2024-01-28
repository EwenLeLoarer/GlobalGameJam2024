using UnityEngine;

public class SpriteFaceCamera : MonoBehaviour
{
    private Transform _mainCameraTransform;

    void Awake()
    {
        _mainCameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // transform.rotation = _mainCameraTransform.rotation; /* fully face the camera */

        /* face camera but will not point upward */
        Vector3 newRotation = _mainCameraTransform.eulerAngles;
        newRotation.x = 0;
        newRotation.z = 0;
        transform.eulerAngles = newRotation;
    }
}
