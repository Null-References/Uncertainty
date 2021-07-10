using System.Collections.Generic;
using System.Linq;
using NPC.Enemy_AI.StateMachine.Conditions;

namespace Utils
{
    public static class ConditionExtension
    {
        public static bool AreMet(this List<Condition> conditions) => conditions.All(item => item.IsMet);
    }
}