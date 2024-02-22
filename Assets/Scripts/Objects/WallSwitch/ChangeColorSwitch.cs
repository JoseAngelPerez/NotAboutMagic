using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorSwitch: MonoBehaviour
{
    [SerializeField] Material switchReadyMaterial, switchActiveMaterial;
    private Renderer rend;

    private void Start()
    {
        rend= GetComponent<Renderer>();
        SetReadyMaterial();
    }

    public void SetReadyMaterial()
    {
        rend.sharedMaterial = switchReadyMaterial;
    }

    public void SetActiveMaterial()
    {
        rend.sharedMaterial = switchActiveMaterial;
    }
}
