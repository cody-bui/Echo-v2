#version 460 core
layout(location = 0) in vec4 aPosition;

uniform mat4 mvp = mat4(1.0);

void main()
{
	gl_Position = mvp * aPosition;
}