using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator wait2(Collider2D collision)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(wait2(collision));
    }
}
