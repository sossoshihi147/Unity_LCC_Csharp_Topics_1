using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

namespace OLIVER
{
    /// <summary>
    /// 人物屬性
    /// </summary>
    [System.Serializable]
    public class CharacterStats
    {
        public float age;
        public float ability;
        public float sociability;
        public float health;
        public float money;

        public CharacterStats(float _age, float _ability, float _sociability,float _health, float _money)
        {
            age = _age; 
            ability = _ability;
            sociability = _sociability;
            health = _health;
            money = _money;
        }

        public void ModifyStat(string statName, int value)
        {
            switch (statName)
            {
                case "age": age += value; break;
                case "ability": ability += value; break;
                case "sociability": sociability += value; break;
                case "health": health += value; break;
                case "money": money += value; break;
            }
        }
    }
    /// <summary>
    /// 主腳本
    /// </summary>
    public class GameMain : MonoBehaviour
    {
        [SerializeField] public CharacterStats stats;
        private void Awake()
        {
            LogSystem.LogWithColor("恭喜你終於破防了，精生也請多多指教!!", "#f0f");
            Born();
        }

        private void Born()
        {
            int randomStart = Random.Range(0, 4);
            if (randomStart == 0)
            {
                stats = new CharacterStats(1, 0, 10, 120, 800);
                LogSystem.LogWithColor("今世你出生在熱愛戶外活動的家庭", "#f99");
            }
            if (randomStart == 1)
            {
                stats = new CharacterStats(1, 5, 5, 100, 10000);
                LogSystem.LogWithColor("今世你是大財團的三公子", "#f99");
            }
            if (randomStart == 2)
            {
                stats = new CharacterStats(1, 0, 0, 100, 500);
                LogSystem.LogWithColor("今世你出生在一般的上班族家庭", "#f99");
            }
            if (randomStart == 3)
            {
                stats = new CharacterStats(1, 10, 0, 100, 1500);
                LogSystem.LogWithColor("今世你出生電競世家", "#f99");
            }
        }

        public void TriggerEvent(string eventName)
        {
            stats.ModifyStat("age", 1);
            float ageCheck = stats.age / 4;
            switch (eventName)
            {
                case "Learn":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("流著口水，聽著古典樂就成長了", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("在幼稚園捏泥巴，玩玩具就長大了", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("ability", 2);
                        stats.ModifyStat("money", -80);
                    } 
                    #endregion
                    break;
                case "Social":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("對著面前不知是哪位的大媽咯咯笑", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("逛街時，對路上的小姐姐眨眨眼", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("sociability", 2);
                        stats.ModifyStat("money", -100);
                    } 
                    #endregion
                    break;
                case "Work":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("啃著沾有奶粉的手手被直播了", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("過年時，對著爺爺奶奶輸出一頓小搥搥", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("ability", 1);
                        stats.ModifyStat("money", 400);
                    } 
                    #endregion
                    break;
                case "Rest":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("安安靜靜，世界和平", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("聽著Baby Shark，看著巧虎，終於歇停了會兒", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("health", 1);
                        stats.ModifyStat("money", -50);
                    } 
                    #endregion
                    break;
            }

        }
    }
}
