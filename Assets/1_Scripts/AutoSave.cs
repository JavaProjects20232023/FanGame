using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Auto());
    }

    public IEnumerator Auto()
    {
        yield return new WaitForSeconds(60);
        SaveLoad.instance.Save();
    }
}
