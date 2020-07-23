namespace ExtiliaEngine
{
    public class ObjectCondition : Condition
    {
        public object BaseObject { get; }
        public string ObjectFieldPath { get; }

        public ObjectCondition(string fieldPath, string conditionOperator,
            object baseObject, string objectFieldPath)
            : base(fieldPath, conditionOperator, null)
        {
            BaseObject = baseObject;
            ObjectFieldPath = objectFieldPath;
        }

        public new bool IsMatchCondition(object inputObject)
        {
            BaseValue = Util.GetFieldValue(ObjectFieldPath, BaseObject);
            return base.IsMatchCondition(inputObject);
        }
    }
}