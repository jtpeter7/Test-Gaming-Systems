using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public GameObject SIZER;
    public void NEXTSCENE()
    {
        SIZER.transform.parent = null;
        Object.DontDestroyOnLoad(SIZER);
        SceneManager.LoadScene("Level1");
    }
}
