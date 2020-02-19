#version 460 core
layout (location = 0) out vec4 color;

in vec2 texCoord;

uniform sampler2D tex0;
uniform sampler2D tex1;
uniform float blend = 0.5;

void main()
{
	color = mix(texture(tex0, texCoord), texture(tex1, texCoord), blend);
}