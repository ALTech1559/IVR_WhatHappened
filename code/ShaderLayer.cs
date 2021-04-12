using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderLayer : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> takerObjects;
    [SerializeField] private Material changeMaterial;

    private void Awake()
    {
        //foreach( MeshRenderer mesh in takerObjects)
        //{
        //    Texture currentMaterial = mesh.material.mainTexture;
        //    changeMaterial.mainTexture = currentMaterial;
        //    mesh.material = changeMaterial;
        //}
        //for (int i =0; i < takerObjects.Count; ++i)
        //{
        //    Texture currentMaterial = takerObjects[i].material.mainTexture;
        //    changeMaterial.mainTexture = currentMaterial;
        //    takerObjects[i].material = changeMaterial;
        //}
    }
}
