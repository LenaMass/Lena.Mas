using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    [SerializeField] private string _levelName = string.Empty;

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Player") == false)
            return;

        SceneManager.LoadScene("SampleScene");
    }


// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
