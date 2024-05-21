using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PersonalLibrary.Utilities;

namespace Core
{
    public class DataManager : Singleton<DataManager>
    {
        public int HealthPoints = Constants.Num.DefaultHealth;
    }
}