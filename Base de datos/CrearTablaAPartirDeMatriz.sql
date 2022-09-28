USE alscript
GO

SELECT 
    *
INTO ExamenTabla
FROM OPENROWSET(
    'Microsoft.ACE.OLEDB.12.0',
    'Excel 12.0 Xml;HDR=YES;Database=C:\Datos\DB.xlsx',
    'SELECT * FROM [matriz$]'
); 