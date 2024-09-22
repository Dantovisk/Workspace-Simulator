// Aviso: Esse codigo funciona quando você coloca o script em alguma entidade filho (como uma barra superior)
// E O script moverá todo o objeto Pai
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDragger : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform parentRectTransform; // RectTransform da janela completa
    private Vector2 originalPosition;

    private void Awake()
    {
        // Obtém o RectTransform do objeto pai, que é o "EmailWindow"
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    // Função chamada quando o clique começa
    public void OnPointerDown(PointerEventData eventData)
    {
        originalPosition = parentRectTransform.anchoredPosition; // Salva a posição original da janela completa

        // Traz a janela clicada para o topo
        parentRectTransform.SetAsLastSibling();
    }

    // Função chamada quando o arrasto começa
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Pode ser usada para configurar algo quando o arrasto começa (opcional)
    }

    // Função chamada enquanto o painel está sendo arrastado
    public void OnDrag(PointerEventData eventData)
    {
        parentRectTransform.anchoredPosition += eventData.delta; // Move a janela completa de acordo com o movimento do mouse/touch
    }

    // Função chamada quando o arrasto termina
    public void OnEndDrag(PointerEventData eventData)
    {
        // Pode ser usada para ações quando o arrasto termina (opcional)
    }
}
