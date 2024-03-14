using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManagement : MonoBehaviour
{

    [SerializeField] GameObject enemies;
    [SerializeField] GameObject portalController;

    private void Update()
    {
        if (enemies.transform.childCount == 0)
        {
            portalController.SetActive(true);
        }
    }

}
