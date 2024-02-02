using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class SelectionTesting : MonoBehaviour
{
    [SerializeField] private Transform _dot;

    private TouchInput _input;
    private Camera _camera;

    private void Awake()
    {
        _input = FindObjectOfType<TouchInput>();
        _camera = Camera.main;

    }
    private void OnEnable()
    {
        TouchInput.OnClicked += ClickTest;
    }

    private void Update()
    {
        /*if (_input.TouchIsHeld)
        {
            //ClickTest();
            if(!_dot.gameObject.activeInHierarchy) _dot.gameObject.SetActive(false);

            Vector3 dotPosition = _camera.ScreenToWorldPoint(_input.TouchScreenPosition);
            dotPosition.z = 0;
            _dot.transform.position = dotPosition;

            ClickTest();
        }
        else
        {
            if (_dot.gameObject.activeInHierarchy) _dot.gameObject.SetActive(false);
        }*/
    }
    /*public void ClickTest()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(_input.TouchScreenPosition * -Vector3.forward * 10f, Vector3.forward, 100f);

        if (hit2D)
        {
            Debug.Log("Hit");
        }
        else
        {
            Debug.Log("No hit");
        }
    }*/
    
    public void ClickTest()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(_input.TouchScreenPosition);


        if (Physics.Raycast(ray, out hit))
        {
            // display the aim indicator
            //_dot.transform.position = hit.point;

            Debug.Log("Hit");
        }
        else
        {
            Debug.Log("No hit");
        }
    }
}
