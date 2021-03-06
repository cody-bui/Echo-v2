### *welcome to Echo v2 !*

***`components:`***\
	- **echo core:** handle the interactions between components of the program: event system, background calculations...\
	- **echo gen:** handle the level generation of the program\
	- **echo visual:** handle the rendering component of the program: shaders, buffers...\
	- **echo editor:** the level editor, possibly written in c# dotnet running on a c++ library

__note__: these components maybe merged together into one in the future

- ***`echo visual:`***
	- buffer classes
	- renderer classes
	- shader classes
	- meshing, material...

- ***`echo core:`***
	- all-purpose container class
	- new beat object class
	- new shape class
	- new event class -> input / custom event
	- adding shape to database
	- adding shape to beat object
	- adding beat object to database
	- adding event to beat object

- ***`echo gen:`*** pssd stuff, not really relevant for now

- ***`echo editor:`*** call echo core functions to add content into the game
	- add new shape -> call add new shape function from echo core into a vector

\
*`echo core structure:`*
- running on `entity component system` (as the name suggest, they'll be the three main elements of the engine):
	- entity: a set of components that forms a logical game element
	- component: a set of functionalities or data that the program uses
	- system: pretty much everything combined, handling logic functionalities and rendering functionalities

- components: a small set of functionalities or data that the program uses
- possible components:
	- `transform:` position on the display
	- `motion:` movement pattern, acceleration, velocity...
	- `sprite:` appearance on the display
	- `hit:` interaction with player-controlled entities
	- `tick:` lifetime of an entity
	- `control:` keyboard, mouse, etc.
	- `audio:` not to be confused with music, since it's independent of everything else

- entities: a group of components that made up a fully functioning object of the program
- possible entities:
	- controllable object: the only component that receives the input: Player class, cursor (osu!std), hit circle (taiko)...
		- `transform`: location on the screen
		- `motion`: may not be needed for many games, if the controllable object doesn't move and only beat object moves

	- beat note: aka game object
		- `transform, motion, sprite, hit, tick, audio` (everything except `control`)
		- `transform`: drawing multiple similar notes on the display
		- `motion`: possibly static along objects
		- `sprite`: containing various rendering elements: curves, circles, squares, rectangles...
		- `hit`: using raised event data to determine if the cursor is hit or not
		- `tick`: divide the lifetime of the beat object to different ticks, thereby determining the score
		- `audio`: play audio when `hit` is raised


- ecs overview:
	- `entities` are used to provide a unique identifier, making the environment aware of the the set of bundled components
		- it's basically just an id and optionally other functions to let the environment recognizes what it is, nothing else
	- `entity manager` creates entities and keep track of them *`(sucessfully implemented)`*
		- divides entities into pool of entities: `player` pool, `npc` pool, `boxes` pool...
		- `static int staticid` keeps track of the id -> different pools but different ids
	- `system`: to keep track of the components and entities and mke sure that they never tick (update)

- possible implementation:
	- *e.g.:* `player` class: player class will create a new entity and add all the desired components into it
	- `player` does not inherit from entity. it simply creates an entity (by calling the entity manager and component manager)
	- hitbox detecting system: when an attack event is raised, it will go through every entities with a health component and check it's transform component to see if it's a hit or not
	-> would be a bit more convenient to make entity and component manager public

	- memory layout:
		- `components` are mapped to dictionary keys, holding sequential components and entities id
		- `entities` are stored in a sequential list -> entities held in dictionary has direct index access to the entities themselves
	
```c#
// possibly inherit from system, since player itself can be a player creation system
public class Player /* : EntityComponentSystem */
{
	public void CreatePlayer()
	{
		Entity entity = EntityManager.Add</*??? create a new entity or use a separate entity id class ???*/>();
		ComponentManager.Add<T1...>(entity);
	}
}

public class AttackSystem
{
	public void OnAttack(object sender, AttackData e)
	{
		// since we know which target can be affected by the attack (or cannot), 
		// we can loop through every components and only deal damange to the type we wanted to
	}
}
```