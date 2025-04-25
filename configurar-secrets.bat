@echo off
echo === Configurando User Secrets para Vasis.Erp.Facil ===

REM Inicializa secrets no projeto
dotnet user-secrets init

REM Define a connection string com autenticação do Windows
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=Vega02;Database=vasis_erp;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True"

REM Define a chave JWT com pelo menos 32 caracteres
dotnet user-secrets set "JwtSettings:Secret" "supersegur@_chave_de_32_bytes!!"

REM Define issuer e audience
dotnet user-secrets set "JwtSettings:Issuer" "Vasis.Erp.Facil"
dotnet user-secrets set "JwtSettings:Audience" "Vasis.Erp.Facil"
dotnet user-secrets set "JwtSettings:ExpireHours" "2"

echo === Configuração finalizada com sucesso ===
pause
