using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Mesh/Combine Children")]

public class GenerateWeaponParts : MonoBehaviour {

    public Texture2D Blade;
    public Texture2D Hilt;
    public Texture2D Handle;
    public Texture2D Guard;
    public Texture2D[] ImageBlades;
    public Texture2D[] ImageHilts;
    public Texture2D[] ImageHandles;
    public Texture2D[] ImageGuards;
    public int imageSize = 64;
    public float Bladewidth;
    public float Hiltwidth;
    public float Handlewidth;
    public float Guardwidth;
    public int scale = 10;
    public Transform SwordPiece;
    public Transform padre;
    public bool Sheathe = false;
    public int SBlade, SHilt, SHandle, SGuard;
    public GameObject info, blade, guard, handle;
    int test = 1;

    private void Start()
    {
        try
        {
            blade = GameObject.Find("Blade");
            handle = GameObject.Find("Handle");
            guard = GameObject.Find("Guard");
            SBlade = blade.GetComponent<Sprites>().count;
            SHandle = handle.GetComponent<Sprites>().count;
            SHilt = guard.GetComponent<Sprites>().count;
            Blade = ImageBlades[SBlade];
            Hilt = ImageHilts[SHilt];
            Handle = ImageHandles[SHandle];
            Guard = ImageGuards[SGuard];
            test = 0;
        }
        catch { }
        Sheathe = !Sheathe;
        SheatheWeapon();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Sheathe = !Sheathe;
            SheatheWeapon();
        }
        if (test == 1)
        {
            if (Input.GetKeyDown("1"))
            {
                SBlade++;
                if (SBlade >= 10)
                {
                    SBlade = 0;
                }
                Debug.Log("Next Blade: " + SBlade);
            }
            if (Input.GetKeyDown("2"))
            {
                SHilt++;
                if (SHilt >= 10)
                {
                    SHilt = 0;
                }
                Debug.Log("Next Hilt: " + SHilt);
            }
            if (Input.GetKeyDown("3"))
            {
                SHandle++;
                if (SHandle >= 10)
                {
                    SHandle = 0;
                }
                Debug.Log("Next Handle: " + SHandle);
            }
            if (Input.GetKeyDown("4"))
            {
                SGuard++;
                if (SGuard >= 10)
                {
                    SGuard = 0;
                }
                Debug.Log("Next Guard: " + SGuard);
            }
            Blade = ImageBlades[SBlade];
            Hilt = ImageHilts[SHilt];
            Handle = ImageHandles[SHandle];
            Guard = ImageGuards[SGuard];
        }
    }

    void SheatheWeapon()
    {
        if (! Sheathe)
        
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        else
        {
            //Debug.Log(SBlade + " , " + SHilt + " , " + SHandle + " , " + SGuard);
            for (int y = 1; y < imageSize; y++)
            {
                for (int x = 1; x < imageSize; x++)
                {
                    try
                    {
                        if (Blade.GetPixel(x, y) != Color.white)
                        {
                            Transform cube = Instantiate(SwordPiece, new Vector3(x, y, 0), Quaternion.identity);
                            cube.transform.parent = padre;
                            cube.transform.rotation = padre.rotation;
                            cube.transform.localPosition = new Vector3(x, y, 0) / scale;
                            cube.transform.localScale = new Vector3(1, 1, Bladewidth) / scale;
                            cube.GetComponent<Renderer>().material.SetColor("_Color", Blade.GetPixel(x, y));
                            cube.GetComponent<Renderer>().material.name = (cube.GetComponent<Renderer>().material.GetColor("_Color") + " ");
                            cube.GetComponent<BoxCollider>().enabled = false;
                        }
                    }
                    catch  { }
                    try
                    {
                        if (Hilt.GetPixel(x, y) != Color.white)
                        {
                            Transform cube = Instantiate(SwordPiece, new Vector3(x, y, 0), Quaternion.identity);
                            cube.transform.parent = padre;
                            cube.transform.rotation = padre.rotation;
                            cube.transform.localPosition = new Vector3(x, y, 0) / scale;
                            cube.transform.localScale = new Vector3(1, 1, Hiltwidth) / scale;
                            cube.GetComponent<Renderer>().material.color = Hilt.GetPixel(x, y);
                            cube.GetComponent<Renderer>().material.name = (cube.GetComponent<Renderer>().material.GetColor("_Color") + " ");
                            cube.GetComponent<BoxCollider>().enabled = false;
                        }
                    }
                    catch { }
                    try
                    {
                        if (Handle.GetPixel(x, y) != Color.white)
                        {
                            Transform cube = Instantiate(SwordPiece, new Vector3(x, y, 0), Quaternion.identity);
                            cube.transform.parent = padre;
                            cube.transform.rotation = padre.rotation;
                            cube.transform.localPosition = new Vector3(x, y, 0) / scale;
                            cube.transform.localScale = new Vector3(1, 1, Handlewidth) / scale;
                            cube.GetComponent<Renderer>().material.color = Handle.GetPixel(x, y);
                            cube.GetComponent<Renderer>().material.name = (cube.GetComponent<Renderer>().material.GetColor("_Color") + " ");
                            cube.GetComponent<BoxCollider>().enabled = false;
                        }
                    }
                    catch { }
                    try
                    {
                        if (Guard.GetPixel(x, y) != Color.white)
                        {
                            Transform cube = Instantiate(SwordPiece, new Vector3(x, y, 0), Quaternion.identity);
                            cube.transform.parent = padre;
                            cube.transform.rotation = padre.rotation;
                            cube.transform.localPosition = new Vector3(x, y, 0) / scale;
                            cube.transform.localScale = new Vector3(1, 1, Guardwidth) / scale;
                            //cube.GetComponent<Renderer>().material.mainTexture = (Handle.GetPixel(x, y));
                            cube.GetComponent<Renderer>().material.color = Guard.GetPixel(x, y);
                            cube.GetComponent<Renderer>().material.name = (cube.GetComponent<Renderer>().material.GetColor("_Color") + " ");
                            cube.GetComponent<BoxCollider>().enabled = false;
                        }
                    }
                    catch { }
                }
            }
            
            ///Credit to: http://grrava.blogspot.com/2014/08/combine-meshes-in-unity.html
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

            ///to here
            
    

        }
        
    }


}
