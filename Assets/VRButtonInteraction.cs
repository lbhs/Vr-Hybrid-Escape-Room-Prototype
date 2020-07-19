using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButtonInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10 && canPush == true) //10 is UIButton
        {
            StartCoroutine(Push());
            other.gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }

    bool canPush = true;
    IEnumerator Push()
    {
        canPush = false;
        yield return new WaitForSecondsRealtime(0.1f);
        canPush = true;
    }
}
