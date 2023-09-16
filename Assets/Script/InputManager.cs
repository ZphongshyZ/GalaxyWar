using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Singleton
    protected static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] protected Vector3 mousePos;
    public Vector3 MousePos { get => mousePos; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }

    private void Awake()
    {
        if (InputManager.instance != null) Debug.Log("Only 1 Input Manager allowed to exist");
        InputManager.instance = this;
    }

    private void FixedUpdate()
    {
        this.GetMousePos();
        this.GetMouseDown();
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }

    protected virtual void GetMousePos()
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
