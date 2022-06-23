#pragma once
#include<string>
using namespace System;

namespace CodeDLL {
	public ref class code
	{
	public:
		static char* Encode(char* str)
		{
			int f = 1;
			for (int i = 0; i < strlen(str); i++)
			{
				str[i] = str[i] + f;
				f = -f;
			}

			return str;
		}

		static char* Decode(char* str)
		{
			int f = -1;
			for (int i = 0; i < strlen(str); i++)
			{
				str[i] = str[i] + f;
				f = -f;
			}
			return str;
		}
	};
}
