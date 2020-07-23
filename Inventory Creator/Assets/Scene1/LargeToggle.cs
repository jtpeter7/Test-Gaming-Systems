using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject s1, s2, s3;
    bool toggle = false;

    private void Start()
    {
        s1.SetActive(toggle);
        s2.SetActive(toggle);
        s3.SetActive(toggle);
    }
    public void TOGGLE()
    {
        toggle = !toggle;
        s1.SetActive(toggle);
        s2.SetActive(toggle);
        s3.SetActive(toggle);
    }
}
