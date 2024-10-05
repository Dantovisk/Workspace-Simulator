using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public Image trophyImage;       // Imagem do trof�u espec�fico
    public int pointsToUnlock;      // Pontos necess�rios para desbloquear o trof�u

    void Start()
    {
        // Registra este achievement no AchievementManager
        AchievementManager.Instance.RegisterAchievement(this);

        // Inicializa o trof�u como trancado
        trophyImage.sprite = Resources.Load<Sprite>("Images/LockedTrophy");
    }

    // M�todo chamado para verificar se o achievement foi conclu�do
    public void CheckCompletion(int totalPoints)
    {
        if (totalPoints >= pointsToUnlock)
        {
            // Substitui pela imagem de trof�u correspondente
            string trophyName = "Trophy" + (pointsToUnlock / 10).ToString("00"); // Exemplo: troca dependendo dos pontos
            trophyImage.sprite = Resources.Load<Sprite>("Images/" + trophyName);
        }
    }
}
