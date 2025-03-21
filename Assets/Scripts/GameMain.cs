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
            stats.ModifyStat("health", -1);
            float ageCheck = stats.age / 4;
            switch (eventName)
            {
                case "Learn":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("流著口水，聽著古典樂就成長了<<能力+2，金錢-80>>", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("在幼稚園捏泥巴，玩玩具就長大了<<能力+2，金錢-80>>", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("ability", 2);
                        stats.ModifyStat("money", -80);
                    }
                    #endregion

                    #region 少年時期
                    // 少年時期
                    if (ageCheck > 2 && ageCheck < 3)
                    {
                        LogSystem.LogWithColor("九九乘法他悄悄地來，悄悄地走<<能力+3，金錢-120>>", "#f09");
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        LogSystem.LogWithColor("二元一次方程式，與我總如初相識<<能力+3，金錢-120>>", "#f09");
                    }
                    if (ageCheck > 2 && ageCheck < 4 && ageCheck != 3)
                    {
                        stats.ModifyStat("ability", 3);
                        stats.ModifyStat("money", -120);
                    }
                    #endregion

                    #region 青年時期
                    // 青年時期
                    if (ageCheck > 4 && ageCheck < 5)
                    {
                        LogSystem.LogWithColor("微積分有什麼難度，我都查危機百科<<能力+5，金錢-150>>", "#f09");
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        LogSystem.LogWithColor("咦?專題的完成進度，總是跟我的個人進度巧妙的吻合???<<能力+5，金錢-150>>", "#f09");
                    }
                    if (ageCheck > 4 && ageCheck < 6 && ageCheck != 5)
                    {
                        stats.ModifyStat("ability", 5);
                        stats.ModifyStat("money", -150);
                    }
                    #endregion

                    #region 壯年時期
                    // 狀年時期
                    if (ageCheck > 6 && ageCheck < 7)
                    {
                        LogSystem.LogWithColor("下班後還去聯成上C#課程，這樣置入有折扣嗎<<能力+7，社交+1，金錢-200>>", "#f09");
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        LogSystem.LogWithColor("C#上完接著上Unity，又置入啦，為什麼說又呢?<<能力+7，社交+1，金錢-200>>", "#f09");
                    }
                    if (ageCheck > 6 && ageCheck < 8 && ageCheck != 7)
                    {
                        stats.ModifyStat("ability", 7);
                        stats.ModifyStat("sociability", 1);
                        stats.ModifyStat("money", -200);
                    } 
                    #endregion
                    break;
                case "Social":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("對著面前不知是哪位的大媽咯咯笑<<社交+2，金錢-100>>", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("逛街時，對路上的小姐姐眨眨眼<<社交+2，金錢-100>>", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("sociability", 2);
                        stats.ModifyStat("money", -100);
                    }
                    #endregion

                    #region 少年時期
                    // 少年時期
                    if (ageCheck > 2 && ageCheck < 3)
                    {
                        LogSystem.LogWithColor("揪同學到圖書館集合，玩傳說對決<<社交+3，金錢-150>>", "#f09");
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        LogSystem.LogWithColor("揪同學到陸鱷鯊集合，玩PTCG<<社交+3，金錢-150>>", "#f09");
                    }
                    if (ageCheck > 2 && ageCheck < 4 && ageCheck != 3)
                    {
                        stats.ModifyStat("sociability", 3);
                        stats.ModifyStat("money", -150);
                    }
                    #endregion

                    #region 青年時期
                    // 青年時期
                    if (ageCheck > 4 && ageCheck < 5)
                    {
                        LogSystem.LogWithColor("我們社團的宗旨是：智商少一半，快樂不間斷<<社交+5，金錢-180>>", "#f09");
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        LogSystem.LogWithColor("約同學逛夜市，結果被夜市王的人潮擠爆了<<社交+5，金錢-180>>", "#f09");
                    }
                    if (ageCheck > 4 && ageCheck < 6 && ageCheck != 5)
                    {
                        stats.ModifyStat("sociability", 5);
                        stats.ModifyStat("money", -180);
                    }
                    #endregion

                    #region 壯年時期
                    // 狀年時期
                    if (ageCheck > 6 && ageCheck < 7)
                    {
                        LogSystem.LogWithColor("約同事一起聚餐，開始建立人脈了<<能力+1，社交+7，金錢-250>>", "#f09");
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        LogSystem.LogWithColor("去貓舍做義工，撸貓比人際關係輕鬆多了<<能力+1，社交+7，金錢-250>>", "#f09");
                    }
                    if (ageCheck > 6 && ageCheck < 8 && ageCheck != 7)
                    {
                        stats.ModifyStat("ability", 1);
                        stats.ModifyStat("sociability", 7);
                        stats.ModifyStat("money", -250);
                    } 
                    #endregion
                    break;
                case "Work":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("啃著沾有奶粉的手手被直播了<<能力+1，金錢-400>>", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("過年時，對著爺爺奶奶輸出一頓小搥搥<<能力+1，金錢-400>>", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("ability", 1);
                        stats.ModifyStat("money", 400);
                    }
                    #endregion

                    #region 少年時期
                    // 少年時期
                    if (ageCheck > 2 && ageCheck < 3)
                    {
                        LogSystem.LogWithColor("幫爸爸出售Pokemon Ga-Ole的卡閘<<能力+1，社交+1，金錢+500>>", "#f09");
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        LogSystem.LogWithColor("去阿姨的美食直播幫忙吃東西<<能力+1，社交+1，金錢+500>>", "#f09");
                    }
                    if (ageCheck > 2 && ageCheck < 4 && ageCheck != 3)
                    {
                        stats.ModifyStat("ability", 1);
                        stats.ModifyStat("sociability", 1);
                        stats.ModifyStat("money", 500);
                    }
                    #endregion

                    #region 青年時期
                    // 青年時期
                    if (ageCheck > 4 && ageCheck < 5)
                    {
                        LogSystem.LogWithColor("飲料店的時薪，居然不如我5歲的小搥搥<<能力+2，社交+1，金錢+800>>", "#f09");
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        LogSystem.LogWithColor("到企業實習，主要工作是訂下午茶??<<能力+2，社交+1，金錢+800>>", "#f09");
                    }
                    if (ageCheck > 4 && ageCheck < 6 && ageCheck != 5)
                    {
                        stats.ModifyStat("ability", 2);
                        stats.ModifyStat("sociability", 1);
                        stats.ModifyStat("money", 800);
                    }
                    #endregion

                    #region 壯年時期
                    // 狀年時期
                    if (ageCheck > 6 && ageCheck < 7)
                    {
                        LogSystem.LogWithColor("加班賣肝，老闆賺翻<<能力+3，健康-2，金錢+1000>>", "#f09");
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        LogSystem.LogWithColor("與其把肝賣給公司，何不直接賣給醫院??<<能力+3，健康-2，金錢+1000>>", "#f09");
                    }
                    if (ageCheck > 6 && ageCheck < 8 && ageCheck != 7)
                    {
                        stats.ModifyStat("ability", 3);
                        stats.ModifyStat("health", -2);
                        stats.ModifyStat("money", 1000);
                    } 
                    #endregion
                    break;
                case "Rest":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("安安靜靜，世界和平<<健康+2，金錢-50>>", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("聽著Baby Shark，看著巧虎，終於歇停了會兒<<健康+2，金錢-50>>", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("health", 2);
                        stats.ModifyStat("money", -50);
                    }
                    #endregion

                    #region 少年時期
                    // 少年時期
                    if (ageCheck > 2 && ageCheck < 3)
                    {
                        LogSystem.LogWithColor("每天9點準時就寢，爸媽覺得擔心<<健康+3，金錢-50>>", "#f09");
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        LogSystem.LogWithColor("和媽媽一起去上瑜珈課，放鬆身心<<健康+3，金錢-50>>", "#f09");
                    }
                    if (ageCheck > 2 && ageCheck < 4 && ageCheck != 3)
                    {
                        stats.ModifyStat("health", 3);
                        stats.ModifyStat("money", -50);
                    }
                    #endregion

                    #region 青年時期
                    // 青年時期
                    if (ageCheck > 4 && ageCheck < 5)
                    {
                        LogSystem.LogWithColor("在家是想多陪伴家人，絕對不是沒朋友什麼的<<健康+5，金錢-50>>", "#f09");
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        LogSystem.LogWithColor("俗話說的好，在哪裡跌倒就在哪裡躺下<<健康+5，金錢-50>>", "#f09");
                    }
                    if (ageCheck > 4 && ageCheck < 6 && ageCheck != 5)
                    {
                        stats.ModifyStat("health", 5);
                        stats.ModifyStat("money", -50);
                    }
                    #endregion

                    #region 壯年時期
                    // 狀年時期
                    if (ageCheck > 6 && ageCheck < 7)
                    {
                        LogSystem.LogWithColor("都20好幾了，你以為還能躺著發育嗎<<能力-3，社交-3，健康+7，金錢-100>>", "#f09");
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        LogSystem.LogWithColor("都這個時候了，肯定不是躺平，這是戰略性休息<<能力-3，社交-3，健康+7，金錢-100>>", "#f09");
                    }
                    if (ageCheck > 6 && ageCheck < 8 && ageCheck != 7)
                    {
                        stats.ModifyStat("ability", -3);
                        stats.ModifyStat("sociability", -3);
                        stats.ModifyStat("health", 7);
                        stats.ModifyStat("money", -100);
                    } 
                    #endregion
                    break;
            }

        }
    }
}
