* THIS IS THE BASE LINE FOR GAME IMPLEMENTATION *
- This followed the quote "Everything is a module"
Example of game objects:
@anotation: [O]: Output, [I]: Input, "Path": field path, 'field': field
-- Case S-1: Wall game object
---- Description<I>: wall description, 'Value' = I'm a wall
---- Coordinate<I>: Positioning for game object, 'Value' = [1,1]
---- [O]Effect for any [I]'Effect.Target' != 'this', [O]'Effect.Value' = 'Effect.Value' * -1
---- Hp<I>: Health point 
---- 'Value' change if "Trigger.Condition.BaseObject.Coordinate" == Effect.Coordinate && Effect.Types["HP"]
