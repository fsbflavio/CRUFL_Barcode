# Gerador de Código de Barras Intercalado 2/5 para Crystal Reports
[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/fsbflavio/CRUFL_Barcode/blob/main/README.en.md)
## Biblioteca UFL para gerar código de barras Intercalado 2/5 padrão FEBRABAN (usado em boletos bancários) para Crystal Reports

## Sobre
A biblioteca gera uma string para ser usada com a fonte Code 2/5 Interleaved (Code_2_5.ttf).

O código foi feito a partir do link abaixo [1], convertendo de da linguagem vba para C#.

Utilizei o manual do Crystal Reports [2][3] e uma biblioteca UFL [4] que encontrei no GitHub para tornar a dll do projeto visível no Crystal Reports.

O arquivo .ttf estava com a propriedade 'Inserção de fonte' como 'Restrito', isso impedia que a fonte fosse exportada para 
PDF [5], eu utilizei o programa 'ttfpatch' [6] para mudar o atributo para 'Instalável' permitindo a exportação.

## Uso Geral:
1-Instalar a fonte (arquivo Code_2_5.ttf)   
2-Usar a biblioteca para converter o conjunto numérico para o formato que a fonte entende.   
EX:
Entrada: "00198909600001567600000003364815000046685817" -> Saida: "(0Cç9Ê01ÆÚ0003T`?00^ÒÈA)"
Mudar a fonte da string de saída para a fonte Code 2/5 Interleaved (pode ser usado um editor de texto para teste como o word).

## Uso no Crystal Reports for Visual Studio
### Para uso no Crystal Reports 32 bits:
1-Compilar a dll especificamente para x86, (AnyCpu não funciona).   
2-Salvar a Dll em:   
	'C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win32_x86   
3-Acessar a pasta onde a Dll foi salva e Registra-la usando o RegAsm:
	"C:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe" /codebase CRUFL_Barcode.dll

### Para uso no Crystal Reports 64 bits:
1-Compilar a dll especificamente para x64, (AnyCpu não funciona).
2-Salvar a Dll em:
	'C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win64_x64
3-Acessar a pasta onde a Dll foi salva e Registra-la usando o RegAsm:
	"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe" /codebase CRUFL_Barcode.dll

OBS: O caminho para salvar a dll pode variar dependendo do produto SAP Crystal Reports

4-Após realizar os passos acima a função 'BarcodeInterleavedTo2of5()' vai estar visível no editor de formulas do Crystal Reports
dentro da listagem de formulas em 'formulas adicionais' dentro do Grupo COM/.NET

5-Adicione um campo de formula ao arquivo e mude a fonte para Code 2/5 Interleaved (a fonte precisa estar instalada).

## Referências
[1] Link da fonte (.ttf) e codigo original: 
https://www.mail-archive.com/sqlwin@virtualand.net/msg03351.html

[2] Link SAP Crystal Reports for Visual Studio .NET SDK
https://help.sap.com/docs/SAP_CRYSTAL_REPORTS,_DEVELOPER_VERSION_FOR_MICROSOFT_VISUAL_STUDIO/0d6684e153174710b8b2eb114bb7f843/45c5c9076e041014910aba7db0e91070.html?locale=en-US&q=ufl

[3] Link SAP Crystal Reports 2020 User Guide 
https://help.sap.com/docs/SAP_CRYSTAL_REPORTS/dfc124becfa845ffa91b1e717b20e3ec/477c74596e041014910aba7db0e91070.html?locale=en-US

[4] Projeto usado como base para criar uma biblioteca UFL:
https://github.com/wiggick/CRUFL_I18N

[5] Link ttfpatch: 
http://www.derwok.de/downloads/ttfpatch/index.html
https://github.com/rmuch/ttfpatch

[6] fsType flag reference
https://docs.microsoft.com/en-us/typography/opentype/spec/os2#fstype