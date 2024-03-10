using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : Singleton<PortalController>
{
	protected override void Awake()
	{
		base.Awake();
		this.gameObject.SetActive(false);
	}

	public void ShowPortal()
	{
		this.gameObject.SetActive(true);
	}

    public void HidePortal()
    {
        this.gameObject.SetActive(false);
    }
}
