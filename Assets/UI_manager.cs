using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_manager : MonoBehaviour
{
    [SerializeField]
    private Text score_text;
    // Start is called before the first frame update
    void Start()
    {
        score_text.text = "Score: " + 0;                        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
