using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public Image trophyImage;       // Imagem do troféu específico
    public int pointsToUnlock;      // Pontos necessários para desbloquear o troféu
    public int perfectPhasesToUnlock;
    public int achievementIndex;

    void Start()
    {
        // Registra este achievement no AchievementManager
        AchievementManager.Instance.RegisterAchievement(this);

        // Inicializa o troféu como trancado
        trophyImage.sprite = Resources.Load<Sprite>("Images/LockedTrophy");
    }

    // Método chamado para verificar se o achievement foi concluído
    public void CheckCompletion(int totalPoints, int totalPerfects)
    {
        if (totalPoints >= pointsToUnlock && totalPerfects >= perfectPhasesToUnlock)
        {
            // Substitui pela imagem de troféu correspondente
            string trophyName = "Trophy" + achievementIndex.ToString("00"); // Exemplo: troca dependendo dos pontos
            trophyImage.sprite = Resources.Load<Sprite>("Images/" + trophyName);
        }
    }
}
