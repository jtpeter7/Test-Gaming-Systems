using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaMapGeneration : MonoBehaviour
{
    public Texture2D Map;
    public Texture2D Map_Color;
    public Transform Cube;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Map.width; i++)
        {
            for (int j = 0; j < Map.height; j++)
            {
                int temp = (int)(17 - (Map.GetPixel(i, j).a) * 16);
                //Debug.Log(temp);
                Transform cube = Instantiate(Cube, new Vector3(i, 0, j), Quaternion.identity);
                cube.transform.parent = transform;
                cube.transform.rotation = transform.rotation;
                cube.transform.localPosition = new Vector3(i-Map.width/2, temp/2, j - Map.height / 2);
                cube.transform.localScale = new Vector3(1, temp, 1);


                cube.GetComponent<Renderer>().material.color = Map_Color.GetPixel(i, j);
                cube.GetComponent<Renderer>().material.name = (cube.GetComponent<Renderer>().material.GetColor("_Color") + " ");
            }
        }
        combine();
    }
    void combine() { 
        Matrix4x4 myTransform = transform.worldToLocalMatrix;
        Dictionary<string, List<CombineInstance>> combines = new Dictionary<string, List<CombineInstance>>();
        Dictionary<string, Material> namedMaterials = new Dictionary<string, Material>();
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshRenderer in meshRenderers)
        {
            foreach (var material in meshRenderer.sharedMaterials)
                if (material != null && !combines.ContainsKey(material.name))
                {
                    combines.Add(material.name, new List<CombineInstance>());
                    namedMaterials.Add(material.name, material);
                }
        }

        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        foreach (var filter in meshFilters)
        {
            if (filter.sharedMesh == null)
                continue;
            var filterRenderer = filter.GetComponent<Renderer>();
            if (filterRenderer.sharedMaterial == null)
                continue;
            if (filterRenderer.sharedMaterials.Length > 1)
                continue;
            CombineInstance ci = new CombineInstance
            {
                mesh = filter.sharedMesh,
                transform = myTransform * filter.transform.localToWorldMatrix
            };
            combines[filterRenderer.sharedMaterial.name].Add(ci);

            Destroy(filterRenderer);
        }

        foreach (Material m in namedMaterials.Values)
        {
            var go = new GameObject("Combined mesh");
            go.transform.parent = transform;
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;

            var filter = go.AddComponent<MeshFilter>();
            filter.mesh.CombineMeshes(combines[m.name].ToArray(), true, true);

            var arenderer = go.AddComponent<MeshRenderer>();
            go.AddComponent<MeshCollider>();
            arenderer.material = m;
        }

        var children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.name != "Combined mesh")
            {
                children.Add(child.gameObject);
            }
        }
        children.ForEach(child => Destroy(child));
    }
}
