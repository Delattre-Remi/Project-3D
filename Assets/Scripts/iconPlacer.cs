using UnityEngine;
using TMPro;

public class iconPlacer : MonoBehaviour
{
    [SerializeField] GameObject[] icons;
    [SerializeField] GameObject[] texts;
    [SerializeField] Tower[] towers;
    [SerializeField] GameObject parent;
    [SerializeField] float offset;
    private RectTransform parentRt;
    private int nbrOfIcons;
    private float parentHeight;
    private float parentWidth;
    private float step;
    private Vector3 newScale;
    private GameObject icon;
    private RectTransform iconRect;
    private GameObject text;
    private Vector3 newPos;
    private Tower tower;

    void Start()
    {
        // Place les icones en fonction de la taille de l'écran et de leur nombre
        // Resize les icones en fonction de la taile de l'écran
        parentRt = parent.GetComponent<RectTransform>();
        parentHeight = parentRt.rect.height - offset;
        parentWidth = parentRt.rect.width;
        nbrOfIcons = icons.Length;
        step = parentHeight / nbrOfIcons;
        for(int i = 0 ; i < nbrOfIcons ; i++)
        {
            icon = icons[i];
            text = texts[i];
            tower = towers[i];
            text.GetComponent<TextMeshProUGUI>().text = tower.price.ToString();
            newScale = icon.transform.localScale;
            iconRect = icon.GetComponent<RectTransform>();
            newScale *= parentWidth / iconRect.rect.width;
            icon.transform.localScale = newScale;
            newPos = icon.transform.position;
            newPos.y = parentHeight - step * i - offset;
            icon.transform.position = newPos;
            newPos.y -= iconRect.rect.width;
            text.transform.position = newPos;
        }
    }
}
