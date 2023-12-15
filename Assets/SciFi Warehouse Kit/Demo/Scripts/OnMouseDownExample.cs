using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownExample : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject uiPanel;
    void OnMouseDown()
	{
		uiPanel.SetActive(true);
		print (name);
	}
}
