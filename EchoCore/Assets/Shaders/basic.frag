#version 460 core
layout (location = 0) out vec4 color;

in vec2 texCoord;

uniform vec4 uColor = vec4(1.0);

uniform sampler2D tex0;
uniform sampler2D tex1;

void main()
{
	color = uColor * mix(texture(tex0, texCoord), texture(tex1, texCoord), 0.5);
}