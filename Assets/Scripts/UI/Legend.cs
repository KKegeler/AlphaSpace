using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Legend : GenericWindow {

	// Use this for initialization
	void Start () {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5f);
        manager.Open(0);
    }
	
}
