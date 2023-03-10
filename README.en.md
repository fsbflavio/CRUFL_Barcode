# Interleaved 2/5 Barcode Generator for Crystal Reports
## UFL Library to Generate FEBRABAN Standard Interleaved 2/5 Barcodes (Used in Bank Slips) for Crystal Reports

## About
The library generates a string to be used with the Code 2/5 Interleaved font (Code_2_5.ttf).

The code was created from the link below [1], by converting from VBA language to C#.

I used the Crystal Reports manual [2][3] and a UFL library [4] that I found on GitHub to make the project's DLL visible in Crystal Reports.

The .ttf file had the 'Font Embedding' property set to 'Restricted', which prevented the font from being exported to PDF [5]. I used the 'ttfpatch' program [6] to change the attribute to 'Installable', allowing for the export.

## General Usage:
1-Install the font (Code\_2\_5.ttf file)  
2-Use the library to convert the numeric set to the format that the font understands.  
EXAMPLE: Input: "00198909600001567600000003364815000046685817" -> Output: "(0Cç9Ê01ÆÚ0003T\`?00^ÒÈA)" Change the font of the output string to the Code 2/5 Interleaved font (a text editor such as Word can be used for testing).

## Usage in Crystal Reports for Visual Studio

### For use in 32-bit Crystal Reports:

1-Compile the DLL specifically for x86 (AnyCpu doesn't work).  
2-Save the DLL in:  
'C:\\Program Files (x86)\\SAP BusinessObjects\\Crystal Reports for .NET Framework 4.0\\Common\\SAP BusinessObjects Enterprise XI 4.0\\win32\_x86  
3-Access the folder where the DLL was saved and register it using RegAsm: "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\RegAsm.exe" /codebase CRUFL\_Barcode.dll

### For use in 64-bit Crystal Reports:

1-Compile the DLL specifically for x64 (AnyCpu doesn't work).  
2-Save the DLL in:  
'C:\\Program Files (x86)\\SAP BusinessObjects\\Crystal Reports for .NET Framework 4.0\\Common\\SAP BusinessObjects Enterprise XI 4.0\\win64\_x64 3-Access the folder where the DLL was saved and register it using RegAsm: "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\RegAsm.exe" /codebase CRUFL\_Barcode.dll

NOTE: The path to save the DLL may vary depending on the SAP Crystal Reports product.

4-After completing the above steps, the 'BarcodeInterleavedTo2of5()' function will be visible in the Crystal Reports formula editor under the formula listing in 'Additional Formulas' within the COM/.NET group.

5-Add a formula field to the file and change the font to the Code 2/5 Interleaved font (the font needs to be installed).

## References
[1] Source link (.ttf) and original code:
https://www.mail-archive.com/sqlwin@virtualand.net/msg03351.html

[2] SAP Crystal Reports for Visual Studio .NET SDK link:
https://help.sap.com/docs/SAP_CRYSTAL_REPORTS,_DEVELOPER_VERSION_FOR_MICROSOFT_VISUAL_STUDIO/0d6684e153174710b8b2eb114bb7f843/45c5c9076e041014910aba7db0e91070.html?locale=en-US&q=ufl

[3] Link SAP Crystal Reports 2020 User Guide 
https://help.sap.com/docs/SAP_CRYSTAL_REPORTS/dfc124becfa845ffa91b1e717b20e3ec/477c74596e041014910aba7db0e91070.html?locale=en-US

[4] Project used as a base to create a UFL library:
https://github.com/wiggick/CRUFL_I18N

[5] ttfpatch link:
http://www.derwok.de/downloads/ttfpatch/index.html
https://github.com/rmuch/ttfpatch

[6] fsType flag reference:
https://docs.microsoft.com/en-us/typography/opentype/spec/os2#fstype