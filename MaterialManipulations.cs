using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewGreenButton : MonoBehaviour
{
    [SerializeField]
    private Color[] colors;
    [SerializeField]
    private Material[] baseMaterials;
    int colorIndex = 0;
    int baseIndex = 0;
    Color color = Color.black;
    public Renderer head;
    SkinnedMeshRenderer rend;
    Material[] mats;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SkinnedMeshRenderer>();
        mats = rend.materials;
        mats[0] = baseMaterials[baseIndex];
        mats[1].SetColor("_Color",colors[colorIndex]);
        mats[1].SetColor("_EmissionColor",Color.black);
    }
    private void OnMouseDown()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;
        // Set the z-coordinate to the distance from the camera to the object (y because camera is overhead)
        mouseScreenPosition.z = Camera.main.transform.position.y - transform.position.y;
        // Convert the screen space position to world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 distance = mouseWorldPosition - transform.position;
        if (distance.sqrMagnitude < 0.42f)
        {
            color = head.material.color;
            //change base material
            baseIndex++;
            mats[0] = baseMaterials[baseIndex % baseMaterials.Length];
            mats[0].SetColor("_Color", color);
            mats[0].SetColor("_EmissionColor", color);
        }
        head.material = mats[0];
    }
    private void OnMouseEnter()
    {
        mats[1].SetColor("_EmissionColor", colors[colorIndex % colors.Length]);
    }
    private void OnMouseExit()
    {
        mats[1].SetColor("_EmissionColor", Color.black);
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewRedButton : MonoBehaviour
{
    [SerializeField]
    private Color[] colors;
    [SerializeField]
    private Material[] baseMaterials;
    int colorIndex = 0;
    public Renderer head;
    SkinnedMeshRenderer rend;
    Material[] mats;
    Material headMat;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SkinnedMeshRenderer>();
        mats = rend.materials;
        headMat = head.material;
        mats[1].SetColor("_Color",colors[colorIndex]);
        mats[1].SetColor("_EmissionColor",Color.black);
    }
    private void OnMouseDown()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;
        // Set the z-coordinate to the distance from the camera to the object (y because camera is overhead)
        mouseScreenPosition.z = Camera.main.transform.position.y - transform.position.y;
        // Convert the screen space position to world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 distance = mouseWorldPosition - transform.position;
        if (distance.sqrMagnitude < 0.42f)
        {
                        headMat = head.material;
            colorIndex++;
            headMat.SetColor("_Color", colors[colorIndex % colors.Length]);
            headMat.SetColor("_EmissionColor", ((int)Time.time) % 2 == 0 ? Color.black : colors[colorIndex % colors.Length]);
        }
        head.material = headMat;
    }
    private void OnMouseEnter()
    {
        mats[1].SetColor("_EmissionColor", colors[colorIndex % colors.Length]);
    }
    private void OnMouseExit()
    {
        mats[1].SetColor("_EmissionColor", Color.black);
    }
}