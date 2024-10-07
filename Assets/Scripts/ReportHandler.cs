using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ReportHandler : MonoBehaviour
{
    public Button submitButton;  // Botão de submissão que o usuário irá clicar
    public Toggle[] toggles;     // Lista de toggles dentro do relatório
    public bool[] correctAnswers; // Array de booleans representando se cada Toggle deve estar ligado ou desligado
    private GlobeReportReceiver reportReceiver;  // Referência ao receiver que gerencia os relatórios
    private string reportName;  // Nome do relatório para remover na lista de assuntos

    private TextMeshProUGUI scoreText;

    // Nome do objeto de texto na UI principal (TextMeshPro)
    public string scoreTextObjectName = "ScoreText";

    // Referência ao script de Achievement
    public Achievement achievementSystem; // <-- Adiciona essa referência


    // Função para inicializar o report handler com as referências adequadas
    public void Initialize(GlobeReportReceiver receiver, string name)
    {
        if (name == "PlaceHolder") return;
        reportReceiver = receiver;
        reportName = name;

        // Adicionar listener ao botão de submit
        submitButton.onClick.AddListener(CalculateScore);

        GameObject textObject = GameObject.Find(scoreTextObjectName); // <-- Encontra o objeto pelo nome
        if (textObject != null)
        {
            scoreText = textObject.GetComponent<TextMeshProUGUI>();  // Pega o componente TextMeshProUGUI
        }
        else
        {
            Debug.LogError("Texto de pontuação não encontrado na UI principal.");
        }
    }

    // Função chamada ao clicar no botão de submit
    private void CalculateScore()
    {
		int score = 0;
        int perfect = 1;

        // Verifica se cada Toggle está no estado correto
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn && toggles[i].isOn == correctAnswers[i])
            {
                score+=10;  // Aumenta a pontuação por cada acerto
            }
            else if (!toggles[i].isOn && correctAnswers[i])
            {
                score--;
                perfect = 0;
            }
            else if(!toggles[i].isOn && !correctAnswers[i])
            {
                score++;
            }
            else
            {
                score--;
                perfect = 0;
            }
        }

        Debug.Log($"Score: {score}");

        if (scoreText != null)
        {
            // Pega a pontuação armazenada nos PlayerPrefs
            int currentPoints = PlayerPrefs.GetInt("PlayerPoints", 0); // 0 é o valor padrão caso não haja um valor salvo
            currentPoints += score; // Soma a pontuação atual com o score
            PlayerPrefs.SetInt("PlayerPoints", currentPoints); // Salva a nova pontuação
            PlayerPrefs.Save(); // Garante que o valor seja persistido

            // Atualiza o texto da pontuação
            scoreText.text = $"{currentPoints}";
        }

        // Atualiza a pontuação global no AchievementManager
        AchievementManager.Instance.UpdatePoints(score, perfect);

        // Remove o relatório atual e o botão da aba de assuntos
        reportReceiver.RemoveReport(reportName, this.gameObject);
	}
}
