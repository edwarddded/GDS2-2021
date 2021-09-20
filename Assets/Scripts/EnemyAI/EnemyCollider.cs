using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    SkinnedMeshRenderer SkinnedMeshRenderer;
    MeshCollider MeshCollider;
    // Start is called before the first frame update
    void Start()
    {
        SkinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
        MeshCollider = gameObject.GetComponent<MeshCollider>();
    }

    public void UpdateCollider()
    {
        Mesh ColliderMesh = new Mesh();
        SkinnedMeshRenderer.BakeMesh(ColliderMesh);
        MeshCollider.sharedMesh = null;
        MeshCollider.sharedMesh = ColliderMesh;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateCollider();
    }
}
