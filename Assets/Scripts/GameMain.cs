using UnityEngine;

namespace OLIVER
{
    /// <summary>
    /// 主腳本
    /// </summary>
    public class GameMain : MonoBehaviour
    {

    }

    public class CharacterStats
    {
        public int age;
        public int ability;
        public int money;
        public int Sociability;
        public int health;
    }
    /// <summary>
    /// 幼年期
    /// </summary>
    public class childhood : CharacterStats
    {

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
