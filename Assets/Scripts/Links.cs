using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Links : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text m_text;

    private void Awake()
    {
        m_text = GetComponent<TMP_Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var linkIndex = TMP_TextUtilities.FindIntersectingLink(m_text, eventData.position, null);
        if (linkIndex < 0) { return; }
        
        var linkInfo = m_text.textInfo.linkInfo[linkIndex];
        Application.OpenURL(linkInfo.GetLinkID());
    }
}
