using UnityEngine;

namespace Nojumpo
{
    public class RecursionTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] int CurrentValue = 10;
        [SerializeField] int AddUpValue = 20;
        [SerializeField] int IncrementAmount = 20;
        [SerializeField] int RepeatAmount = 2;
        
        
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Start() {
            Debug.Log(FindIncrementingValue(CurrentValue, AddUpValue,IncrementAmount, RepeatAmount).ToString());
        }
        
        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        int FindIncrementingValue(int currentValue, int addUpValue, int addUpIncrementAmount, int repeatAmount) {
            if (repeatAmount == 0)
            {
                return currentValue;
            }

            currentValue += addUpValue;
            return FindIncrementingValue(currentValue, addUpValue + addUpIncrementAmount, addUpIncrementAmount, repeatAmount - 1);
        }
    }
}