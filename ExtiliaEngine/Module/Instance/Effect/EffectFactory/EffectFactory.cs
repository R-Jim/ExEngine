using System;
namespace ExtiliaEngine
{
    public class EffectFactory
    {
        public string[] Types { get; }

        public Factory CoordinateFactory { get; }

        public Factory ValueFactory { get; }

        public Factory SourceFactory { get; }


        public EffectFactory(string[] types, Factory coordinateFactory,
            Factory valueFactory, Factory sourceFactory)
        {
            Types = types;
            CoordinateFactory = coordinateFactory;
            ValueFactory = valueFactory;
            SourceFactory = sourceFactory;
        }

        public Effect GetEffect(Effect effect)
        {
            return new Effect(Types, (Coordinate)CoordinateFactory.GetValue(effect),
                ValueFactory.GetValue(effect), (Instance)SourceFactory.GetValue(effect));
        }
    }
}