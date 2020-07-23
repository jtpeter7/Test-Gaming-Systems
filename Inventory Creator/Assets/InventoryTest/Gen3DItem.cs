using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen3DItem : MonoBehaviour
{
    bool up = true;
    private int count;
    public GameObject PlayerCollider;
    // Start is called before the first frame update

    private void Start()
    {
        PlayerCollider = GameObject.Find("PlayerCollider"); 
    }
    public void Generate(Texture2D Image, int scale)
    {
        count = Mathf.FloorToInt(Random.Range(0, 30));
        transform.RotateAround(transform.position, Vector3.down, Mathf.FloorToInt(Random.Range(0, 360)));
        Transform ItemPiece = Resources.Load<Transform>("ItemPiece");
        for (int y = 1; y < Image.height; y++)
        {
            for (int x = 1; x < Image.width; x++)
            {
                try
                {
                    if (Image.GetPixel(x, y) != Color.white)
                    {
                        Transform cube = Instantiate(ItemPiece, new Vector3(x, y, 0), Quaternion.identity);
                        cube.name = "PART";
                        cube.transform.parent = transform;
                        cube.transform.rotation = transform.rotation;
                        cube.transform.localPosition = new Vector3(x, y, 0) / scale;
                        cube.transform.localScale = new Vector3(1, 1, (float)transform.parent.GetComponent<Item>().width) / scale;
                        cube.GetComponent<Renderer>().material.SetColor("_Color", Image.GetPixel(x, y));
                        cube.GetComponent<Renderer>().material.name = (cube.GetComponent<Renderer>().material.GetColor("_Color") + " ");
                        cube.GetComponent<BoxCollider>().enabled = false;
                    }
                }
                catch { }
            }
        }
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
            go.transform.localPosition = Vector3.zero + new Vector3(-1, 0, 0);
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
            go.layer = 10;
            var filter = go.AddComponent<MeshFilter>();
            filter.mesh.CombineMeshes(combines[m.name].ToArray(), true, true);

            var arenderer = go.AddComponent<MeshRenderer>();
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


        transform.localPosition = new Vector3(Random.Range(0, .2f), 0, Random.Range(0, .2f));
    }


    private void Update()
    {
        if (!PlayerCollider.GetComponent<Inventory>().UI)
        {
            if (up)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + .01f, transform.localPosition.z);
                count++;
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - .01f, transform.localPosition.z);
                count--;
            }
            if (count >= 30)
            {
                up = false;
            }
            else if (count <= 0)
            {
                up = true;
            }
            transform.RotateAround(transform.position + new Vector3(0,0,0), Vector3.down, 1); ;
        }
    }
}