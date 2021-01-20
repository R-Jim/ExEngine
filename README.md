# ExEngine (Jul 23, 2020 Deprecated), HexEngine (coming soon)
An Instance Module Engine

1. EngineTest: Unit test for Engine
   - ScenarioTest: Describe how this engine should be use for normal game's behaviour.
2. ExtiliaEngine:
   - Module: all basic functions of Engine
     - Instance: Main focus of Engine. Everything invole with Effect -> Instance -> Effect
     - Util

Workflow for instance (Deprecated):

```***Factory```: A class that will modify the assigned ```BaseValue``` base on the field path of input object

Each ```Instance``` and bound with:
 - ```ValueFactory``` that will change value based on If that Instance was triggered.
 - ```Trigger``` triggered if the input Effect match Trigger's ```Condition``` and return an the ```Effect``` created by the assigned ```EffectFactory```

