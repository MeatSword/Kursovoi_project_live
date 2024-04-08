using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCam : MonoBehaviour
{
    public Transform Target;

    [SerializeField]private float _smooth;

    private void Start()
    {
        transform.position = Target.transform.position;
    }

    private void LateUpdate()
    {
        Following();
    }

    private void Following()
    {
        Vector3 _targetPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z-10);
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _smooth*Time.deltaTime);
    }
}