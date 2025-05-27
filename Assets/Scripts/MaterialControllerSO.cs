using UnityEngine;

[CreateAssetMenu(fileName = "MaterialController", menuName = "ScriptableObject/MaterialController", order = 1)]
public class MaterialControllerSO : ScriptableObject
{
    [Header("Visual Values")]
    [SerializeField] private Material material;
    [SerializeField] private Color[] ballColors;

    public void SetBallColor(OnMaterialChange type)
    {
        switch (type)
        {
            case OnMaterialChange.OnLaunch:
                material.SetColor("", ballColors[0]);
                break;
            case OnMaterialChange.OnNormal:
                material.SetColor("", ballColors[1]);
                break;
        }
    }
}
public enum OnMaterialChange
{
    OnLaunch, OnNormal
}
