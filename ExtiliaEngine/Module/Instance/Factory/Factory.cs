using ExtiliaEngine.Module.Instance.Factory.Modifier;
using System.Collections.Generic;
namespace ExtiliaEngine
{
    public class Factory
    {
        protected string FieldPath { get; }
        protected object BaseValue;
        protected Modifier Modifier { get; }

        public Factory(object baseValue)
            : this(null, baseValue, null)
        {

        }

        public Factory(string fieldPath)
            : this(fieldPath, null, null)
        {

        }

        public Factory(string fieldPath, object baseValue, string modifier)
        {
            FieldPath = fieldPath;
            BaseValue = baseValue;
            Modifier = ModifierController.GetModifier(modifier, baseValue);
        }

        public object GetValue(Effect effect)
        {
            object fieldValue = Util.GetFieldValue(FieldPath, effect);
            if(BaseValue == null)
            {
                return fieldValue;
            }
            return Modifier.GetModifiedValue(BaseValue, fieldValue);
        }
    }
}