namespace ExtiliaEngine
{
    public class Effect
    {
        public string[] Types { get; }
        public Coordinate Coordinate { get; }
        public object Value { get; }
        public Instance Source;
        public Instance Target;

        public Effect(string[] types, Coordinate coordinate, object value)
            : this(types, coordinate, value, null, null)
        {

        }

        public Effect(string[] types, Coordinate coordinate, object value, Instance source)
            : this(types, coordinate, value, source, null)
        {

        }

        public Effect(string[] types, Coordinate coordinate, object value, Instance source, Instance target)
        {
            Types = types;
            Coordinate = coordinate;
            Value = value;
            Source = source;
            Target = target;
        }

        public Effect NewEffectWithTarget(Instance target)
        {
            return new Effect(Types, Coordinate, Value, Source, target);
        }
    }
}