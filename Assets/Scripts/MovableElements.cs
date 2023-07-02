using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableElements : MonoBehaviour
{
    private Transform m_Transform;

    void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }
    void Start()
    {
        //Get starting X and location. These will be used to help determine bounds.
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
