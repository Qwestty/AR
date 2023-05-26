using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    Material _activeMaterial;
    [SerializeField]
    GameObject _infoPanel;
    [SerializeField]
    GameObject _NoneActiveMaterial;
    private void OnMouseDown()
    {
        gameObject.GetComponent<Renderer>().material = _activeMaterial;
        gameObject.transform.localPosition += new Vector3(0, 0.02f, 0);
        _infoPanel.SetActive(true);
    }
}
