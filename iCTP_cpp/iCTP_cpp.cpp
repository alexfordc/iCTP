// iCTP_cpp.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include "CTP.h"

int _tmain(int argc, _TCHAR* argv[])
{
	CTP *ctp = new CTP;
    ctp->run();
	while(true)
	{
		char *input = new char[1024];
		cin >> input;
		if(strcmp(input, "exit") == 0)
		{
			break;
		}
	}
	return 0;
}

