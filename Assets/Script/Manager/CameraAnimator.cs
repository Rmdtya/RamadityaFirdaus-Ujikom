using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{
    Camera mainCamera;
    Animator animator;

    private void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();

        mainCamera.orthographic = true;
        animator = GetComponent<Animator>();    
    }

    public void GameOver()
    {
        animator.CrossFade("GameOver", 0.2f);
        mainCamera.orthographic = false;
    }
}
