ctp = CTPMTM();%����iCTP MATLAB����
ctpID = ctp.create();%����CTPʵ��
if ctpID > 0
    reqID = ctp.generateReqID(ctpID); %��������id
    if reqID >= 0
        ctp.start(ctpID, reqID, '218.202.237.33:10012', '218.202.237.33:10002', '9999', '021739', '123456');%��¼����,���׷�����
        while (1 == 1)
            if ctp.isMdLogined(ctpID) >= 0
                if ctp.isTdLogined(ctpID) >= 0
                    fprintf('��¼�ɹ�!!!!!!!!!!\n');
                    break;
                end
            end
            fprintf('��¼���ɹ�, 5S���������\n');
            pause(5);
        end
        subStatus = ctp.subMarketDatas(ctpID, reqID, 'cu1712');%���Ĺ�Ʊ��Ϣ
        if subStatus > 0
            while (1 == 1) %ѭ����ȡ��Ʊ��Ϣ
                mp = ctp.getDepthMarketData(ctpID);
                %keys(mp);
                %values(mp);
                keys = mp.keys;
                len = length(keys) -1;
                if len > 0 %����й�Ʊ��Ϣ�������Ʊ��Ϣ
                    for w = 1: len
                        fprintf('%s : %s \n', char(keys(w)), char(mp(char(keys(w)))));
                    end
                else
                     fprintf('û������\n');
                end
                pause(5);
            end
        end
        fprintf('����ʧ��!!\n');
    end
end
 fprintf('��¼ʧ��!!\n');