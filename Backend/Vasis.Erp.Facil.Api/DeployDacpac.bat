@echo off
:: Caminho do SqlPackage
set SQLPACKAGE_PATH="C:\Program Files\Microsoft SQL Server\160\DAC\bin\SqlPackage.exe"

:: Caminho onde o .dacpac será salvo
set DACPAC_PATH="C:\Backups\VasisErpFacilDB.dacpac"

:: Detalhes do banco de dados
set SOURCE_SERVER="localhost"
set SOURCE_DB="VasisErpFacilDB"
set TARGET_SERVER="localhost"
set TARGET_DB="VasisErpFacilDB_Homolog"

:: Gerar .dacpac (extração do banco)
echo Gerando .dacpac de %SOURCE_DB%...
%SQLPACKAGE_PATH% /Action:Extract /SourceServerName:%SOURCE_SERVER% /SourceDatabaseName:%SOURCE_DB% /TargetFile:%DACPAC_PATH%

:: Verificar se gerou o .dacpac com sucesso
if exist %DACPAC_PATH% (
    echo .dacpac gerado com sucesso!
    echo Publicando no banco de homologação...

    :: Publicar .dacpac no banco de homologação
    %SQLPACKAGE_PATH% /Action:Publish /SourceFile:%DACPAC_PATH% /TargetServerName:%TARGET_SERVER% /TargetDatabaseName:%TARGET_DB%
    if %ERRORLEVEL% EQU 0 (
        echo Banco de dados %TARGET_DB% publicado com sucesso!
    ) else (
        echo Erro ao publicar o banco de dados.
    )
) else (
    echo Erro ao gerar o .dacpac. Verifique se o caminho está correto.
)

pause
