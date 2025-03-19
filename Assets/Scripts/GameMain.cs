using UnityEngine;

namespace OLIVER
{
    /// <summary>
    /// 主腳本
    /// </summary>
    public class GameMain : MonoBehaviour
    {
        [SerializeField, Header("年齡")]
        public int age;
        [SerializeField, Header("能力")]
        public int ability;
        [SerializeField, Header("社交")]
        public int sociability;
        [SerializeField, Header("健康")]
        public int health;
        [SerializeField, Header("金錢")]
        public int money;

        private void Awake()
        {
            LogSystem.LogWithColor("恭喜你終於破防了，精生也請多多指教!!", "#f0f");
            int randomStart = Random.Range(0, 4);
            // 熱愛戶外之家
            if (randomStart == 0)
            {
                age = 1;
                ability = 0;
                sociability = 10;
                health = 120;
                money = 800;
                LogSystem.LogWithColor("今世你出生在熱愛戶外活動的家庭", "#f99");
            }
            // 大財團
            if (randomStart == 1)
            {
                age = 1;
                ability = 5;
                sociability = 5;
                health = 100;
                money = 10000;
                LogSystem.LogWithColor("今世你是大財團的三公子", "#f99");
            }
            // 平民
            if (randomStart == 2)
            {
                age = 1;
                ability = 0;
                sociability = 0;
                health = 100;
                money = 500;
                LogSystem.LogWithColor("今世你出生在一般的上班族家庭", "#f99");
            }
            // 平民
            if (randomStart == 3)
            {
                age = 1;
                ability = 10;
                sociability = 0;
                health = 100;
                money = 1500;
                LogSystem.LogWithColor("今世你出生電競世家", "#f99");
            }
            childhood child1 = new childhood();
            child1.test();
        }



        public class CharacterStats
        {
            public int age;
            public int ability;
            public int sociability;
            public int health;
            public int money;
            
        }
        /// <summary>
        /// 幼年期
        /// </summary>
        public class childhood : CharacterStats
        {
            public void test()
            {
                LogSystem.LogWithColor($"數值{age}, {ability}, {sociability}, {health}, {money}", "#f00");
            }
        }
        /// <summary>
        /// 少年期
        /// </summary>
        public class juvenile : CharacterStats
        {

        }
        /// <summary>
        /// 青年期
        /// </summary>
        public class youth : CharacterStats
        {

        }
        /// <summary>
        /// 成人期
        /// </summary>
        public class adult : CharacterStats
        {

        }
    }
}
