using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScoreView : MonoBehaviour
{
    public Text KillEnemyText;
    public Text KillBossText;
    public Text ClearMissionText;
    public Text UnlockAnimalText;
    public GameObject PlayerScoreVIew;

    // Start is called before the first frame update
    void Start()
    {
        AnimalArr.callAnimalArr();
        UnlockAnimalText.text = string.Format("10 마리중 {0}마리 해금했습니다.", AnimalArr.AnimalArray.Length);
        int bossnum = PlayerPrefs.GetInt("killBosALLNum");
        int enemynum = PlayerPrefs.GetInt("killEnemyALLNum");
        KillBossText.text = string.Format("보스를 총 {0}번 죽였습니다.", bossnum);
        KillEnemyText.text = string.Format("적을 총 {0}번 죽였습니다.", enemynum);
        ClearMissionText.text = string.Format("{0}개의 미션을 클리어했습니다.", TestUGUI.clearmissionNum);

    }

    public void onClickCancleBtn()
    {
        PlayerScoreVIew.SetActive(false);
    }
}
