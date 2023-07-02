using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovableElements : MonoBehaviour
{
    private Transform m_Transform;
	[SerializeField] private Button upButton;
	[SerializeField] private Button downButton;
	[SerializeField] private float moveIncrement;

	private float startLocY;

    void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }
    void Start()
    {
		startLocY = m_Transform.position.y;
		upButton.onClick.AddListener(onUpClick);
		downButton.onClick.AddListener(onDownClick);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void onUpClick() 
	{
		float newLocY = m_Transform.position.y - moveIncrement;
		if (newLocY < startLocY)
		{
			newLocY = startLocY;
		}

		m_Transform.position = new Vector3(m_Transform.position.x, newLocY, m_Transform.position.z);
	}

	void onDownClick()
	{
		float newLocY = m_Transform.position.y + moveIncrement;
		//TODO: Add bounds Checking at this end eventually as well.
		m_Transform.position = new Vector3(m_Transform.position.x, newLocY, m_Transform.position.z); 
	}

	
}
