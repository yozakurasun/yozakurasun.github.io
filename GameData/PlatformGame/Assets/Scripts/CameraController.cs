using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private float _followLagTime;

    void Update()
    {
        FollowPlayerCamera();
    }

    private void FollowPlayerCamera()
    {
        transform.position = Vector3.Lerp(transform.position, _playerObject.transform.position + new Vector3(0, 0, transform.position.z), _followLagTime * Time.deltaTime);
    }
}
