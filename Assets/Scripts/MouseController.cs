using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject startMark;
    [SerializeField] private GameObject endMark;
    [SerializeField] private BallController projectile;
    [SerializeField] private LineRendererController trajectoryLine;
    [SerializeField] private float speedModifier = 5F;

    private Vector3 startPos;
    private bool isAiming = false;
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAiming = true;
            startPos = GetMouseWorldPosition();
            startMark.transform.position = startPos;
            startMark.SetActive(true);
            endMark.SetActive(false);
        }
        if (context.canceled)
        {
            isAiming = false;
            Vector3 endPos = GetMouseWorldPosition();
            endMark.transform.position = endPos;
            endMark.SetActive(true);

            projectile.Launch((startPos - endPos) * speedModifier);
        }
    }
    public void OnMouseMove(InputAction.CallbackContext context)
    {
        if (!isAiming)
            return;

        Vector3 currentPos = GetMouseWorldPosition();
        trajectoryLine.DrawBallTrajectory((startPos - currentPos) * speedModifier);
    }
    public void OnReset(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            projectile.ResetLaunch();
            startMark.SetActive(false);
            endMark.SetActive(false);
        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 screenPos = Mouse.current.position.ReadValue();
        screenPos.z = 10f;
        return cam.ScreenToWorldPoint(screenPos);
    }
}
