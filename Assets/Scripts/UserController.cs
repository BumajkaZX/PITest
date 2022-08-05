using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    [SerializeField] private LayerMask _zoneMask;
    [SerializeField] private SpawnBots spawn;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),out RaycastHit hit, 100, _zoneMask))
            {
                spawn.SpawnBot(hit.point);
            }
        }
    }
}
