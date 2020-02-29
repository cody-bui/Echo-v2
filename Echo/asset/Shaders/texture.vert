#version 460 core
layout (location = 0) in vec4 aPosition;
layout (location = 1) in vec2 aTexCoord;

uniform mat4 mvp = mat4(1.0);

out vec2 texCoord;

void main()
{
	texCoord = aTexCoord;
	gl_Position = mvp * aPosition;
}