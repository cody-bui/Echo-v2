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
- *beat object class:* running based on entity component system
- game components:
	- `transform:` position on the display
	- `motion:` movement pattern, acceleration, velocity...
	- `sprite:` appearance on the display
	- `hit:` interaction with player-controlled entities
	- `tick:` lifetime of an entity
	- `control:` keyboard, mouse, etc.
	- `audio:` not to be confused with music, since it's independent of everything else

- possible entities:
	```c#
	void Entites::Add(ComponentManager cm)
	{
		cm.Components.push_back(this);
	}
	```

	- cursor:
		- gl.createcursor()
		- `sprite, hit, tick, control`
		- no `transform` component since cursor will take real time position
		- `sprite`: the appearance of cursor on the screen: size, shape, trail, look...

	- beat note: aka game object
		- `transform, motion, sprite, hit, tick, audio` (everything except `control`)
		- `transform`: drawing multiple similar notes on the display
		- `motion`: possibly static along objects
		- `sprite`: containing various rendering elements: curves, circles, squares, rectangles...
		- `hit`: using raised event data to determine if the cursor is hit or not
		- `tick`: 
		- `audio`: play audio when `hit` is raised

- component manager:
	- contain pretty much nothing but the component id
	- hold a vector of components

- event system:
	- event manager class
	```c#
	class EventManager
	{
		public delegate void EventManagerEventHandler(object sender, EventArgs e);
		public event EventManagerEventHandler EventManagerEvent;

		protected virtual void 
	}
	```