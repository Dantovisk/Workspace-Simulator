using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image displayImage; // O componente de Image do prefab para exibir a imagem atual
    public Button leftButton; // Botão para ir para a imagem anterior
    public Button rightButton; // Botão para ir para a próxima imagem

	public Button leftButton2; // Botão para ir para a imagem anterior
	public Button rightButton2; // Botão para ir para a próxima imagem

	public Sprite[] imageArray; // Um array de imagens (defina 3 imagens aqui no inspector)

    private int currentIndex = 0; // Índice da imagem atualmente exibida

    void Start()
    {
        // Exibe a primeira imagem ao iniciar
        displayImage.sprite = imageArray[currentIndex];

        // Configura os listeners para os botões
        leftButton.onClick.AddListener(ShowPreviousImage);
        rightButton.onClick.AddListener(ShowNextImage);

		leftButton2.onClick.AddListener(ShowPreviousImage);
		rightButton2.onClick.AddListener(ShowNextImage);

		// Verifica se o botão da esquerda precisa estar desabilitado inicialmente
		UpdateButtonState();
    }

    // Função para mostrar a imagem anterior
    void ShowPreviousImage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            displayImage.sprite = imageArray[currentIndex];
        }
        UpdateButtonState();
    }

    // Função para mostrar a próxima imagem
    void ShowNextImage()
    {
        if (currentIndex < imageArray.Length - 1)
        {
            currentIndex++;
            displayImage.sprite = imageArray[currentIndex];
        }
        UpdateButtonState();
    }

    // Atualiza o estado dos botões dependendo da posição
    void UpdateButtonState()
    {
        // Se estamos na primeira imagem, o botão da esquerda deve estar desabilitado
        leftButton.interactable = currentIndex > 0;

        // Se estamos na última imagem, o botão da direita deve estar desabilitado
        rightButton.interactable = currentIndex < imageArray.Length - 1;
    }
}
