
using UnityEngine;

[CreateAssetMenu(menuName = "1111")]
public abstract class Conditions : ScriptableObject
{
        public abstract bool IsMet();
}


public class TestCondition : Conditions
{
        
        public override bool IsMet()
        {
                return true;
        }
}