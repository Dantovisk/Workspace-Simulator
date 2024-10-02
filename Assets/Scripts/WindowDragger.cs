// Aviso: Esse codigo funciona quando voc� coloca o script em alguma entidade filho (como uma barra superior)
// E O script mover� todo o objeto Pai
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDragger : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform parentRectTransform; // RectTransform da janela completa
    private Vector2 originalPosition;

    private void Awake()
    {
        // Obt�m o RectTransform do objeto pai, que � o "EmailWindow"
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    // Fun��o chamada quando o clique come�a
    public void OnPointerDown(PointerEventData eventData)
    {
        originalPosition = parentRectTransform.anchoredPosition; // Salva a posi��o original da janela completa

        // Traz a janela clicada para o topo da visualiza��o
        parentRectTransform.SetAsLastSibling();
    }

    // Fun��o chamada quando o arrasto come�a
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    // Fun��o chamada enquanto o painel est� sendo arrastado
    public void OnDrag(PointerEventData eventData)
    {
        float scaleFactor = parentRectTransform.GetComponentInParent<Canvas>().scaleFactor;
        parentRectTransform.anchoredPosition += eventData.delta / scaleFactor; // Ajusta o movimento de acordo com a escala
    }


    // Fun��o chamada quando o arrasto termina
    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
