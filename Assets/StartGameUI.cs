using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameUI : MonoBehaviour
{ public int VRScene=1;
    // Start is called before the first frame update
    void Start()
    {
        if(PlatformManager.isVR == true)
        {
            SceneManager.LoadScene(VRScene);
        }
    }
}
