INSERT INTO PrgValue(P_Type_Id, P_Language_Id, PrgValue) 
--SELECT PrgType_Id, PrgLanguage_Id, 'loop_num = 5' + CHAR(13) +CHAR(10) + 'for i in range(loop_num):'
SELECT PrgType_Id, PrgLanguage_Id, 'loop_num = 5' + CHAR(13) +CHAR(10) + 'For(i = 0; i < loop_num; i++){' + CHAR(13) +CHAR(10) + '}'
from PrgType, PrgLanguage where PrgLanguage_Name = 'C#' AND PrgType.PrgType_Name = 'for';

SELECT * FROM PrgType;
SELECT * FROM PrgLanguage;
SELECT * FROM PrgValue;
--SELECT PrgLanguage_Id from PrgLanguage where PrgLanguage_Name = 'Python';