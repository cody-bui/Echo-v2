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
- *beat object class:*
	```c++
	class BeatObject
	{
	protected:
		std::vector<RenderElement> render;
		std::vector<LogicElement> logic;
	public:
		void AddRenderElement(RenderElement& element) { render.push_back(element); }
		void AddLogicElement(LogicElement& element)	{ logic.push_back(element);	}
	}
	```

- *event system:*
	- event args class
	- event dispatcher class