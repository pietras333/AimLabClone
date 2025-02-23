using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPSController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private LayerMask targetLayer;

    public void OnShootInput(bool isPressed)
    {
        if (isPressed)
        {
            HandleShoot();
        }
    }

    private void HandleShoot()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
        {
            Dummy dummy = hit.collider.GetComponent<Dummy>();

            ScoreManager.Instance.AddScore(dummy.GetScore());

            Destroy(hit.collider.gameObject);
        }
        else
        {
            ScoreManager.Instance.Missed();
        }
    }
}
