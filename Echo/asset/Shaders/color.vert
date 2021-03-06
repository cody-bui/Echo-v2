﻿#version 460 core
layout(location = 0) in vec4 aPosition;

uniform mat4 model = mat4(1.0);
uniform mat4 view = mat4(1.0);
uniform mat4 proj = mat4(1.0);

void main()
{
	gl_Position = proj * model * view * aPosition;
}