using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManagement : MonoBehaviour
{

    [SerializeField] GameObject enemies;

    private void Update()
    {
        if (enemies.transform.childCount == 0)
        {
            PortalController.Instance.ShowPortal();
        }
    }

}
